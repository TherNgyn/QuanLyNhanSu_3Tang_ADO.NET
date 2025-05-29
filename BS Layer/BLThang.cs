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
    class BLThang
    {
        DBMain db;
        public BLThang()
        {
            db = new DBMain();
        }
        public DataSet LayThang()
        {
            return db.ExecuteQueryDataSet("SELECT * FROM Thang", CommandType.Text);
        }

        public bool ThemThang(string MaThang, string MoTa, int SoNgayCong, ref string err)
        {
            try
            {
                string sqlString = "INSERT INTO Thang (MaThang, MoTa, SoNgayCongChuan) " +
                    "VALUES (@MaThang, @MoTa, @SoNgayCongChuan)";
                SqlCommand command = new SqlCommand(sqlString);
                command.Parameters.AddWithValue("@MaThang", MaThang);
                command.Parameters.AddWithValue("@MoTa", MoTa);
                command.Parameters.AddWithValue("@SoNgayCongChuan", SoNgayCong);
                return db.MyExecuteNonQuery(command, CommandType.Text, ref err);
            }
            catch (SqlException ex)
            {
                err = ex.Message;
                return false;
            }
        }
        
        public bool CapNhatThang(string MaThang, string MoTa, int SoNgayCong, ref string err)
        {
            
            string sqlString = "UPDATE Thang SET MoTa=@MoTa, SoNgayCongChuan=@SoNgayCong " +
                    "WHERE MaThang=@MaThang";
            SqlCommand cmd = new SqlCommand(sqlString);
            cmd.Parameters.AddWithValue("@MoTa", MoTa);
            cmd.Parameters.AddWithValue("@SoNgayCong", SoNgayCong);
            cmd.Parameters.AddWithValue("@MaThang", MaThang);
            return db.MyExecuteNonQuery(cmd, CommandType.Text, ref err);

        }
        
        public bool KiemTraThangTonTai(string MaThang, ref string err)
        {
            string sql = "SELECT COUNT(*) FROM Thang WHERE MaThang=@MaThang";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@MaThang", MaThang);

            object result = db.ExecuteScalar(cmd, CommandType.Text);
            return Convert.ToInt32(result) > 0;
        }

        // Tính số ngày công chuẩn
        public int TinhSoNgayCongChuan(string MaThang)
        {
            int soNgayLamViec = 0;

            int thang = int.Parse(MaThang.Substring(0, 2));
            int nam = int.Parse(MaThang.Substring(2, 4));

            // bắt đầu và ngày kết thúc của tháng
            DateTime ngayBatDau = new DateTime(nam, thang, 1);
            DateTime ngayKetThuc = ngayBatDau.AddMonths(1).AddDays(-1);

            // Duyệt qua từng ngày trong tháng
            for (DateTime ngay = ngayBatDau; ngay <= ngayKetThuc; ngay = ngay.AddDays(1))
            {
                if (ngay.DayOfWeek != DayOfWeek.Saturday && ngay.DayOfWeek != DayOfWeek.Sunday)
                {
                    soNgayLamViec++;
                }
            }

            return soNgayLamViec;
        }

        public string TaoMaThang(DateTime ngay)
        {
            return ngay.ToString("MMyyyy");
        }
        public string TaoMoTaThang(string maThang)
        {
            string thang = maThang.Substring(0, 2);
            string nam = maThang.Substring(2, 4);
            return $"Tháng {thang} năm {nam}";
        }
    }
}
