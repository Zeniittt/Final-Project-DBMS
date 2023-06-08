using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DAO
{
    public class LoadList
    {
        private string connectionstring = @"Data Source=LAPTOP-36EMDPS4\SQLEXPRESS;Initial Catalog=QLThuVien;Integrated Security=True";
        DataTable data = new DataTable();
        public DataTable ExecuteQueryToLoadList(string query)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                connection.Close();
            }
            return data;
        }
    }
}
