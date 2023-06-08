using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DAO
{
    internal class TKBookDAO
    {
        private static TKBookDAO instance;

        public static TKBookDAO Instance
        {
            get { if (instance == null) instance = new TKBookDAO(); return instance; }
            private set { instance = value; }
        }

        private TKBookDAO() { }

        public DataTable GetDataBookTimes()
        {

            string query = "exec SoLanSachDuocMuon";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            return data;
        }
    }
}
