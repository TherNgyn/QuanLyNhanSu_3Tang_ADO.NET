using QuanLyNhanSu_3Tang_ADO.DB_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

<<<<<<< HEAD
namespace QuanLyNhanSu_3Tang_ADO.BS_Layer
{
    class BLBaoHiem
    {
        DBMain db = null;
        public BLBaoHiem()
        {
            db = new DBMain();
        }
        public DataSet LayBaoHiem()
        {
            return db.ExecuteQueryDataSet("SELECT nv.MaNV, nv.Ho, nv.Ten, bh.TenBH, ctbh.MaBH, ctbh.NgayBD, ctbh.NgayKT " +
                "FROM NhanVien nv " +
                "JOIN ctBaoHiem ctbh ON nv.MaNV = ctbh.MaNV " +
                "JOIN BaoHiem bh ON ctbh.MaLoai = bh.MaLoai", CommandType.Text);
        }
        public DataSet LayMaLoaiBaoHiem()
        {
            return db.ExecuteQueryDataSet("SELECT * FROM BaoHiem", CommandType.Text);
        }
        public DataSet TimKiemBaoHiem(string MaNV)
        {
            return db.ExecuteQueryDataSet("SELECT nv.MaNV, nv.Ho, nv.Ten, bh.TenBH, ctbh.MaBH, ctbh.NgayBD, ctbh.NgayKT " +
                "FROM NhanVien nv " +
                "JOIN ctBaoHiem ctbh ON nv.MaNV = ctbh.MaNV " +
                "JOIN BaoHiem bh ON ctbh.MaLoai = bh.MaLoai " +
                "WHERE MaNV='" + MaNV + "'", CommandType.Text);
        }
        
        public string LayMaLoaiTuTenLoai(string tenLoai, ref string err)
        {
            try
            {
                string sqlString = "SELECT MaLoai FROM BaoHiem WHERE TenBH = N'" + tenLoai + "'";
                DataSet ds = db.ExecuteQueryDataSet(sqlString, CommandType.Text);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0]["MaLoai"].ToString();
                }
                else
                {
                    err = "Không tìm thấy loại bảo hiểm có tên: " + tenLoai;
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return string.Empty;
            }
        }
  
        public bool ThemBaoHiem(string MaNV, string MaBH, string TenLoaiBH, DateTime NgayBD, DateTime NgayKT, ref string err)
        {
            try
            {
                string maLoai = LayMaLoaiTuTenLoai(TenLoaiBH, ref err);

                if (string.IsNullOrEmpty(maLoai))
                {
                    return false; 
                }
                string sqlString = "INSERT INTO ctBaoHiem(MaNV, MaBH, MaLoai, NgayBD, NgayKT) " +
                    "VALUES(@MaNV, @MaBH, @MaLoai, @NgayBD, @NgayKT)";
                SqlCommand cmd = new SqlCommand(sqlString);
                cmd.Parameters.AddWithValue("@MaBH", MaBH);
                cmd.Parameters.AddWithValue("@MaNV", MaNV);
                cmd.Parameters.AddWithValue("@MaLoai", maLoai);
                cmd.Parameters.AddWithValue("@NgayBD", NgayBD);
                cmd.Parameters.AddWithValue("@NgayKT", NgayKT);
=======

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
>>>>>>> e6accea066e41cff7f07a55b7caebfc4a58722d3
                return db.MyExecuteNonQuery(cmd, CommandType.Text, ref err);
            }
            catch (SqlException ex)
            {
                err = ex.Message;
                return false;
            }
        }
<<<<<<< HEAD
        public bool XoaBaoHiem(ref string err, string MaHD)
        {
            string sqlString = "Delete From ctBaoHiem Where MaBH=@MaBH";
            SqlCommand cmd = new SqlCommand(sqlString);
            cmd.Parameters.AddWithValue("@MaBH", MaHD);
            return db.MyExecuteNonQuery(cmd, CommandType.Text, ref err);
        }
        public bool CapNhatBaoHiem(string MaNV, string MaBH, string TenLoai, DateTime NgayBD, DateTime NgayKT, ref string err)
        {
            string maLoai = LayMaLoaiTuTenLoai(TenLoai, ref err);

            if (string.IsNullOrEmpty(maLoai))
            {
                return false;
            }
            string sqlString = "UPDATE ctBaoHiem " +
                "SET MaLoai=@LoaiBH, NgayBD=@NgayBD, " +
                "NgayKT=@NgayKT " +
                "WHERE MaBH=@MaBH;";
            SqlCommand cmd = new SqlCommand(sqlString);
            cmd.Parameters.AddWithValue("@MaBH", MaBH);
            cmd.Parameters.AddWithValue("@LoaiBH", maLoai);
            cmd.Parameters.AddWithValue("@NgayBD", NgayBD);
            cmd.Parameters.AddWithValue("@NgayKT", NgayKT);
            return db.MyExecuteNonQuery(cmd, CommandType.Text, ref err);
        }

=======

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
>>>>>>> e6accea066e41cff7f07a55b7caebfc4a58722d3
    }
}
