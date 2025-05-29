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
    public class BLChucVu
    {
        DBMain db = new DBMain();

        public DataSet LayChucVu()
        {
            string sql = "SELECT * FROM ChucVu";
            return db.ExecuteQueryDataSet(sql, CommandType.Text);
        }

        public bool ThemChucVu(string maCV, string tenCV, ref string err)
        {
            string sql = $"INSERT INTO ChucVu (MaCV, TenCV) VALUES (@MaCV, @TenCV)";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@MaCV", maCV);
            cmd.Parameters.AddWithValue("@TenCV", tenCV);
            return db.MyExecuteNonQuery(cmd, CommandType.Text, ref err);
        }

        public bool CapNhatChucVu(string maCV, string tenCV, ref string err)
        {
            string sql = $"UPDATE ChucVu SET TenCV = @TenCV WHERE MaCV = @MaCV";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@MaCV", maCV);
            cmd.Parameters.AddWithValue("@TenCV", tenCV);
            return db.MyExecuteNonQuery(cmd, CommandType.Text, ref err);
        }

        public bool XoaChucVu(string maCV, ref string err)
        {
            string sql = $"DELETE FROM ChucVu WHERE MaCV = @MaCV";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@MaCV", maCV);
            return db.MyExecuteNonQuery(cmd, CommandType.Text, ref err);
        }
    }
}
