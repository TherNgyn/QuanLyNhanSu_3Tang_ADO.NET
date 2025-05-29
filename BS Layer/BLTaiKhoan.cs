using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using QuanLyNhanSu_3Tang_ADO.DB_Layer;


namespace QuanLyNhanSu_3Tang_ADO.BS_Layer
{
    internal class BLTaiKhoan
    {
        DBMain db = null;

        public BLTaiKhoan()
        {
            db = new DBMain();
        }
        public DataTable AuthenticateUser(string username, string password)
        {
            DataTable dt = new DataTable();
            try
            {
                string sqlString = "SELECT TK.MaLoai, LTK.Ten " +
                                   "FROM TaiKhoan TK JOIN LoaiTaiKhoan LTK ON TK.MaLoai = LTK.MaLoai " +
                                   "WHERE TK.TenDangNhap = @Username AND TK.MatKhau = @Password";

                // Tạo SqlCommand và thêm tham số, giống như cách bạn muốn
                SqlCommand cmd = new SqlCommand(sqlString);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password); // Mật khẩu không mã hóa

                // Gọi phương thức mới trong DBMain để thực thi SqlCommand đã có tham số
                DataSet ds = db.ExecuteQueryDataSetWithCmd(cmd, CommandType.Text);

                if (ds != null && ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                // Ném lại ngoại lệ để BLL hoặc UI có thể xử lý
                throw new Exception("Lỗi DAL khi xác thực người dùng: " + ex.Message, ex);
            }
            return dt;
        }
        public string AuthenticateUser(string username, string password, out string roleName)
        {
            roleName = string.Empty;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return "Vui lòng nhập đầy đủ Tên đăng nhập và Mật khẩu.";
            }

            try
            {
                DataTable result = AuthenticateUser(username, password);

                if (result != null && result.Rows.Count > 0)
                {
                    roleName = result.Rows[0]["Ten"].ToString();
                    return "SUCCESS";
                }
                else
                {
                    return "Tên đăng nhập hoặc mật khẩu không đúng.";
                }
            }
            catch (Exception ex)
            {
                return "Đã xảy ra lỗi trong quá trình xác thực: " + ex.Message;
            }
        }

        public bool CapNhatMatKhau(String username, String password, ref string err)
        {
            string sqlString = "UPDATE TaiKhoan " +
               "SET MatKhau = @MatKhau " +
               "WHERE TenDangNhap = @TenDangNhap";
            SqlCommand cmd = new SqlCommand(sqlString);
            cmd.Parameters.AddWithValue("@TenDangNhap", username);
            cmd.Parameters.AddWithValue("@MatKhau", password);
            return db.MyExecuteNonQuery(cmd, CommandType.Text, ref err);

        }
    }
}
