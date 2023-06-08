using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DAO
{
    public class TicketBookDAO //-------------------------------------------- Kết nối DATABASE với form THEO DÕI MƯỢN TRẢ --------------------------------------------------------------------
    {
        private static TicketBookDAO instance;

        public static TicketBookDAO Instance
        {
            get { if (instance == null) instance = new TicketBookDAO(); return instance; }
            private set { instance = value; }
        }

        private TicketBookDAO() {}

        // Hàm này lấy nguyên bảng Phiếu sách dưới Database
        public DataTable GetTicketBook()
        {

            string query = "select * from PhieuSach";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            return data;
        }

        // Hàm này có tác dụng thực thi hàm Proc_ThemPhieuSach ở dưới Database với kết quả trả về là true hay false. Mục đích thêm Phiếu sách
        public bool InsertTicketBook(string idStaff, string idReader, int amount)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("Exec Proc_ThemPhieuSach @MaNV , @MaDG , @SoSachMuon ", new object[] { idStaff, idReader, amount });
            return result > 0;
        }
        
    }
}
