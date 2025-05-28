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
        public BLNhanVien()
        {
            db = new DBMain();
        }
        public DataSet LayNhanVien()
        {
            return db.ExecuteQueryDataSet("SELECT * FROM NhanVien", CommandType.Text);
        }
        public DataSet LayNhanVienTheoMa(String MaNV)
        {
            return db.ExecuteQueryDataSet("SELECT * FROM NhanVien WHERE MaNV =" +"'"+ MaNV +"'", CommandType.Text);
        }
        public bool CapNhatNhanVien(String MaNV,String Ho, String Ten, String GioiTinh, DateTime NgaySinh, String DiaChi, String SDT, String Email, String CCCD, ref string err)
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
            MessageBox.Show("Đã Sửa");
            return db.MyExecuteNonQuery(cmd, CommandType.Text, ref err);
        }
    }
}
