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
    internal class BLPhongBan
    {
        DBMain db = null;

        public BLPhongBan()
        {
            db = new DBMain();
        }

        
        private bool KiemTraTruongPhongHopLe(string maPB, string maTrP, ref string err)
        {
            try
            {
                if (!string.IsNullOrEmpty(maTrP))
                {
                    string sqlKiemTraNV = "SELECT COUNT(*) FROM NhanVien WHERE MaNV = @MaNV";
                    SqlCommand cmdKiemTraNV = new SqlCommand(sqlKiemTraNV);
                    cmdKiemTraNV.Parameters.AddWithValue("@MaNV", maTrP);

                    DataSet dsKiemTraNV = db.ExecuteQueryDataSetWithCmd(cmdKiemTraNV, CommandType.Text);
                    if (Convert.ToInt32(dsKiemTraNV.Tables[0].Rows[0][0]) == 0)
                    {
                        err = "Nhân viên được chỉ định làm trưởng phòng không tồn tại!";
                        return false;
                    }

                    // Kiểm tra xem nhân viên có phải là trưởng phòng không
                    string sqlKiemTraCV = @"
                        SELECT COUNT(*) 
                        FROM NhanVien nv 
                        JOIN ChucVu cv ON nv.MaCV = cv.MaCV 
                        WHERE nv.MaNV = @MaNV AND cv.TenCV LIKE N'Trưởng Phòng'";
                    SqlCommand cmdKiemTraCV = new SqlCommand(sqlKiemTraCV);
                    cmdKiemTraCV.Parameters.AddWithValue("@MaNV", maTrP);

                    DataSet dsKiemTraCV = db.ExecuteQueryDataSetWithCmd(cmdKiemTraCV, CommandType.Text);
                    if (Convert.ToInt32(dsKiemTraCV.Tables[0].Rows[0][0]) == 0)
                    {
                        err = "Nhân viên được chỉ định không có chức vụ Trưởng Phòng!";
                        return false;
                    }

                    // Kiểm tra xem nhân viên đã là trưởng phòng nào khác chưa
                    string sqlKiemTraDaLaTrP = @"
                        SELECT COUNT(*) 
                        FROM PhongBan 
                        WHERE MaTrP = @MaTrP AND MaPB <> @MaPB";
                    SqlCommand cmdKiemTraDaLaTrP = new SqlCommand(sqlKiemTraDaLaTrP);
                    cmdKiemTraDaLaTrP.Parameters.AddWithValue("@MaTrP", maTrP);
                    cmdKiemTraDaLaTrP.Parameters.AddWithValue("@MaPB", maPB);

                    DataSet dsKiemTraDaLaTrP = db.ExecuteQueryDataSetWithCmd(cmdKiemTraDaLaTrP, CommandType.Text);
                    if (Convert.ToInt32(dsKiemTraDaLaTrP.Tables[0].Rows[0][0]) > 0)
                    {
                        err = "Người này đã là trưởng phòng của phòng ban khác!";
                        return false;
                    }

                    // Kiểm tra xem phòng ban đã có trưởng phòng khác chưa
                    string sqlKiemTraPBCoTrP = @"
                        SELECT COUNT(*) 
                        FROM NhanVien nv 
                        JOIN ChucVu cv ON nv.MaCV = cv.MaCV 
                        WHERE nv.MaPB = @MaPB AND cv.TenCV LIKE N'Trưởng Phòng' AND nv.MaNV <> @MaNV";
                    SqlCommand cmdKiemTraPBCoTrP = new SqlCommand(sqlKiemTraPBCoTrP);
                    cmdKiemTraPBCoTrP.Parameters.AddWithValue("@MaPB", maPB);
                    cmdKiemTraPBCoTrP.Parameters.AddWithValue("@MaNV", maTrP);

                    DataSet dsKiemTraPBCoTrP = db.ExecuteQueryDataSetWithCmd(cmdKiemTraPBCoTrP, CommandType.Text);
                    if (Convert.ToInt32(dsKiemTraPBCoTrP.Tables[0].Rows[0][0]) > 0)
                    {
                        err = "Phòng ban này đã có một trưởng phòng khác!";
                        return false;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                err = "Lỗi kiểm tra trưởng phòng: " + ex.Message;
                return false;
            }
        }

        
        private bool CapNhatThongTinTruongPhong(string maPB, ref string err)
        {
            try
            {
                // Kiểm tra xem phòng ban có nhân viên không
                string sqlKiemTraNV = "SELECT COUNT(*) FROM NhanVien WHERE MaPB = @MaPB";
                SqlCommand cmdKiemTraNV = new SqlCommand(sqlKiemTraNV);
                cmdKiemTraNV.Parameters.AddWithValue("@MaPB", maPB);

                DataSet dsKiemTraNV = db.ExecuteQueryDataSetWithCmd(cmdKiemTraNV, CommandType.Text);
                int soNhanVien = Convert.ToInt32(dsKiemTraNV.Tables[0].Rows[0][0]);

                if (soNhanVien == 0)
                {
                    // Nếu phòng ban không có nhân viên, đặt MaTrP thành NULL
                    string sqlUpdateNull = "UPDATE PhongBan SET MaTrP = NULL WHERE MaPB = @MaPB";
                    SqlCommand cmdUpdateNull = new SqlCommand(sqlUpdateNull);
                    cmdUpdateNull.Parameters.AddWithValue("@MaPB", maPB);

                    return db.MyExecuteNonQuery(cmdUpdateNull, CommandType.Text, ref err);
                }
                else
                {
                    // Lấy danh sách trưởng phòng trong phòng ban
                    string sqlLayTruongPhong = @"
                        SELECT TOP 1 nv.MaNV
                        FROM NhanVien nv
                        JOIN ChucVu cv ON nv.MaCV = cv.MaCV
                        WHERE nv.MaPB = @MaPB AND cv.TenCV LIKE N'Trưởng Phòng'";
                    SqlCommand cmdLayTruongPhong = new SqlCommand(sqlLayTruongPhong);
                    cmdLayTruongPhong.Parameters.AddWithValue("@MaPB", maPB);

                    DataSet dsLayTruongPhong = db.ExecuteQueryDataSetWithCmd(cmdLayTruongPhong, CommandType.Text);

                    if (dsLayTruongPhong.Tables[0].Rows.Count > 0)
                    {
                        // Nếu có trưởng phòng, cập nhật MaTrP
                        string maTrP = dsLayTruongPhong.Tables[0].Rows[0]["MaNV"].ToString();

                        string sqlUpdateTrP = "UPDATE PhongBan SET MaTrP = @MaTrP WHERE MaPB = @MaPB";
                        SqlCommand cmdUpdateTrP = new SqlCommand(sqlUpdateTrP);
                        cmdUpdateTrP.Parameters.AddWithValue("@MaTrP", maTrP);
                        cmdUpdateTrP.Parameters.AddWithValue("@MaPB", maPB);

                        return db.MyExecuteNonQuery(cmdUpdateTrP, CommandType.Text, ref err);
                    }
                    else
                    {
                        // Nếu không có trưởng phòng, đặt MaTrP thành NULL
                        string sqlUpdateNull = "UPDATE PhongBan SET MaTrP = NULL WHERE MaPB = @MaPB";
                        SqlCommand cmdUpdateNull = new SqlCommand(sqlUpdateNull);
                        cmdUpdateNull.Parameters.AddWithValue("@MaPB", maPB);

                        return db.MyExecuteNonQuery(cmdUpdateNull, CommandType.Text, ref err);
                    }
                }
            }
            catch (Exception ex)
            {
                err = "Lỗi cập nhật thông tin trưởng phòng: " + ex.Message;
                return false;
            }
        }

        public DataSet LayPhongBanTheoTrP(String MaTrP)
        {
            return db.ExecuteQueryDataSet("SELECT PB.MaPB,TenPB,PB.SDT,MaTrP,Ho,Ten " +
                "FROM PhongBan PB LEFT JOIN NhanVien NV ON NV.MaNV = PB.MaTrP " +
                "WHERE MaTrP ='" + MaTrP + "'", CommandType.Text);
        }

        public DataSet LayPhongBan()
        {
            return db.ExecuteQueryDataSet("SELECT PB.MaPB,TenPB,PB.SDT,MaTrP,Ho,Ten FROM PhongBan PB LEFT JOIN NhanVien NV ON NV.MaNV = PB.MaTrP", CommandType.Text);
        }

        public DataSet TongSoLuongNhanVienTheoPhongBan()
        {
            return db.ExecuteQueryDataSet("SELECT TenPB, COUNT(*) " +
                "FROM PhongBan PB INNER JOIN NhanVien NV ON NV.MaPB = PB.MaPB " +
                "Group By TenPB", CommandType.Text);
        }

        public DataSet TongSoLuongNhanVienCua1PhongBan(String MaTrP)
        {
            return db.ExecuteQueryDataSet("SELECT TenPB, COUNT(*) " +
                "FROM PhongBan PB INNER JOIN NhanVien NV ON NV.MaPB = PB.MaPB and PB.MaTrP = '" + MaTrP + "'" +
                "Group By TenPB", CommandType.Text);
        }

        public bool CapNhatPhongBan(String MaPB, String TenPB, String SDT, String MaTrP, ref string err)
        {
            
            if (!KiemTraTruongPhongHopLe(MaPB, MaTrP, ref err))
            {
                return false;
            }

            string sqlString = "UPDATE PhongBan " +
                "SET TenPB = @TenPB, SDT = @SDT, MaTrP = @MaTrP " +
                "WHERE MaPB = @MaPB";
            SqlCommand cmd = new SqlCommand(sqlString);
            cmd.Parameters.AddWithValue("@MaPB", MaPB);
            cmd.Parameters.AddWithValue("@TenPB", TenPB);
            cmd.Parameters.AddWithValue("@SDT", SDT);

            if (string.IsNullOrEmpty(MaTrP))
                cmd.Parameters.AddWithValue("@MaTrP", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@MaTrP", MaTrP);

            return db.MyExecuteNonQuery(cmd, CommandType.Text, ref err);
        }

        public bool ThemPhongBan(String MaPB, String TenPB, String SDT, String MaTrP, ref string err)
        {
            MessageBox.Show(MaTrP);
            if (!KiemTraTruongPhongHopLe(MaPB, MaTrP, ref err))
            {
                return false;
            }

            string sqlString = "INSERT Into PhongBan(MaPB, TenPB, SDT, MaTrP) VALUES (@MaPB, @TenPB, @SDT, @MaTrP)";
            SqlCommand cmd = new SqlCommand(sqlString);
            cmd.Parameters.AddWithValue("@MaPB", MaPB);
            cmd.Parameters.AddWithValue("@TenPB", TenPB);
            cmd.Parameters.AddWithValue("@SDT", SDT);

            if (string.IsNullOrEmpty(MaTrP))
                cmd.Parameters.AddWithValue("@MaTrP", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@MaTrP", MaTrP);

            return db.MyExecuteNonQuery(cmd, CommandType.Text, ref err);
        }

        public bool XoaPhongBan(ref string err, string MaPB)
        {
            string sqlString = "Delete From PhongBan Where MaPB=@MaPB";
            SqlCommand cmd = new SqlCommand(sqlString);
            cmd.Parameters.AddWithValue("@MaPB", MaPB);
            return db.MyExecuteNonQuery(cmd, CommandType.Text, ref err);
        }

       
        public bool DongBoTruongPhongSauKhiCapNhatNhanVien(string maPB, ref string err)
        {
            return CapNhatThongTinTruongPhong(maPB, ref err);
        }
    }
}