using QuanLyThuVien.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class fStatistical : Form //-------------------------------------------- THỐNG KÊ -------------------------------------------------------------------
    {
        public fStatistical()
        {
            InitializeComponent();
            LoadDataBookTimes();
            LoadDataBorrow_Return();
        }

        #region Tab Thống kê số lượng sách đã được mượn

        // Load dữ liệu lên dataGridView1
        void LoadDataBookTimes()
        {
            DataTable listBook = TKBookDAO.Instance.GetDataBookTimes();
            dataGridView1.DataSource = listBook;
        }
        #endregion

        #region Tab thống kê Mượn trả

        // Load dữ liệu lên dataGridView2
        void LoadDataBorrow_Return()
        {
            DataTable listBook = TKBorrow_ReturnDAO.Instance.GetDataBorrow_Return();
            dataGridView2.DataSource = listBook;
        }

        // Hàm tìm kiếm theo mã độc giả, lôi dữ liệu lên từ thông qua Instance của class TKBorrow_ReturnDAO
        public DataTable SearchRBByReaderIDD(string idReader)
        {
            DataTable searchBook = new DataTable();
            searchBook = TKBorrow_ReturnDAO.Instance.SearchRBByReaderID(idReader);
            return searchBook;
        }

        // Xử lý bằng Button tìm kiếm
        private void BtnTimKiemRB_Click(object sender, EventArgs e)
        {
            string idReader = txtSearchRB.Text;
            dataGridView2.DataSource = SearchRBByReaderIDD(idReader);
        }
        #endregion
    }
}
