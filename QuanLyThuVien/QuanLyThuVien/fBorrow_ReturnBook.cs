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
    public partial class fBorrow_ReturnBook : Form //-------------------------------------------- THEO DÕI MƯỢN TRẢ ---------------------------------------------------------------
    {
        
        public fBorrow_ReturnBook()
        {
            InitializeComponent();
            LoadTicketBook();
            LoadTicketBookDetail();
            AddInfoTicketBookDetail();
        }

        #region Tab Lập Phiếu Mượn
        // Load data lên dataGridView của tab Phiếu sách
        void LoadTicketBook()
        {
            DataTable listTicketBook = TicketBookDAO.Instance.GetTicketBook();
            dataGridView1.DataSource = listTicketBook;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTicketID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtStaffID.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtReaderID.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtAmount.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        // Thêm phiếu sách
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //TicketBookDAO.Instance.CreateTicketBook();
            //txtTicketID.Text = TicketBookDAO.Instance.GetNewestTickerBook().ToString();
            string idTicketBook = txtTicketID.Text;
            string idStaff = txtStaffID.Text;
            string idReader = txtReaderID.Text;
            int amount = int.Parse(txtAmount.Text);
            try
            {
                if (TicketBookDAO.Instance.InsertTicketBook(idStaff, idReader, amount))
                {
                    MessageBox.Show("Thêm phiếu sách thành công");
                    LoadTicketBook();
                    LoadTicketBookDetail();
                }
                else
                {
                    MessageBox.Show("Có lỗi trong quá trình xử lý! Thêm phiếu sách không thành công...");
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo!", MessageBoxButtons.OK);
            }
        }
        #endregion

        #region Tab Chi tiết mượn
        // Load phiếu sách chi tiết lên 2 cái dataGridView của 2 tab mượn và trả 
        void LoadTicketBookDetail()
        {
            DataTable listTicketBookDetail = TicketBookDetailDAO.Instance.GetTicketBookDetail();
            dataGridView2.DataSource = listTicketBookDetail;
            dataGridView3.DataSource = listTicketBookDetail;
        }

        // Even khi click vào một Row bất kỳ sẽ cho thông tin ra các textBox
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTicketBookID.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            txtSTT.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            txtBookID.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            txtStatusID.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            txtStaffName.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
            txtReaderName.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
            dateTimePicker1.Value = (DateTime)dataGridView2.CurrentRow.Cells[6].Value;
            dateTimePicker2.Value = (DateTime)dataGridView2.CurrentRow.Cells[7].Value;
            CheckBookID();
        }

        // Load dữ liệu lên comboBox Sách
        void AddInfoTicketBookDetail()
        {
            cbBoxBookID.DataSource = TicketBookDetailDAO.Instance.GetBookID();
            cbBoxBookID.DisplayMember = "TenSach";
            cbBoxBookID.ValueMember = "MaSach";
        }

        // Kiểm tra nút Mượn
        void CheckBookID()
        {
            if (txtBookID.Text.Length > 0)
            {
                btnMuon.Enabled = false;
            }
            else
            {
                btnMuon.Enabled = true;
            }
        }

        // Xử lý Button mượn
        private void btnMuon_Click(object sender, EventArgs e)
        {
            int idBook = int.Parse(cbBoxBookID.SelectedValue.ToString());
            int idTicketBook = int.Parse(txtTicketBookID.Text);
            int STT = int.Parse(txtSTT.Text);
            try
            {
                if (TicketBookDetailDAO.Instance.UpdateTicketBookDetail(idBook, idTicketBook, STT))
                {

                    MessageBox.Show("Mượn sách thành công!!");
                    LoadTicketBookDetail();
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Sách này đã hết", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        #endregion

        #region Tab In Phiếu Mượn
        public DataTable SearchTicketBook_Muon_ByIDTicketBookk(int idTicketBook)
        {
            DataTable searchBook = new DataTable();
            searchBook = TicketBookDetailDAO.Instance.SearchTicketBook_Muon_ByIDTicketBook(idTicketBook);
            return searchBook;
        }

        void LoadDataToInPhieuMuon()
        {
            int idTicketBook = int.Parse(txtSearchTicketBookMuon.Text);
            dataGridView4.DataSource = SearchTicketBook_Muon_ByIDTicketBookk(idTicketBook);
        }

        private void btnTimKiemMuon_Click(object sender, EventArgs e)
        {
            LoadDataToInPhieuMuon();
        }

        private void btnInMuon_Click(object sender, EventArgs e)
        {
            fPrintBorrowTicket f = new fPrintBorrowTicket(int.Parse(txtSearchTicketBookMuon.Text));
            f.ShowDialog();
        }
        #endregion

        #region Tab Chi tiết trả
        // Even khi click vào một Row bất kỳ sẽ cho thông tin ra các textBox
        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTicketBookIDTra.Text = dataGridView3.CurrentRow.Cells[0].Value.ToString();
            txtSTTTra.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString();
            txtBookIDTra.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString();
            txtStatusIDTra.Text = dataGridView3.CurrentRow.Cells[3].Value.ToString();
            txtStaffNameTra.Text = dataGridView3.CurrentRow.Cells[4].Value.ToString();
            txtReaderNameTra.Text = dataGridView3.CurrentRow.Cells[5].Value.ToString();
            dateTimePicker3.Value = (DateTime)dataGridView3.CurrentRow.Cells[6].Value;
            dateTimePicker4.Value = (DateTime)dataGridView3.CurrentRow.Cells[7].Value;
        }

        
        // Xử lý Button kiểm tra tiền phạt
        private void btnCheckFineMoney_Click(object sender, EventArgs e)
        {
            int idTicketBook = int.Parse(txtTicketBookIDTra.Text);
            int STT = int.Parse(txtSTTTra.Text);
            int idBook = int.Parse(txtBookIDTra.Text);
            int idStatus = int.Parse(txtStatusIDTra.Text);
            try
            {
                if (TicketBookDetailDAO.Instance.CheckFineMoney(idTicketBook, STT, idBook, idStatus))
                {
                    MessageBox.Show("aaaaaaaaaaa    !");
                }
            }catch(Exception ex)
            {
                LoadTicketBookDetail();
                MessageBox.Show(ex.Message, "Thông báo!", MessageBoxButtons.OK);
            }


        }

        // Xử lý Button Tra Sach
        private void btnTra_Click(object sender, EventArgs e)
        {
            int idTicketBook = int.Parse(txtTicketBookIDTra.Text);
            int STT = int.Parse(txtSTTTra.Text);
            try
            {
                if (TicketBookDetailDAO.Instance.ReturnTicketBookDetail(idTicketBook, STT))
                {
                }
            } catch(Exception ex)
            {
                LoadTicketBook();
                LoadTicketBookDetail();
                MessageBox.Show(ex.Message, "Thông báo!", MessageBoxButtons.OK);
            }
        }

        #endregion

        #region Tab In Phiếu Trả
        public DataTable SearchTicketBook_Tra_ByIDTicketBookk(int idTicketBook)
        {
            DataTable searchBook = new DataTable();
            searchBook = TicketBookDetailDAO.Instance.SearchTicketBook_Tra_ByIDTicketBook(idTicketBook);
            return searchBook;
        }

        public int TongTienPhat(int idTicketBook)
        {
            int Sum;
            Sum = int.Parse(TicketBookDetailDAO.Instance.CalTinhTienPhat(idTicketBook).ToString());

            return Sum;                  
        }

        void LoadDataToInPhieuTra()
        {
            int idTicketBook = int.Parse(txtSearchTicketBookTra.Text);
            dataGridView5.DataSource = SearchTicketBook_Tra_ByIDTicketBookk(idTicketBook);
        }

        private void btnTimKiemTra_Click(object sender, EventArgs e)
        {
            int idTicketBook = int.Parse(txtSearchTicketBookTra.Text);
            LoadDataToInPhieuTra();
            txtTongTienPhat.Text = TongTienPhat(idTicketBook).ToString();
        }

        private void btnInTra_Click(object sender, EventArgs e)
        {
            fPrintReturnTicket f = new fPrintReturnTicket(int.Parse(txtSearchTicketBookTra.Text));
            f.ShowDialog();
        }

        #endregion


    }
}
