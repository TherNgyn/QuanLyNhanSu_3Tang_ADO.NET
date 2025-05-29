using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;
namespace QuanLyNhanSu_3Tang_ADO.DB_Layer
{
    class DBMain
    {
        public static string connectString = "Data Source=LAPTOP-7H9D7KEU\\CSDL_SQLSEVER;Initial Catalog=QuanLyNhanSu;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
        SqlConnection conn = null;
        SqlCommand comm = null;
        SqlDataAdapter da = null;
        public DBMain()
        {
            conn = new SqlConnection(connectString);
            comm = conn.CreateCommand();
        }
        public DataSet ExecuteQueryDataSet(string strSQL, CommandType ct)
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();
            comm.CommandText = strSQL;
            comm.CommandType = ct;
            da = new SqlDataAdapter(comm);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public bool MyExecuteNonQuery(SqlCommand cmd, CommandType ct, ref string error)
        {
            bool f = false;
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandType = ct;

            try
            {
                cmd.ExecuteNonQuery();
                f = true;  
            }
            catch (SqlException ex)
            {
                error = ex.Message;
                f = false;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                f = false;
            }
            finally
            {
                conn.Close();
            }
            return f;
        }
        public DataSet ExecuteQueryDataSetWithCmd(SqlCommand cmd, CommandType ct)
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();
            cmd.Connection = conn; // Gán kết nối cho SqlCommand
            cmd.CommandType = ct;

            da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close(); // Đóng kết nối sau khi hoàn thành
            return ds;
        }

    }
}
