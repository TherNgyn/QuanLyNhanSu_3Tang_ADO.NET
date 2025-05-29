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
        public static string connectString = "Data Source=DESKTOP-0PJCAJ8\\SQLEXPRESS;Initial Catalog=QuanLyNhanSu;Integrated Security=True;Encrypt=False";
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
            cmd.Connection = conn; 
            cmd.CommandType = ct;

            da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close(); // Đóng kết nối sau khi hoàn thành
            return ds;
        }
        public object ExecuteScalar(SqlCommand cmd, CommandType ct)
        {
            try
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();

                conn.Open();
                cmd.Connection = conn;
                cmd.CommandType = ct;
                object result = cmd.ExecuteScalar();

                conn.Close(); 
                return result;
            }
            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                throw ex; 
            }
        }
        public DataTable ExecuteQueryDataTableWithCmd(SqlCommand cmd, CommandType cmdType)
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();

            conn.Open();
            cmd.Connection = conn;
            cmd.CommandType = cmdType;

            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            conn.Close();
            return dt;
        }

    }
}
