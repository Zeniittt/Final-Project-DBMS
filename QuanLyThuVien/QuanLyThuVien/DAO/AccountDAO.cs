using QuanLyThuVien.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DAO
{
    public class AccountDAO //-------------------------------------------- Kết nối DATABASE với form LOGIN --------------------------------------------------------------------
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get { if(instance == null) instance = new AccountDAO(); return instance; }
            private set { instance = value; }
        }

        private AccountDAO() { }

        public bool Login(string username, string password, string query)
        {
            DataTable table = new DataTable();
            table = DataProvider.Instance.ExecuteQuery(query, new object[] {username, password});
            return table.Rows.Count > 0;
        }

        public Account GetAccountManager(string username, string password)
        {
            DataTable table = DataProvider.Instance.ExecuteQuery("EXEC dbo.LoginAsQuanLy @userName  , @passWord ", new object[] { username, password });
            DataRow row = table.Rows[0];
            Account loginAccount = new Account(row);
            return loginAccount;
        }

        public Account GetAccountStaff(string username, string password)
        {
            DataTable table = DataProvider.Instance.ExecuteQuery("EXEC dbo.LoginAsNhanVien @userName  , @passWord ", new object[] { username, password });
            DataRow row = table.Rows[0];
            Account loginAccount = new Account(row);
            return loginAccount;
        }

        public DataTable ShowAllAccount()
        {
            DataTable table = DataProvider.Instance.ExecuteQuery("SELECT * FROM [Danh sách tài khoản]");
            return table;
        }

        public bool CheckUserName(string username)
        {
            DataTable table = new DataTable();
            table = DataProvider.Instance.ExecuteQuery("SELECT * FROM KiemTraTenDangNhap ( @userName )", new object[] { username });
            //lớn hơn 0 thì false
            return table.Rows.Count <= 0;
        }

        public bool InsertAccount(string username, string password, int roleID)
        {
            if (DataProvider.Instance.ExecuteNonQuery("EXEC dbo.ThemAccount @userName , @password , @roleID ", new object[] { username, password, roleID }) == 1)
            {
                return true;
            }
            return false;
        }

        public bool DeleteAccount(string username)
        {
            if (DataProvider.Instance.ExecuteNonQuery("EXEC dbo.XoaAccount @userName ", new object[] { username }) == 1)
            {
                return true;
            }
            return false;
        }

    }
}
