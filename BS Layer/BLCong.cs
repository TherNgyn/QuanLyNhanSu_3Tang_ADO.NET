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
    class BLCong
    {
        DBMain db = null;
        BLThang blThang = new BLThang();
        public BLCong()
        {
            db = new DBMain();
        }
        public DataSet LayDSChamCongByNV(string MaNV)
        {
            string sql = "SELECT ct.NgayChamCong, thg.MoTa AS Thang, " +
                "cong.MoTa AS MoTa, " +
                "cong.HeSo " +
                "FROM ctChamCong ct JOIN ChamCong cong ON cong.MaCC = ct.MaCC " +
                "JOIN Thang thg ON thg.MaThang = ct.MaThang " +
                "WHERE ct.MaNV = '"+ MaNV +"'";

            return db.ExecuteQueryDataSet(sql, CommandType.Text);
        }
        public DataSet LayDSChamCong()
        {
            string sql = "SELECT * FROM ChamCong";
            return db.ExecuteQueryDataSet(sql, CommandType.Text);
        }
        public bool ChamCong(string MaNV, string MaCC, ref string err)
        {
            try
            {
                DateTime ngayHienTai = DateTime.Now;

                string maThang = blThang.TaoMaThang(ngayHienTai);
                /*MessageBox.Show("" + maThang);*/
                int ngayChamCong = ngayHienTai.Day;
                
                if (!blThang.KiemTraThangTonTai(maThang, ref err))
                {
                    int soNgayCongChuan = blThang.TinhSoNgayCongChuan(maThang);

                    // Tạo mô tả tháng
                    string moTa = blThang.TaoMoTaThang(maThang);

                    // Thêm tháng mới
                    if (!blThang.ThemThang(maThang, moTa, soNgayCongChuan, ref err))
                    {
                        return false;
                    }
                }

                // Kiểm tra đã chấm công chưa???? 
                if (KiemTraDaChamCong(MaNV, maThang, ngayChamCong, ref err))
                {
                    err = "Đã chấm công cho ngày này";
                    return false;
                }

                string sql = "INSERT INTO ctChamCong (MaNV, MaCC, MaThang, NgayChamCong) " +
                    "VALUES(@MaNV, @MaCC, @MaThang, @NgayChamCong)";

                SqlCommand cmd = new SqlCommand(sql);
                cmd.Parameters.AddWithValue("@MaNV", MaNV);
                cmd.Parameters.AddWithValue("@MaCC", MaCC);
                cmd.Parameters.AddWithValue("@MaThang", maThang);
                cmd.Parameters.AddWithValue("@NgayChamCong", ngayChamCong);

                return db.MyExecuteNonQuery(cmd, CommandType.Text, ref err);
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }

        private bool KiemTraDaChamCong(string maNV, string maThang, int ngayChamCong, ref string err)
        {
            string sql = "SELECT COUNT(*) FROM ctChamCong WHERE MaNV=@MaNV " +
                "AND MaThang=@MaThang " +
                "AND NgayChamCong=@NgayChamCong";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@MaNV", maNV);
            cmd.Parameters.AddWithValue("@MaThang", maThang);
            cmd.Parameters.AddWithValue("@NgayChamCong", ngayChamCong);

            object result = db.ExecuteScalar(cmd, CommandType.Text);
            return Convert.ToInt32(result) > 0;
        }
        public bool ThemCong(string MaCC, string MoTa, float HeSo, ref string err)
        {

            string sql = "INSERT INTO ChamCong (MaCC, MoTa, HeSo) VALUES (@MaCC, @MoTa, @HeSo)";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@MaCC", MaCC);
            cmd.Parameters.AddWithValue("@MoTa", MoTa);
            cmd.Parameters.AddWithValue("@HeSo", HeSo);
            return db.MyExecuteNonQuery(cmd, CommandType.Text, ref err);
        }
        public bool SuaCong(string MaCC, string MoTa, float HeSo, ref string err)
        {

            string sql = "UPDATE ChamCong SET MoTa=@MoTa, HeSo=@HeSo WHERE MaCC=@MaCC";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@MaCC", MaCC);
            cmd.Parameters.AddWithValue("@MoTa", MoTa);
            cmd.Parameters.AddWithValue("@HeSo", HeSo);
            return db.MyExecuteNonQuery(cmd, CommandType.Text, ref err);
        }
    }
}
