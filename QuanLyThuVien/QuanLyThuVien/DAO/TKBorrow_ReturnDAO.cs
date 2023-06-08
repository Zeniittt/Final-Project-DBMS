using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DAO
{
    internal class TKBorrow_ReturnDAO
    {
        private static TKBorrow_ReturnDAO instance;

        public static TKBorrow_ReturnDAO Instance
        {
            get { if (instance == null) instance = new TKBorrow_ReturnDAO(); return instance; }
            private set { instance = value; }
        }

        private TKBorrow_ReturnDAO() { }

        
        public DataTable GetDataBorrow_Return()
        {

            string query = "select * from [Danh Sách Đọc Giả Mượn Sách Của Thư Viện]";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            return data;
        }

        public DataTable SearchRBByReaderID(string idReader)
        {
            string query = string.Format("select * from TatCaSachDocGiaMuon(dbo.MaDGThanhTenDG('{0}'))", idReader);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            return data;
        }
    }
}
