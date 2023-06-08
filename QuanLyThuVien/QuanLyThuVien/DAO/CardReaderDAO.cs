using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DAO
{
    public class CardReaderDAO //-------------------------------------------- Kết nối DATABASE với form THẺ ĐỘC GIẢ --------------------------------------------------------------------
    {
        private static CardReaderDAO instance;

        public static CardReaderDAO Instance
        {
            get { if (instance == null) instance = new CardReaderDAO(); return instance; }
            private set { instance = value; }
        }

        private CardReaderDAO() { }

        // Hàm này lấy tất cả các thẻ độc giả ở dưới Database
        public DataTable GetCardReader()
        {

            string query = "select * from TheDG";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            return data;
        }
    }
}
