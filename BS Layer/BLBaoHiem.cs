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
    public class BLBaoHiem
    {
        DBMain db = new DBMain();

        public DataSet LayBaoHiem()
        {
            string sql = @"
                SELECT cb.MaBH, cb.MaNV, nv.Ho + ' ' + nv.Ten AS TenNV, bh.TenBH, cb.NgayBD, cb.NgayKT
                FROM ctBaoHiem cb
                JOIN NhanVien nv ON cb.MaNV = nv.MaNV
                JOIN BaoHiem bh ON cb.MaLoai = bh.MaLoai";
            return db.ExecuteQueryDataSet(sql, CommandType.Text);
        }

        public DataTable LayLoaiBaoHiem()
        {
            string sql = "SELECT * FROM BaoHiem";
            return db.ExecuteQueryDataSet(sql, CommandType.Text).Tables[0];
        }


        public bool ThemBaoHiem(string maNV, string maBH, string maLoai, DateTime ngayBD, DateTime ngayKT, ref string err)
        {
            try
            {
                string sql = "INSERT INTO ctBaoHiem (MaNV, MaBH, MaLoai, NgayBD, NgayKT) " +
                             "VALUES (@MaNV, @MaBH, @MaLoai, @NgayBD, @NgayKT)";
                SqlCommand cmd = new SqlCommand(sql);
                cmd.Parameters.AddWithValue("@MaNV", maNV);
                cmd.Parameters.AddWithValue("@MaBH", maBH);
                cmd.Parameters.AddWithValue("@MaLoai", maLoai);
                cmd.Parameters.AddWithValue("@NgayBD", ngayBD);
                cmd.Parameters.AddWithValue("@NgayKT", ngayKT);
                return db.MyExecuteNonQuery(cmd, CommandType.Text, ref err);
            }
            catch (SqlException ex)
            {
                err = ex.Message;
                return false;
            }
        }

        public bool XoaBaoHiem(string maBH, ref string err)
        {
            string sql = "DELETE FROM ctBaoHiem WHERE MaBH = @MaBH";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@MaBH", maBH);
            return db.MyExecuteNonQuery(cmd, CommandType.Text, ref err);
        }

        public bool CapNhatBaoHiem(string maNV, string maBH, string maLoai, DateTime ngayBD, DateTime ngayKT, ref string err)
        {
            string sql = "UPDATE ctBaoHiem SET MaNV = @MaNV, MaLoai = @MaLoai, NgayBD = @NgayBD, NgayKT = @NgayKT WHERE MaBH = @MaBH";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@MaNV", maNV);
            cmd.Parameters.AddWithValue("@MaBH", maBH);
            cmd.Parameters.AddWithValue("@MaLoai", maLoai);
            cmd.Parameters.AddWithValue("@NgayBD", ngayBD);
            cmd.Parameters.AddWithValue("@NgayKT", ngayKT);
            return db.MyExecuteNonQuery(cmd, CommandType.Text, ref err);
        }
    }
}
