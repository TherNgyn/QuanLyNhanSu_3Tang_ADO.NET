using QuanLyNhanSu_3Tang_ADO.DB_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanSu_3Tang_ADO.BS_Layer
{
    class BLThuongPhat
    {
        DBMain db = null;
        public BLThuongPhat()
        {
            db = new DBMain();
        }

        public DataSet LayThuongPhat()
        {
            return db.ExecuteQueryDataSet("SELECT * FROM ThuongPhat", CommandType.Text);
        }

        public DataSet TimKiemThuongPhat(string MaThuongPhat)
        {
            return db.ExecuteQueryDataSet("SELECT * FROM ThuongPhat WHERE MaThuongPhat='" +
                    MaThuongPhat + "'", CommandType.Text);
        }

        public DataSet LayThuongPhatTheoLoai(string Loai)
        {
            return db.ExecuteQueryDataSet("SELECT * FROM ThuongPhat WHERE Loai='" +
                    Loai + "'", CommandType.Text);
        }

        public DataSet LayChiTietThuongPhat()
        {
            return db.ExecuteQueryDataSet("SELECT * FROM ctThuongPhat", CommandType.Text);
        }

        public DataSet LocThuongPhatNhanVien(string MaNV, string Loai)
        {
            string sql = "SELECT " +
            "nv.MaNV AS MaNhanVien, " +
            "nv.Ho AS Ho, " +
            "nv.Ten AS Ten, " +
            "tp.Loai AS Loai, " +
            "tp.LyDo AS LyDo, " +
            "tp.SoTien AS TienThuongPhat, " +
            "cttp.MaThang AS MaThang, " +
            "cttp.NgayThuongPhat AS NgayThuongPhat, " +
            "cv.TenCV AS TenChucVu, " +
            "pb.TenPB AS TenPhongBan " +
            "FROM ctThuongPhat cttp " +
            "JOIN ThuongPhat tp ON cttp.MaThuongPhat = tp.MaThuongPhat " +
            "JOIN NhanVien nv ON cttp.MaNV = nv.MaNV " +
            "LEFT JOIN ChucVu cv ON nv.MaCV = cv.MaCV " +
            "LEFT JOIN PhongBan pb ON nv.MaPB = pb.MaPB " +
            "WHERE tp.Loai = @Loai AND nv.MaNV = @MaNV";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@MaNV", MaNV);
            cmd.Parameters.AddWithValue("@Loai", Loai);
            return db.ExecuteQueryDataSetWithCmd(cmd, CommandType.Text);
        }

        public bool ThemThuongPhat(string MaThuongPhat, string Loai, int SoTien, string LyDo, ref string err)
        {
            try
            {
                string sql = "INSERT INTO ThuongPhat(MaThuongPhat, Loai, SoTien, LyDo) " +
                    "VALUES (@MaThuongPhat, @Loai, @SoTien, @LyDo);";
                SqlCommand cmd = new SqlCommand(sql);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@MaThuongPhat", MaThuongPhat);
                cmd.Parameters.AddWithValue("@Loai", Loai);
                cmd.Parameters.AddWithValue("@SoTien", SoTien);
                cmd.Parameters.AddWithValue("@LyDo", LyDo);
                return db.MyExecuteNonQuery(cmd, CommandType.Text, ref err);
            }
            catch (SqlException ex)
            {
                err = ex.Message;
                return false;
            }
        }

        public bool ThemChiTietThuongPhat(string MaNV, string MaThuongPhat, string MaThang, int NgayThuongPhat, ref string err)
        {
            try
            {
                string sql = "INSERT INTO ctThuongPhat(MaNV, MaThuongPhat, MaThang, NgayThuongPhat) " +
                    "VALUES (@MaNV, @MaThuongPhat, @MaThang, @NgayThuongPhat)";
                SqlCommand cmd = new SqlCommand(sql);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@MaNV", MaNV);
                cmd.Parameters.AddWithValue("@MaThuongPhat", MaThuongPhat);
                cmd.Parameters.AddWithValue("@MaThang", MaThang);
                cmd.Parameters.AddWithValue("@NgayThuongPhat", NgayThuongPhat);
                return db.MyExecuteNonQuery(cmd, CommandType.Text, ref err);
            }
            catch (SqlException ex)
            {
                err = ex.Message;
                return false;
            }
        }

        public bool CapNhatThuongPhat(string MaThuongPhat, string Loai, int SoTien, string LyDo, ref string err)
        {
            try
            {
                string sql = "UPDATE ThuongPhat " +
                    "SET MaThuongPhat = @MaThuongPhat, Loai = @Loai, " +
                    "SoTien = @SoTien, LyDo = @LyDo " +
                    "WHERE MaThuongPhat = @MaThuongPhat";
                SqlCommand cmd = new SqlCommand(sql);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@MaThuongPhat", MaThuongPhat);
                cmd.Parameters.AddWithValue("@Loai", Loai);
                cmd.Parameters.AddWithValue("@SoTien", SoTien);
                cmd.Parameters.AddWithValue("@LyDo", LyDo);
                return db.MyExecuteNonQuery(cmd, CommandType.Text, ref err);
            }
            catch (SqlException ex)
            {
                err = ex.Message;
                return false;
            }
        }

        public bool CapNhatNgayThangThuongPhat(string MaNV, string MaThuongPhat, string MaThang, int NgayThuongPhat, ref string err)
        {
            try
            {
                string sql = "UPDATE ctThuongPhat " +
                    "SET MaThang = @MaThang, NgayThuongPhat = @NgayThuongPhat " +
                    "WHERE MaThuongPhat = @MaThuongPhat AND MaNV = @MaNV";
                SqlCommand cmd = new SqlCommand(sql);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@MaNV", MaNV);
                cmd.Parameters.AddWithValue("@MaThuongPhat", MaThuongPhat);
                cmd.Parameters.AddWithValue("@MaThang", MaThang);
                cmd.Parameters.AddWithValue("@NgayThuongPhat", NgayThuongPhat);
                return db.MyExecuteNonQuery(cmd, CommandType.Text, ref err);
            }
            catch (SqlException ex)
            {
                err = ex.Message;
                return false;
            }
        }

        public bool XoaThuongPhat(ref string err, string MaThuongPhat)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM ThuongPhat WHERE MaThuongPhat = @MaThuongPhat;");
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@MaThuongPhat", MaThuongPhat);
                return db.MyExecuteNonQuery(cmd, CommandType.Text, ref err);
            }
            catch (SqlException ex)
            {
                err = ex.Message;
                return false;
            }
        }

        public bool XoaChiTietThuongPhat(string MaNV, int NgayThuongPhat, string MaTP, string MaThang, ref string err)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM ctThuongPhat " +
                    "WHERE MaNV=@MaNV and NgayThuongPhat = @NgayThuongPhat and " +
                    "MaThuongPhat = @MaTP and MaThang = @MaThang");
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@MaNV", MaNV);
                cmd.Parameters.AddWithValue("@NgayThuongPhat", NgayThuongPhat);
                cmd.Parameters.AddWithValue("@MaTP", MaTP);
                cmd.Parameters.AddWithValue("@MaThang", MaThang);
                return db.MyExecuteNonQuery(cmd, CommandType.Text, ref err);
            }
            catch (SqlException ex)
            {
                err = ex.Message;
                return false;
            }
        }
    }
}