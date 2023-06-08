using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien.DAO
{
    public class DataProvider 
    {
        private static DataProvider instance;
        private static DataProvider instanceforpermission;
        private static string username;
        private static string password;

        public static DataProvider InstanceGetPermission(string username, string password)
        {
            if(instanceforpermission == null) instanceforpermission = new DataProvider(username, password);
            return instance;
        }

        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return DataProvider.instance; }
            private set { DataProvider.instance = value; } 
        }

        private DataProvider(string username, string password)
        {
            DataProvider.username = username;
            DataProvider.password = password;
        }

        private DataProvider()
        {
        }

        //private string connectionstring = @"Data Source=LAPTOP-36EMDPS4\SQLEXPRESS;Initial Catalog=QLThuVien;Integrated Security=True"; 

        private string connectionstring = ("Password=" + DataProvider.password + "; Persist Security Info=True;User ID=" + DataProvider.username + @";Initial Catalog=QLThuVien;Data Source=LAPTOP-36EMDPS4\SQLEXPRESS");

        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);


                if(parameter != null)
                {
                    object[] listPara = query.Split(' ');
                    int i = 0;

                    foreach(string item in listPara)
                    {
                        if(item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }    
                    }    
                }    

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                connection.Close();
            }
            return data;
        }


        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);


                if (parameter != null)
                {
                    object[] listPara = query.Split(' ');
                    int i = 0;

                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = command.ExecuteNonQuery();

                connection.Close();
            }
            return data;
        }


        public object ExecuteScalar(string query, object[] parameter = null)
        {
            object data = 0;
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);


                if (parameter != null)
                {
                    object[] listPara = query.Split(' ');
                    int i = 0;

                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = command.ExecuteScalar();

                connection.Close();
            }
            return data;
        }

    }
}
