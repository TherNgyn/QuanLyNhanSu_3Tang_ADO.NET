using QuanLyNhanSu_3Tang_ADO.DB_Layer;
using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace QuanLyNhanSu_3Tang_ADO.BS_Layer
{
    public class BLNghiPhep
    {
        DBMain db = new DBMain();

        public DataSet LayNghiPhep()
        {
            string sql = @"SELECT np.MaNV, np.MaThang, np.NgayNghiPhep, np.GhiChu, nv.Ho + ' ' + nv.Ten AS TenNV, t.MoTa AS TenThang
                           FROM NghiPhep np 
                           JOIN NhanVien nv ON np.MaNV = nv.MaNV
                           JOIN Thang t ON np.MaThang = t.MaThang";
            return db.ExecuteQueryDataSet(sql, CommandType.Text);
        }

        // Hàm mô phỏng trigger tr_NghiPhep_ctChamCong_CheckNghiPhep
        private bool ThemVaoChamCong(string maNV, string maThang, int ngayNghiPhep, ref string err)
        {
            try
            {
                
                string nam = maThang.Substring(2, 4);

                // Đếm số ngày nghỉ phép trong năm của nhân viên đó
                string sqlDemNgayNghi = @"SELECT COUNT(*) 
                                          FROM NghiPhep 
                                          WHERE MaNV = @MaNV AND RIGHT(MaThang, 4) = @Nam";
                SqlCommand cmdDemNgayNghi = new SqlCommand(sqlDemNgayNghi);
                cmdDemNgayNghi.Parameters.AddWithValue("@MaNV", maNV);
                cmdDemNgayNghi.Parameters.AddWithValue("@Nam", nam);

                DataSet dsSoNgayNghi = db.ExecuteQueryDataSetWithCmd(cmdDemNgayNghi, CommandType.Text);
                int soNgayDaNghi = Convert.ToInt32(dsSoNgayNghi.Tables[0].Rows[0][0]);

                // Xác định MaCC dựa trên số ngày đã nghỉ phép
                string maCC;
                if (soNgayDaNghi >= 13) // 13 là do tính cả bản ghi hiện tại
                {
                    string sqlMaCCKhongLuong = "SELECT MaCC FROM ChamCong WHERE MoTa LIKE N'%ghỉ không lương%'";
                    DataSet dsMaCCKhongLuong = db.ExecuteQueryDataSet(sqlMaCCKhongLuong, CommandType.Text);
                    maCC = dsMaCCKhongLuong.Tables[0].Rows[0]["MaCC"].ToString();
                }
                else
                {
                    string sqlMaCCPhepNam = "SELECT MaCC FROM ChamCong WHERE MoTa LIKE N'%ghỉ phép năm%'";
                    DataSet dsMaCCPhepNam = db.ExecuteQueryDataSet(sqlMaCCPhepNam, CommandType.Text);
                    maCC = dsMaCCPhepNam.Tables[0].Rows[0]["MaCC"].ToString();
                }

                // Thêm bản ghi vào bảng ctChamCong
                string sqlThemCtChamCong = "INSERT INTO ctChamCong (MaNV, MaCC, MaThang, NgayChamCong) VALUES (@MaNV, @MaCC, @MaThang, @NgayChamCong)";
                SqlCommand cmdThemCtChamCong = new SqlCommand(sqlThemCtChamCong);
                cmdThemCtChamCong.Parameters.AddWithValue("@MaNV", maNV);
                cmdThemCtChamCong.Parameters.AddWithValue("@MaCC", maCC);
                cmdThemCtChamCong.Parameters.AddWithValue("@MaThang", maThang);
                cmdThemCtChamCong.Parameters.AddWithValue("@NgayChamCong", ngayNghiPhep);

                return db.MyExecuteNonQuery(cmdThemCtChamCong, CommandType.Text, ref err);
            }
            catch (Exception ex)
            {
                err = "Lỗi khi thêm vào bảng chấm công: " + ex.Message;
                return false;
            }
        }

        // Kiểm tra xem ngày nghỉ có phải là ngày đã qua hay không
        private bool KiemTraNgayHopLe(string maThang, int ngayNghi, ref string err)
        {
            try
            {
             
                string thangStr = maThang.Substring(0, 2);
                string namStr = maThang.Substring(2, 4);

                int thang = int.Parse(thangStr);
                int nam = int.Parse(namStr);

                
                DateTime ngayDangKy = new DateTime(nam, thang, ngayNghi);

                
                if (ngayDangKy < DateTime.Today)
                {
                    err = "Không thể đăng ký nghỉ phép cho ngày đã qua!";
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                err = "Lỗi khi kiểm tra ngày: " + ex.Message;
                return false;
            }
        }

        public bool ThemNghiPhep(string maNV, string maThang, int ngayNghi, string ghiChu, ref string err)
        {
            try
            {
                
                if (!KiemTraNgayHopLe(maThang, ngayNghi, ref err))
                {
                    return false;
                }

        
                string sql = "INSERT INTO NghiPhep (MaNV, MaThang, NgayNghiPhep, GhiChu) VALUES (@MaNV, @MaThang, @Ngay, @GhiChu)";
                SqlCommand cmd = new SqlCommand(sql);
                cmd.Parameters.AddWithValue("@MaNV", maNV);
                cmd.Parameters.AddWithValue("@MaThang", maThang);
                cmd.Parameters.AddWithValue("@Ngay", ngayNghi);
                cmd.Parameters.AddWithValue("@GhiChu", ghiChu);

                bool ketQua = db.MyExecuteNonQuery(cmd, CommandType.Text, ref err);

                
                if (ketQua)
                {
                    string chamCongErr = "";
                    if (!ThemVaoChamCong(maNV, maThang, ngayNghi, ref chamCongErr))
                    {
                       
                        if (!string.IsNullOrEmpty(chamCongErr))
                        {
                            err += " " + chamCongErr;
                        }
                    }
                }

                return ketQua;
            }
            catch (Exception ex)
            {
                err = "Lỗi khi thêm nghỉ phép: " + ex.Message;
                return false;
            }
        }

        public bool CapNhatNghiPhep(string maNV, string maThang, int ngayNghi, string ghiChu, ref string err)
        {

            try
            {

                if (!KiemTraNgayHopLe(maThang, ngayNghi, ref err))
                {
                    return false;
                }

                string sql = "UPDATE NghiPhep SET NgayNghiPhep = @Ngay, GhiChu = @GhiChu WHERE MaNV = @MaNV AND MaThang = @MaThang";
                SqlCommand cmd = new SqlCommand(sql);
                cmd.Parameters.AddWithValue("@Ngay", ngayNghi);
                cmd.Parameters.AddWithValue("@GhiChu", ghiChu);
                cmd.Parameters.AddWithValue("@MaNV", maNV);
                cmd.Parameters.AddWithValue("@MaThang", maThang);

                bool ketQua = db.MyExecuteNonQuery(cmd, CommandType.Text, ref err);

              
                if (ketQua)
                {
                    
                    string sqlUpdateCtChamCong = "UPDATE ctChamCong SET NgayChamCong = @NgayChamCong WHERE MaNV = @MaNV AND MaThang = @MaThang";
                    SqlCommand cmdUpdateCtChamCong = new SqlCommand(sqlUpdateCtChamCong);
                    cmdUpdateCtChamCong.Parameters.AddWithValue("@NgayChamCong", ngayNghi);
                    cmdUpdateCtChamCong.Parameters.AddWithValue("@MaNV", maNV);
                    cmdUpdateCtChamCong.Parameters.AddWithValue("@MaThang", maThang);

                    string updateErr = "";
                    bool ketQuaUpdate = db.MyExecuteNonQuery(cmdUpdateCtChamCong, CommandType.Text, ref updateErr);

                    if (!ketQuaUpdate && !string.IsNullOrEmpty(updateErr))
                    {
                        err += " " + updateErr;
                    }
                }

                return ketQua;
            }
            catch (Exception ex)
            {
                err = "Lỗi khi cập nhật nghỉ phép: " + ex.Message;
                return false;
            }
        }

        public bool XoaNghiPhep(string maNV, string maThang, ref string err)
        {
            try
            {
               
                string sqlDeleteCtChamCong = "DELETE FROM ctChamCong WHERE MaNV = @MaNV AND MaThang = @MaThang";
                SqlCommand cmdDeleteCtChamCong = new SqlCommand(sqlDeleteCtChamCong);
                cmdDeleteCtChamCong.Parameters.AddWithValue("@MaNV", maNV);
                cmdDeleteCtChamCong.Parameters.AddWithValue("@MaThang", maThang);

                string deleteCtChamCongErr = "";
                db.MyExecuteNonQuery(cmdDeleteCtChamCong, CommandType.Text, ref deleteCtChamCongErr);
                string sql = "DELETE FROM NghiPhep WHERE MaNV = @MaNV AND MaThang = @MaThang";
                SqlCommand cmd = new SqlCommand(sql);
                cmd.Parameters.AddWithValue("@MaNV", maNV);
                cmd.Parameters.AddWithValue("@MaThang", maThang);

                bool ketQua = db.MyExecuteNonQuery(cmd, CommandType.Text, ref err);

                if (!string.IsNullOrEmpty(deleteCtChamCongErr))
                {
                    err += " " + deleteCtChamCongErr;
                }

                return ketQua;
            }
            catch (Exception ex)
            {
                err = "Lỗi khi xóa nghỉ phép: " + ex.Message;
                return false;
            }
        }
    }
}