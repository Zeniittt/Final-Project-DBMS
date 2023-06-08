using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DTO
{
    public class Account
    {
        private int id;
        private string userName;
        private string password;
        private int roleID;

        public int Id { get => id; set => id = value; }
        public string UserName { get => userName; set => userName = value; }
        public string Password { get => password; set => password = value; }
        public int RoleID { get => roleID; set => roleID = value; }

        public Account(string userName, string password, int roleID)
        {
            this.UserName = userName;
            this.Password = password;
            this.RoleID = roleID;
        }

        public Account(DataRow row)
        {
            this.Id = (int)row["id"];
            this.UserName = row["Username"].ToString();
            this.Password = row["Password"].ToString();
            this.RoleID = (int)row["RoleID"];
        }
    }
}
