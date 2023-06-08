using QuanLyThuVien.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace QuanLyThuVien
{
    public partial class fBookManage : Form //-------------------------------------------- SÁCH ---------------------------------------------------------------
    {
        public fBookManage()
        {
            InitializeComponent();
            LoadBook();
        }
        // Load dữ liệu lên dataGridView1
        void LoadBook()
        {
            DataTable listBook = BookDAO.Instance.GetBook();
            dataGridView1.DataSource = listBook;
        }
        
        // Hàm này có chức năng khi click nào một dòng bất kỳ sẽ cho ra từng giá trị ở từng textBox
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtBookID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtBookName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtWriterID.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtBookCate.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtBookLanguage.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtNXBID.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtBookPosition.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txtBookStatus.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            txtSoLuong.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            txtBookPrice.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
        }

        // Xử lý trong Button Thêm
        private void btnAdd_Click(object sender, EventArgs e)
        {
            int idBook = int.Parse(txtBookID.Text);
            string nameBook = txtBookName.Text;
            string idWriter = txtWriterID.Text;
            int idTypeBook = int.Parse(txtBookCate.Text);
            int idTypeLanguage = int.Parse(txtBookLanguage.Text);
            string idNXB = txtNXBID.Text;
            string idPos = txtBookPosition.Text;
            int idStatus = int.Parse(txtBookStatus.Text);
            int amount = int.Parse(txtSoLuong.Text);
            int price = int.Parse(txtBookPrice.Text);
            try
            {
                if (BookDAO.Instance.InsertBook(idBook, nameBook, idWriter, idTypeBook, idTypeLanguage, idNXB, idPos, idStatus, amount, price))
                {
                }
            }catch(Exception ex)
            {
                LoadBook();
                MessageBox.Show(ex.Message, "Thông báo!",MessageBoxButtons.OK);
            }
        }

        // Xử lý trong Button Sửa
        private void btnEdit_Click(object sender, EventArgs e)
        {
            int idBook = int.Parse(txtBookID.Text);
            string nameBook = txtBookName.Text;
            string idWriter = txtWriterID.Text;
            int idTypeBook = int.Parse(txtBookCate.Text);
            int idTypeLanguage = int.Parse(txtBookLanguage.Text);
            string idNXB = txtNXBID.Text;
            string idPos = txtBookPosition.Text;
            int idStatus = int.Parse(txtBookStatus.Text);
            int amount = int.Parse(txtSoLuong.Text);
            int price = int.Parse(txtBookPrice.Text);
            try
            {
                if (BookDAO.Instance.UpdateBook(idBook, nameBook, idWriter, idTypeBook, idTypeLanguage, idNXB, idPos, idStatus, amount, price))
                {
                }
            }catch(Exception ex)
            {
                LoadBook();
                MessageBox.Show(ex.Message, "Thông báo!", MessageBoxButtons.OK);
            }
        }

        // Xử lý trong Button Xóa
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtBookID.Text);
            try
            {
                if (BookDAO.Instance.DeleteBook(id))
                {
                }
            }catch(Exception ex)
            {
                LoadBook();
                MessageBox.Show(ex.Message, "Thông báo!", MessageBoxButtons.OK);
            }
        }
    }
}
