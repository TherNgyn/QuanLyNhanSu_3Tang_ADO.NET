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
        public DataSet TongSoLuongNhanVienCua1PhongBan(String MaPB)
        {
            return db.ExecuteQueryDataSet("SELECT TenPB, COUNT(*) " +
                "FROM PhongBan PB INNER JOIN NhanVien NV ON NV.MaPB = PB.MaPB and PB.MaPB = '" +MaPB +"'"+
                "Group By TenPB", CommandType.Text); 
        }
        public bool CapNhatPhongBan(String MaPB, String TenPB, String SDT, String MaTrP, ref string err)
        {
            string sqlString = "UPDATE PhongBan " +
                "SET TenPB = @TenPB, SDT = @SDT, MaTrP = @MaTrP " +
                "WHERE MaPB = @MaPB";
            SqlCommand cmd = new SqlCommand(sqlString);
            cmd.Parameters.AddWithValue("@MaPB", MaPB);
            cmd.Parameters.AddWithValue("@TenPB", TenPB);
            cmd.Parameters.AddWithValue("@SDT", SDT);
            cmd.Parameters.AddWithValue("@MaTrP", MaTrP);
            return db.MyExecuteNonQuery(cmd, CommandType.Text, ref err);
        }
        public bool ThemPhongBan(String MaPB, String TenPB, String SDT, String MaTrP, ref string err)
        {
            string sqlString = "INSERT Into PhongBan(MaPB, TenPB, SDT, MaTrP) VALUES (@MaPB, @TenPB, @SDT, @MaTrP)";
            SqlCommand cmd = new SqlCommand(sqlString);
            cmd.Parameters.AddWithValue("@MaPB", MaPB);
            cmd.Parameters.AddWithValue("@TenPB", TenPB);
            cmd.Parameters.AddWithValue("@SDT", SDT);
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
    }
}
