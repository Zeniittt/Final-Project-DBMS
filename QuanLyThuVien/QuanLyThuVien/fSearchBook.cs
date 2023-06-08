using QuanLyThuVien.DAO;
using QuanLyThuVien.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace QuanLyThuVien
{
    public partial class fSearchBook : Form //-------------------------------------------- TRA CỨU SÁCH ---------------------------------------------------------------
    {
        public fSearchBook()
        {
            InitializeComponent();
            
        }

        // Load dữ liệu lấy được từ Database lên dataGridView1
        void LoadBookInfo()
        {
            DataTable listBookInfo = SearchBookDAO.Instance.GetBookInfo();
            dataGridView1.DataSource = listBookInfo;
        }

        // Hàm này trả về 1 bảng các cuốn sách theo Mã Sách
        public DataTable SearchBookByIDD(int idBook)
        {
            DataTable searchBook = new DataTable();
            searchBook = SearchBookDAO.Instance.SearchBookByID(idBook);
            return searchBook;
        }

        // Hàm này trả về 1 bảng các cuốn sách theo Tên Sách
        public DataTable SearchBookByNamee(string nameBook)
        {
            DataTable searchBook = new DataTable();
            searchBook = SearchBookDAO.Instance.SearchBookByName(nameBook);
            return searchBook;
        }

        // Hàm này trả về 1 bảng các cuốn sách theo Thể Loại
        public DataTable SearchBookByTypeBookk(string typeBook)
        {
            DataTable searchBook = new DataTable();
            searchBook = SearchBookDAO.Instance.SearchBookByTypeBook(typeBook);
            return searchBook;
        }

        // Hàm này trả về 1 bảng các cuốn sách theo Tác giả
        public DataTable SearchBookByWriterr(string writer)
        {
            DataTable searchBook = new DataTable();
            searchBook = SearchBookDAO.Instance.SearchBookByWriter(writer);
            return searchBook;
        }

        // Hàm này trả về 1 bảng các cuốn sách theo Ngôn ngữ
        public DataTable SearchBookByLanguagee(string language)
        {
            DataTable searchBook = new DataTable();
            searchBook = SearchBookDAO.Instance.SearchBookByLanguage(language);
            return searchBook;
        }

        // Xử lý click vào 1 Row bất kỳ thì dữ liệu sẽ được truyền vào các textBox
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtBookID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtBookName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtWriter.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtBookType.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtBookLanguage.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtNXB.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtKhu.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txtNgan.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            txtKe.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            txtBookStatus.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            txtSoLuong.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            txtBookPrice.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
        }

        // Hàm này xử lý nút Tìm để tìm sách theo mong muốn
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(RbtnBookID.Checked)
            {
                int idBook = int.Parse(txtSearchBook.Text);
                dataGridView1.DataSource = SearchBookByIDD(idBook);              
            }
            if (RbtnBookName.Checked)
            {
                dataGridView1.DataSource = SearchBookByNamee(txtSearchBook.Text);
            }
            if (RbtnType.Checked)
            {
                dataGridView1.DataSource = SearchBookByTypeBookk(txtSearchBook.Text);
            }
            if (RbtnWriter.Checked)
            {
                dataGridView1.DataSource = SearchBookByWriterr(txtSearchBook.Text);
            }
            if (RbtnLanguage.Checked)
            {
                dataGridView1.DataSource = SearchBookByLanguagee(txtSearchBook.Text);
            }

        }

        // Hàm này xử lý nút Hiện tất cả sách, khi bấm vào thì tất cả sách sẽ hiện ra
        private void btnShowAllBook_Click(object sender, EventArgs e)
        {
            LoadBookInfo();
        }

        // Event này được thực thi khi mà bấm những kí tự trong bàn phím ở txtSearchBook (textBox dùng để nhập dữ liệu vào)
        //private void txtSearchBook_KeyDown(object sender, KeyEventArgs e)
        //{
        //    btnSearch_Click(null, null);
        //}
    }
}
