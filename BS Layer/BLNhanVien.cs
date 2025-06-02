using QuanLyNhanSu_3Tang_ADO.DB_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace QuanLyNhanSu_3Tang_ADO.BS_Layer
{
    class BLNhanVien
    {
        DBMain db = null;
        BLPhongBan blPhongBan = null;

        public BLNhanVien()
        {
            db = new DBMain();
            blPhongBan = new BLPhongBan();
        }

      
        private bool KiemTraDieuKienTruongPhong(string maNV, string maCV, string maPB, ref string err)
        {
            try
            {
                string sqlKiemTraCV = "SELECT TenCV FROM ChucVu WHERE MaCV = @MaCV";
                SqlCommand cmdKiemTraCV = new SqlCommand(sqlKiemTraCV);
                cmdKiemTraCV.Parameters.AddWithValue("@MaCV", maCV);

                DataSet dsKiemTraCV = db.ExecuteQueryDataSetWithCmd(cmdKiemTraCV, CommandType.Text);
                if (dsKiemTraCV.Tables[0].Rows.Count > 0)
                {
                    string tenCV = dsKiemTraCV.Tables[0].Rows[0]["TenCV"].ToString();

                    if (tenCV.Contains("Trưởng Phòng"))
                    {
                       
                        string sqlDemTruongPhong = @"
                            SELECT COUNT(*) 
                            FROM NhanVien nv
                            JOIN ChucVu cv ON nv.MaCV = cv.MaCV
                            WHERE nv.MaPB = @MaPB 
                              AND cv.TenCV LIKE N'Trưởng Phòng'
                              AND nv.MaNV <> @MaNV";
                        SqlCommand cmdDemTruongPhong = new SqlCommand(sqlDemTruongPhong);
                        cmdDemTruongPhong.Parameters.AddWithValue("@MaPB", maPB);
                        cmdDemTruongPhong.Parameters.AddWithValue("@MaNV", maNV);

                        DataSet dsDemTruongPhong = db.ExecuteQueryDataSetWithCmd(cmdDemTruongPhong, CommandType.Text);
                        int soTruongPhong = Convert.ToInt32(dsDemTruongPhong.Tables[0].Rows[0][0]);

                        if (soTruongPhong > 0)
                        {
                            err = "Mỗi phòng ban chỉ được có duy nhất một trưởng phòng!";
                            return false;
                        }

                       
                        string sqlKiemTraTrPKhac = "SELECT COUNT(*) FROM PhongBan WHERE MaTrP = @MaNV AND MaPB <> @MaPB";
                        SqlCommand cmdKiemTraTrPKhac = new SqlCommand(sqlKiemTraTrPKhac);
                        cmdKiemTraTrPKhac.Parameters.AddWithValue("@MaNV", maNV);
                        cmdKiemTraTrPKhac.Parameters.AddWithValue("@MaPB", maPB);

                        DataSet dsKiemTraTrPKhac = db.ExecuteQueryDataSetWithCmd(cmdKiemTraTrPKhac, CommandType.Text);
                        int laTruongPhongKhac = Convert.ToInt32(dsKiemTraTrPKhac.Tables[0].Rows[0][0]);

                        if (laTruongPhongKhac > 0)
                        {
                            err = "Nhân viên này đã là trưởng phòng của phòng ban khác!";
                            return false;
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                err = "Lỗi kiểm tra điều kiện trưởng phòng: " + ex.Message;
                return false;
            }
        }

        private bool DongBoThongTinTruongPhong(string maNV, string maPBCu, string maPBMoi, string maCVCu, string maCVMoi, ref string err)
        {
            try
            {
                bool ketQua = true;
                string dongBoErr = "";

                if (!string.IsNullOrEmpty(maPBCu) && maPBCu != maPBMoi)
                {

                    if (!blPhongBan.DongBoTruongPhongSauKhiCapNhatNhanVien(maPBCu, ref dongBoErr))
                    {
                        err += dongBoErr + " ";
                        ketQua = false;
                    }
                }

              
                if (!blPhongBan.DongBoTruongPhongSauKhiCapNhatNhanVien(maPBMoi, ref dongBoErr))
                {
                    err += dongBoErr;
                    ketQua = false;
                }

                return ketQua;
            }
            catch (Exception ex)
            {
                err = "Lỗi đồng bộ thông tin trưởng phòng: " + ex.Message;
                return false;
            }
        }

        public DataSet LayTatCaMaNhanVien()
        {
            return db.ExecuteQueryDataSet("SELECT MaNV FROM NhanVien", CommandType.Text);
        }

        public DataSet LayNhanVien()
        {
            return db.ExecuteQueryDataSet("SELECT * FROM NhanVien", CommandType.Text);
        }

        public DataSet LayNhanVien1PBCV(String MaTrP)
        {
            return db.ExecuteQueryDataSet("SELECT MaNV,Ho,Ten,GioiTinh,NgaySinh,DiaChi, NV.SDT,Email,CCCD,PB.MaPB,CV.MaCV " +
                "FROM NhanVien NV " +
                "INNER JOIN PhongBan PB ON NV.MaPB = PB.MaPB and PB.MaTrP ='" + MaTrP + "' " +
                "INNER JOIN ChucVu CV ON NV.MaCV = CV.MaCV", CommandType.Text);
        }

        public DataSet LayNhanVienPBCV()
        {
            return db.ExecuteQueryDataSet("SELECT MaNV,Ho,Ten,GioiTinh,NgaySinh,DiaChi, NV.SDT,Email,CCCD,PB.MaPB,CV.MaCV " +
                "FROM NhanVien NV " +
                "INNER JOIN PhongBan PB ON NV.MaPB = PB.MaPB " +
                "INNER JOIN ChucVu CV ON NV.MaCV = CV.MaCV", CommandType.Text);
        }

        public DataSet TimNhanVienTheoMa1PB(String MaNV, String MaTrP)
        {
            return db.ExecuteQueryDataSet("SELECT MaNV,Ho,Ten,GioiTinh,NgaySinh,DiaChi, NV.SDT,Email,CCCD,PB.MaPB,CV.MaCV " +
                "FROM NhanVien NV " +
                "INNER JOIN PhongBan PB ON NV.MaPB = PB.MaPB and PB.MaTrP ='" + MaTrP + "' " +
                "INNER JOIN ChucVu CV ON NV.MaCV = CV.MaCV " +
                "WHERE MaNV Like" + "'%" + MaNV + "%'", CommandType.Text);
        }

        public DataSet TimNhanVienTheoMa(String MaNV)
        {
            return db.ExecuteQueryDataSet("SELECT MaNV,Ho,Ten,GioiTinh,NgaySinh,DiaChi, NV.SDT,Email,CCCD,PB.MaPB,CV.MaCV " +
                "FROM NhanVien NV " +
                "INNER JOIN PhongBan PB ON NV.MaPB = PB.MaPB " +
                "INNER JOIN ChucVu CV ON NV.MaCV = CV.MaCV " +
                "WHERE MaNV Like" + "'%" + MaNV + "%'", CommandType.Text);
        }
        public DataSet TimNhanVienTheoMaTen(String MaNV)
        {
            return db.ExecuteQueryDataSet("SELECT MaNV,Ho,Ten,GioiTinh,NgaySinh,DiaChi, NV.SDT,Email,CCCD,PB.TenPB,CV.TenCV " +
                "FROM NhanVien NV " +
                "INNER JOIN PhongBan PB ON NV.MaPB = PB.MaPB " +
                "INNER JOIN ChucVu CV ON NV.MaCV = CV.MaCV " +
                "WHERE MaNV Like" + "'%" + MaNV + "%'", CommandType.Text);
        }

        public DataSet LayNhanVienTheoMa(String MaNV)
        {
            return db.ExecuteQueryDataSet("SELECT * FROM NhanVien WHERE MaNV =" + "'" + MaNV + "'", CommandType.Text);
        }

        public DataSet LayNhanVienTheoHoTen(String Ho, String Ten)
        {
            return db.ExecuteQueryDataSet("SELECT * FROM NhanVien " +
                "WHERE Ho LIKE" + "N'%" + Ho + "%'" + "OR" + "Ten LIKE" + "N'%" + Ten + "%'", CommandType.Text);
        }

        public DataSet TongNhanVienTheoGioiTinh1PB(String MaTrP)
        {
            return db.ExecuteQueryDataSet("SELECT NV.GioiTinh, COUNT(*) as SoLuongNhanVien " +
                 "FROM NhanVien NV " +
                 "INNER JOIN PhongBan PB ON NV.MaPB = PB.MaPB AND PB.MaTrP = '" + MaTrP + "' " +
                 "GROUP BY NV.GioiTinh", CommandType.Text);
        }

        public DataSet TongNhanVienTheoGioiTinh()
        {
            return db.ExecuteQueryDataSet("SELECT GioiTinh,COUNT(*) as SoLuongNhanVien FROM NhanVien Group by GioiTinh", CommandType.Text);
        }

        public DataSet TongNhanVienTheoPhongBan1PB(String MaTrP)
        {
            return db.ExecuteQueryDataSet("SELECT TenPB , COUNT(*) as SoLuongNhanVien FROM NhanVien NV " +
                "INNER JOIN PhongBan PB ON NV.MaPB = PB.MaPB and PB.MaTrP ='" + MaTrP + "' " +
                "Group by TenPB", CommandType.Text);
        }

        public DataSet TongNhanVienTheoPhongBan()
        {
            return db.ExecuteQueryDataSet("SELECT TenPB , COUNT(*) as SoLuongNhanVien FROM NhanVien NV " +
                "INNER JOIN PhongBan PB ON NV.MaPB = PB.MaPB Group by TenPB", CommandType.Text);
        }

        public bool CapNhatNhanVienCV(String MaNV, String Ho, String Ten, String GioiTinh, DateTime NgaySinh, String DiaChi, String SDT, String Email, String CCCD, ref string err)
        {
            try
            {
                string sqlString = "UPDATE NhanVien " +
                    "SET Ho = @Ho, Ten = @Ten, GioiTinh = @GioiTinh, NgaySinh = @NgaySinh, DiaChi = @DiaChi, SDT = @SDT, Email = @Email, CCCD = @CCCD " +
                    "WHERE MaNV = @MaNV";
                SqlCommand cmd = new SqlCommand(sqlString);
                cmd.Parameters.AddWithValue("@MaNV", MaNV);
                cmd.Parameters.AddWithValue("@Ho", Ho);
                cmd.Parameters.AddWithValue("@Ten", Ten);
                cmd.Parameters.AddWithValue("@GioiTinh", GioiTinh);
                cmd.Parameters.AddWithValue("@NgaySinh", NgaySinh);
                cmd.Parameters.AddWithValue("@DiaChi", DiaChi);
                cmd.Parameters.AddWithValue("@SDT", SDT);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@CCCD", CCCD);

                return db.MyExecuteNonQuery(cmd, CommandType.Text, ref err);
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }

        public bool CapNhatNhanVien(String MaNV, String Ho, String Ten, String GioiTinh, DateTime NgaySinh, String DiaChi, String SDT, String Email, String CCCD, String MaPB, String MaCV, ref string err)
        {

            try
            {
               
                string sqlLayThongTinCu = "SELECT MaPB, MaCV FROM NhanVien WHERE MaNV = @MaNV";
                SqlCommand cmdLayThongTinCu = new SqlCommand(sqlLayThongTinCu);
                cmdLayThongTinCu.Parameters.AddWithValue("@MaNV", MaNV);

                DataSet dsThongTinCu = db.ExecuteQueryDataSetWithCmd(cmdLayThongTinCu, CommandType.Text);
                string maPBCu = string.Empty;
                string maCVCu = string.Empty;

                if (dsThongTinCu.Tables[0].Rows.Count > 0)
                {
                    maPBCu = dsThongTinCu.Tables[0].Rows[0]["MaPB"].ToString();
                    maCVCu = dsThongTinCu.Tables[0].Rows[0]["MaCV"].ToString();
                }

                // Kiểm tra điều kiện trưởng phòng nếu nhân viên được thăng chức thành trưởng phòng
                if (!KiemTraDieuKienTruongPhong(MaNV, MaCV, MaPB, ref err))
                {
                    return false;
                }
                MessageBox.Show(MaCV);
               
                string sqlString = "UPDATE NhanVien " +
                    "SET Ho = @Ho, Ten = @Ten, GioiTinh = @GioiTinh, NgaySinh = @NgaySinh, DiaChi = @DiaChi, SDT = @SDT, Email = @Email, CCCD = @CCCD, MaPB = @MaPB, MaCV = @MaCV " +
                    "WHERE MaNV = @MaNV";
                SqlCommand cmd = new SqlCommand(sqlString);
                cmd.Parameters.AddWithValue("@MaNV", MaNV);
                cmd.Parameters.AddWithValue("@Ho", Ho);
                cmd.Parameters.AddWithValue("@Ten", Ten);
                cmd.Parameters.AddWithValue("@GioiTinh", GioiTinh);
                cmd.Parameters.AddWithValue("@NgaySinh", NgaySinh);
                cmd.Parameters.AddWithValue("@DiaChi", DiaChi);
                cmd.Parameters.AddWithValue("@SDT", SDT);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@CCCD", CCCD);
                cmd.Parameters.AddWithValue("@MaPB", MaPB);
                cmd.Parameters.AddWithValue("@MaCV", MaCV);

                bool ketQua = db.MyExecuteNonQuery(cmd, CommandType.Text, ref err);

                // Nếu cập nhật thành công và có thay đổi phòng ban hoặc chức vụ, đồng bộ thông tin trưởng phòng
                if (ketQua && (maPBCu != MaPB || maCVCu != MaCV))
                {
                    string dongBoErr = "";
                    DongBoThongTinTruongPhong(MaNV, maPBCu, MaPB, maCVCu, MaCV, ref dongBoErr);

                    if (!string.IsNullOrEmpty(dongBoErr))
                    {
                        err += " " + dongBoErr;
                    }
                }

                return ketQua;
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }

        public bool ThemNhanVien(String MaNV, String Ho, String Ten, String GioiTinh, DateTime NgaySinh, String DiaChi, String SDT, String Email, String CCCD, String MaPB, String MaCV, ref string err)
        {
            try
            {
               
                if (!KiemTraDieuKienTruongPhong(MaNV, MaCV, MaPB, ref err))
                {
                    return false;
                }

              
                string sqlString = "INSERT Into NhanVien(MaNV, Ho, Ten, GioiTinh, NgaySinh, DiaChi, SDT, Email, CCCD, MaPB, MaCV) " +
                    "VALUES (@MaNV, @Ho, @Ten, @GioiTinh, @NgaySinh, @DiaChi, @SDT, @Email, @CCCD, @MaPB, @MaCV)";
                SqlCommand cmd = new SqlCommand(sqlString);
                cmd.Parameters.AddWithValue("@MaNV", MaNV);
                cmd.Parameters.AddWithValue("@Ho", Ho);
                cmd.Parameters.AddWithValue("@Ten", Ten);
                cmd.Parameters.AddWithValue("@GioiTinh", GioiTinh);
                cmd.Parameters.AddWithValue("@NgaySinh", NgaySinh);
                cmd.Parameters.AddWithValue("@DiaChi", DiaChi);
                cmd.Parameters.AddWithValue("@SDT", SDT);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@CCCD", CCCD);
                cmd.Parameters.AddWithValue("@MaPB", MaPB);
                cmd.Parameters.AddWithValue("@MaCV", MaCV);

                bool ketQua = db.MyExecuteNonQuery(cmd, CommandType.Text, ref err);

               
                if (ketQua)
                {
                    
                    string dongBoErr = "";
                    DongBoThongTinTruongPhong(MaNV, "", MaPB, "", MaCV, ref dongBoErr);

                    if (!string.IsNullOrEmpty(dongBoErr))
                    {
                        err += " " + dongBoErr;
                    }
                }

                return ketQua;
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }

        public bool XoaNhanVien(ref string err, string MaNV)
        {
            try
            {
               
                string sqlLayThongTin = "SELECT MaPB, MaCV FROM NhanVien WHERE MaNV = @MaNV";
                SqlCommand cmdLayThongTin = new SqlCommand(sqlLayThongTin);
                cmdLayThongTin.Parameters.AddWithValue("@MaNV", MaNV);

                DataSet dsThongTin = db.ExecuteQueryDataSetWithCmd(cmdLayThongTin, CommandType.Text);
                string maPB = string.Empty;
                string maCV = string.Empty;

                if (dsThongTin.Tables[0].Rows.Count > 0)
                {
                    maPB = dsThongTin.Tables[0].Rows[0]["MaPB"].ToString();
                    maCV = dsThongTin.Tables[0].Rows[0]["MaCV"].ToString();
                }
                try
                {
                    BLTaiKhoan blTaiKhoan = new BLTaiKhoan();
                    string taiKhoanErr = "";
                    blTaiKhoan.XoaTaiKhoan(ref taiKhoanErr, MaNV);
                }
                catch (Exception) { }
                string sqlString = "Delete From NhanVien Where MaNV=@MaNV";
                SqlCommand cmd = new SqlCommand(sqlString);
                cmd.Parameters.AddWithValue("@MaNV", MaNV);

                bool ketQua = db.MyExecuteNonQuery(cmd, CommandType.Text, ref err);

               
                if (ketQua && !string.IsNullOrEmpty(maPB))
                {
                    string dongBoErr = "";
                    blPhongBan.DongBoTruongPhongSauKhiCapNhatNhanVien(maPB, ref dongBoErr);

                    if (!string.IsNullOrEmpty(dongBoErr))
                    {
                        err += " " + dongBoErr;
                    }
                }

                return ketQua;
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }
    }
}