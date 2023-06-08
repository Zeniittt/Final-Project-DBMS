using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace QuanLyThuVien.DAO
{
    public class BookDAO //-------------------------------------------- Kết nối DATABASE với form SÁCH --------------------------------------------------------------------
    {
        private static BookDAO instance;

        public static BookDAO Instance
        {
            get { if (instance == null) instance = new BookDAO(); return instance; }
            private set { instance = value; }
        }

        private BookDAO() { }

        // Hàm này lấy nguyên bảng Sách dưới Database
        public DataTable GetBook()
        {

            string query = "select * from Sach";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            return data;
        }

        // Hàm này có tác dụng thực thi hàm Proc_ThemSach ở dưới Database với kết quả trả về là true hay false. Mục đích thêm NHÂN VIÊN
        public bool InsertBook(int idBook, string nameBook, string idWriter, int idTypeBook, int idTypeLanguage, string idNXB, string idPos, int idStatus, int amount, int price)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("Exec Proc_ThemSach @MaSach , @TenSach , @MaTG , @MaTL , @MaNN , @MaNXB , @MaVT , @MaTT , @SoLuong , @GiaTien ", 
                new object[] { idBook, nameBook, idWriter, idTypeBook, idTypeLanguage, idNXB, idPos, idStatus, amount, price});

            return result > 0;
        }

        // Hàm này có tác dụng thực thi hàm Proc_SuaSach ở dưới Database với kết quả trả về là true hay false. Mục đích sửa NHÂN VIÊN
        public bool UpdateBook(int idBook, string nameBook, string idWriter, int idTypeBook, int idTypeLanguage, string idNXB, string idPos, int idStatus, int amount, int price)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("Exec Proc_SuaSach @MaSach , @TenSach , @MaTG , @MaTL , @MaNN , @MaNXB , @MaVT , @MaTT , @SoLuong , @GiaTien ", 
                new object[] { idBook, nameBook, idWriter, idTypeBook, idTypeLanguage, idNXB, idPos, idStatus, amount, price });

            return result > 0;
        }

        // Hàm này có tác dụng thực thi hàm Proc_XoaSach ở dưới Database với kết quả trả về là true hay false. Mục đích xóa NHÂN VIÊN
        public bool DeleteBook(int id)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("Exec Proc_XoaSach @MaSach ", new object[] { id });

            return result > 0;
        }
    }
}
