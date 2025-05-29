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

        public bool ThemNghiPhep(string maNV, string maThang, int ngayNghi, string ghiChu, ref string err)
        {
            string sql = "INSERT INTO NghiPhep (MaNV, MaThang, NgayNghiPhep, GhiChu) VALUES (@MaNV, @MaThang, @Ngay, @GhiChu)";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@MaNV", maNV);
            cmd.Parameters.AddWithValue("@MaThang", maThang);
            cmd.Parameters.AddWithValue("@Ngay", ngayNghi);
            cmd.Parameters.AddWithValue("@GhiChu", ghiChu);
            return db.MyExecuteNonQuery(cmd, CommandType.Text, ref err);
        }

        public bool CapNhatNghiPhep(string maNV, string maThang, int ngayNghi, string ghiChu, ref string err)
        {
            string sql = "UPDATE NghiPhep SET NgayNghiPhep = @Ngay, GhiChu = @GhiChu WHERE MaNV = @MaNV AND MaThang = @MaThang";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@Ngay", ngayNghi);
            cmd.Parameters.AddWithValue("@GhiChu", ghiChu);
            cmd.Parameters.AddWithValue("@MaNV", maNV);
            cmd.Parameters.AddWithValue("@MaThang", maThang);
            return db.MyExecuteNonQuery(cmd, CommandType.Text, ref err);
        }

        public bool XoaNghiPhep(string maNV, string maThang, ref string err)
        {
            string sql = "DELETE FROM NghiPhep WHERE MaNV = @MaNV AND MaThang = @MaThang";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@MaNV", maNV);
            cmd.Parameters.AddWithValue("@MaThang", maThang);
            return db.MyExecuteNonQuery(cmd, CommandType.Text, ref err);
        }
    }
}
