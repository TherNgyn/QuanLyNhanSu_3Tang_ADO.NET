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
        public DataSet LayTatCaMaNhanVien()
        {
            return db.ExecuteQueryDataSet("SELECT MaNV FROM NhanVien", CommandType.Text);

        }
        public DataSet LayNhanVien()
        {
            return db.ExecuteQueryDataSet("SELECT * FROM NhanVien", CommandType.Text);
        }
        public DataSet LayNhanVienPBCV()
        {
            return db.ExecuteQueryDataSet("SELECT MaNV,Ho,Ten,GioiTinh,NgaySinh,DiaChi, NV.SDT,Email,CCCD,PB.TenPB,CV.TenCV " +
                "FROM NhanVien NV " +
                "INNER JOIN PhongBan PB ON NV.MaPB = PB.MaPB " +
                "INNER JOIN ChucVu CV ON NV.MaCV = CV.MaCV", CommandType.Text);
        }
        public DataSet TimNhanVienTheoMa(String MaNV)
        {
            return db.ExecuteQueryDataSet("SELECT * FROM NhanVien WHERE MaNV Like" + "'%" + MaNV + "%'", CommandType.Text);
        }
        public DataSet LayNhanVienTheoMa(String MaNV)
        {
            return db.ExecuteQueryDataSet("SELECT * FROM NhanVien WHERE MaNV =" +"'"+ MaNV +"'", CommandType.Text);
        }
        public DataSet LayNhanVienTheoHoTen(String Ho, String Ten)
        {
            return db.ExecuteQueryDataSet("SELECT * FROM NhanVien " +
                "WHERE Ho LIKE"+"N'%"+Ho+"%'"+"OR"+"Ten LIKE" +"N'%"+Ten+"%'", CommandType.Text);
        }
        public DataSet TongNhanVienTheoGioiTinh()
        {
            return db.ExecuteQueryDataSet("SELECT GioiTinh,COUNT(*) as SoLuongNhanVien FROM NhanVien Group by GioiTinh",CommandType.Text);
        }
        public DataSet TongNhanVienTheoPhongBan()
        {
            return db.ExecuteQueryDataSet("SELECT TenPB , COUNT(*) as SoLuongNhanVien FROM NhanVien NV " +
                "INNER JOIN PhongBan PB ON NV.MaPB = PB.MaPB Group by TenPB", CommandType.Text);
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
            return db.MyExecuteNonQuery(cmd, CommandType.Text, ref err);
        }
        public bool ThemNhanVien(String MaNV, String Ho, String Ten, String GioiTinh, DateTime NgaySinh, String DiaChi, String SDT, String Email, String CCCD, ref string err)
        {
            string sqlString = "INSERT Into NhanVien(MaNV, Ho, Ten, GioiTinh, NgaySinh, DiaChi, SDT, Email, CCCD) " +
                "VALUES (@MaNV, @Ho, @Ten, @GioiTinh, @NgaySinh, @DiaChi, @SDT, @Email, @CCCD)";
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
        public bool XoaNhanVien(ref string err, string MaNV)
        {
            string sqlString = "Delete From NhanVien Where MaNV=@MaNV";
            SqlCommand cmd = new SqlCommand(sqlString);
            cmd.Parameters.AddWithValue("@MaNV", MaNV);
            return db.MyExecuteNonQuery(cmd, CommandType.Text, ref err);
        }
    }
}
