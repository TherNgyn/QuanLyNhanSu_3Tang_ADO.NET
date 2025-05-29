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
    class BLHopDong
    {
        DBMain db = null;
        public BLHopDong()
        {
            db = new DBMain();
        }
        public DataSet LayHopDong()
        {
            return db.ExecuteQueryDataSet("SELECT * FROM HopDong", CommandType.Text);
        }
        public DataSet TimKiemHopDong(string MaNV)
        {
            return db.ExecuteQueryDataSet("SELECT * FROM HopDong WHERE MaNV='" + 
                    MaNV+ "'", CommandType.Text);
        }
        public DataSet XemChiTietHopDong(string MaNV)
        {
            string sql = "SELECT nv.MaNV, hd.MaHD, hd.LuongCoBan, hd.NgayBD AS NgayBatDauHopDong, " +
              "hd.NgayKT AS NgayKetThucHopDong, pb.TenPB AS TenPhongBan, cv.TenCV AS TenChucVu " +
              "FROM NhanVien nv " +
              "JOIN HopDong hd ON nv.MaHD = hd.MaHD " +
              "JOIN ChucVu cv ON nv.MaCV = cv.MaCV " +
              "JOIN PhongBan pb ON pb.MaPB = nv.MaPB " +
              "WHERE nv.MaNV = '" + MaNV + "'";
            return db.ExecuteQueryDataSet(sql, CommandType.Text);
        }
        public bool ThemHopDonng(string MaHD, string MaNV, int LuongCoBan, DateTime NgayBD, DateTime NgayKT, ref string err)
        {
            try
            {
                string sqlString = "INSERT INTO HopDong(MaHD, MaNV, LuongCoBan, NgayBD, NgayKT) " +
                "VALUES (@MaHD,@MaNV, @LuongCoBan, @NgayBD, @NgayKT)";
                SqlCommand cmd = new SqlCommand(sqlString);
                cmd.Parameters.AddWithValue("@MaHD", MaHD);
                cmd.Parameters.AddWithValue("@MaNV", MaNV);
                cmd.Parameters.AddWithValue("@LuongCoBan", LuongCoBan);
                cmd.Parameters.AddWithValue("@NgayBD", NgayBD);
                cmd.Parameters.AddWithValue("@NgayKT", NgayKT);
                return db.MyExecuteNonQuery(cmd, CommandType.Text, ref err);
            }
            catch (SqlException ex)
            {
                err = ex.Message;
                return false;
            }
        }
        public bool XoaHopDong(ref string err, string MaHD)
        {
            string sqlString = "Delete From HopDong Where MaHD=@MaHD";
            SqlCommand cmd = new SqlCommand(sqlString);
            cmd.Parameters.AddWithValue("@MaHD", MaHD);
            return db.MyExecuteNonQuery(cmd, CommandType.Text, ref err);
        }
        public bool CapNhatHopDong(string MaHD, string MaNV, int LuongCoBan, DateTime NgayBD, DateTime NgayKT, ref string err)
        {
            string sqlString = "UPDATE HopDong " +
                "SET NgayBD = @NgayBD, NgayKT = @NgayKT, LuongCoBan = @LuongCoBan " +
                "WHERE MaHD = @MaHD";
            SqlCommand cmd = new SqlCommand(sqlString);
            cmd.Parameters.AddWithValue("@MaHD", MaHD);
            cmd.Parameters.AddWithValue("@LuongCoBan", LuongCoBan);
            cmd.Parameters.AddWithValue("@NgayBD", NgayBD);
            cmd.Parameters.AddWithValue("@NgayKT", NgayKT);
            return db.MyExecuteNonQuery(cmd, CommandType.Text, ref err);
        }
        public DataSet LayHopDongSapHetHan()
        {
            string query = "SELECT * FROM HopDong " +
                "WHERE NgayKT >= GETDATE() AND DATEDIFF(day, GETDATE(), NgayKT) <= 30;";
            return db.ExecuteQueryDataSet(query, CommandType.Text);
        }

    }
}
