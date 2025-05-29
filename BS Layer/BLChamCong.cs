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
    class BLChamCong
    {
        DBMain db = null;
        public BLChamCong()
        {
            db = new DBMain();
        }
        public DataSet LayDSChamCong(string MaNV)
        {
            string sql = "SELECT ct.NgayChamCong, thg.MoTa AS Thang, " +
                "cong.MoTa AS MoTa, " +
                "cong.HeSo " +
                "FROM ctChamCong ct JOIN ChamCong cong ON cong.MaCC = ct.MaCC " +
                "JOIN Thang thg ON thg.MaThang = ct.MaThang " +
                "WHERE ct.MaNV = '"+ MaNV +"'";

            return db.ExecuteQueryDataSet(sql, CommandType.Text);
        }
        /*public bool ChamCong (string MaNV, string MaCC, ref string err)
        {
         
            string sql = "INSERT INTO ctChamCong (MaNV, MaCC, MaThang, NgayChamCong) " +
                "VALUES(@MaNV, @MaCC, @MaThang, @NgayChamCong)";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@MaNV", MaNV);
            cmd.Parameters.AddWithValue("@MaCC", MaCC);
            cmd.Parameters.AddWithValue("@MaThang", );
            cmd.Parameters.AddWithValue("@MNgayChamCong");

            return db.MyExecuteNonQuery(cmd, CommandType.Text, ref err);
        }*/
    }
}
