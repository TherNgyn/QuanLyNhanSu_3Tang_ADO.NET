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
    public class BLThongBao
    {
        DBMain db = new DBMain();

        public DataSet LayThongBao()
        {
            string sql = @"SELECT tb.Id, tb.TieuDe, tb.NoiDung, tb.NgayGui, tb.MaPB, pb.TenPB
                            FROM ThongBao tb
                            JOIN PhongBan pb ON tb.MaPB = pb.MaPB";
            return db.ExecuteQueryDataSet(sql, CommandType.Text);
        }

        public DataTable LayDanhSachPhongBan()
        {
            string sql = "SELECT * FROM PhongBan";
            return db.ExecuteQueryDataSet(sql, CommandType.Text).Tables[0];
        }

        public bool ThemThongBao(string tieuDe, string noiDung, string maPB, DateTime ngayGui, ref string err)
        {
            string sql = "INSERT INTO ThongBao (TieuDe, NoiDung, MaPB, NgayGui) VALUES (@TieuDe, @NoiDung, @MaPB, @NgayGui)";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@TieuDe", tieuDe);
            cmd.Parameters.AddWithValue("@NoiDung", noiDung);
            cmd.Parameters.AddWithValue("@MaPB", maPB);
            cmd.Parameters.AddWithValue("@NgayGui", ngayGui);
            return db.MyExecuteNonQuery(cmd, CommandType.Text, ref err);
        }

        public bool CapNhatThongBao(int id, string tieuDe, string noiDung, string maPB, DateTime ngayGui, ref string err)
        {
            string sql = "UPDATE ThongBao SET TieuDe=@TieuDe, NoiDung=@NoiDung, MaPB=@MaPB, NgayGui=@NgayGui WHERE Id=@Id";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@TieuDe", tieuDe);
            cmd.Parameters.AddWithValue("@NoiDung", noiDung);
            cmd.Parameters.AddWithValue("@MaPB", maPB);
            cmd.Parameters.AddWithValue("@NgayGui", ngayGui);
            return db.MyExecuteNonQuery(cmd, CommandType.Text, ref err);
        }

        public bool XoaThongBao(int id, ref string err)
        {
            string sql = "DELETE FROM ThongBao WHERE Id=@Id";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@Id", id);
            return db.MyExecuteNonQuery(cmd, CommandType.Text, ref err);
        }

        public DataTable LayThongBaoChoNV(string maNV)
        {
            string maPB = "";
            using (var conn = new SqlConnection(DBMain.connectString))
            {
                string sql1 = "SELECT MaPB FROM NhanVien WHERE MaNV = @MaNV";
                using (var cmd = new SqlCommand(sql1, conn))
                {
                    cmd.Parameters.AddWithValue("@MaNV", maNV);
                    conn.Open();
                    var result = cmd.ExecuteScalar();
                    if (result != null)
                        maPB = result.ToString();
                }
            }

            if (string.IsNullOrEmpty(maPB))
                return null;

            string sql2 = @"SELECT TieuDe AS [Tiêu đề thông báo], NoiDung AS [Nội dung thông báo], 
                        CONVERT(varchar, NgayGui, 103) AS [Ngày nhận]
                        FROM ThongBao WHERE MaPB = @MaPB ORDER BY NgayGui DESC";

            using (var conn = new SqlConnection(DBMain.connectString))
            using (var da = new SqlDataAdapter(sql2, conn))
            {
                da.SelectCommand.Parameters.AddWithValue("@MaPB", maPB);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}

