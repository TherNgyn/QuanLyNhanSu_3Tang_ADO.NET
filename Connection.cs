using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;

namespace QuanLyNhanSu_3Tang_ADO
{
    internal class Connection
    {
        /*public static string user;
        public static string pass;*/
        

        public static string connectString = "Data Source=DESKTOP-0PJCAJ8\\SQLEXPRESS;Initial Catalog=QuanLyNhanSu;Integrated Security=True;Encrypt=False";
        public static string GetConnectionString()
        {
            return connectString; 
        }
        public static SqlConnection getConnection()
        {
            return new SqlConnection(connectString);
        }

        public static DataTable LoadDataTable(string query)
        {
            connectString = GetConnectionString();
            SqlConnection conn = new SqlConnection(connectString);
            DataTable dataTable = new DataTable();
            try
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.Fill(dataTable);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                conn.Close();
            }
            return dataTable;
        }

        public static DataTable LoadDataTable(SqlCommand command)
        {
            connectString = GetConnectionString();
            SqlConnection conn = new SqlConnection(connectString);
            DataTable dataTable = new DataTable();
            try
            {
                command.Connection = conn;
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataTable);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                conn.Close();
            }
            return dataTable;
        }

        public static void ExecuteCommand(SqlCommand command)
        {
            connectString = GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectString))
            {
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }

        }
        public static void ExecuteCommandAdmin(SqlCommand command)
        {
            using (SqlConnection connection = new SqlConnection(connectString))
            {
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }

}
