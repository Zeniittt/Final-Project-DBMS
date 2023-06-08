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
    public partial class fPrintReturnTicket : Form //-------------------------------------------- TAB IN PHIẾU TRẢ TRONG FORM THEO DÕI MƯỢN TRẢ ----------------------------------------
    {
        int idTicketBook;
        public int IdTicketBook { get => idTicketBook; set => idTicketBook = value; }

        // Show dữ liệu lên form
        public fPrintReturnTicket(int idTicketBook)
        {
            this.IdTicketBook = idTicketBook;
            InitializeComponent();
            DateTime now = DateTime.Now;
            lblThoiGiantt.Text = now.ToString();        // Lấy thời điểm hiện tại khi cho xuất phiếu cho độc giả
            LoadData();
        }

        // Truyền data đã lấy được dưới Database truyền vào biến list thông qua hàm GetBookToReturnTicket ở lớp TicketBookDetailDAO
        public DataTable GetBookToReturnTickett(int idTicketBook)
        {
            DataTable list = new DataTable();
            list = TicketBookDetailDAO.Instance.GetBookToReturnTicket(idTicketBook);
            return list;
        }

        // Truyền data đã lấy được dưới Database truyền vào biến list thông qua hàm GetFineMoneyToReturnTicket ở lớp TicketBookDetailDAO
        public DataTable GetFineMoneyToReturnTickett(int idTicketBook)
        {
            DataTable list = new DataTable();
            list = TicketBookDetailDAO.Instance.GetFineMoneyToReturnTicket(idTicketBook);
            return list;
        }

        // Hàm này dùng để lấy dữ liệu truyền vào dataGridView và các label
        void LoadData()
        {
            lblNhanVientt.Text = TicketBookDetailDAO.Instance.GetStaffToReturnTicket(IdTicketBook);                     // Lấy tên nhân viên 
            dataGridView2.DataSource = GetBookToReturnTickett(IdTicketBook);                                            // Lấy những cuốn truyện cho mượn đẩy lên dataGridView2                                
            lblNgayMuontt.Text = TicketBookDetailDAO.Instance.GetBorrowDateToReturnTicket(IdTicketBook).ToString();     // Lấy ngày mượn
            lblNgayTratt.Text = TicketBookDetailDAO.Instance.GetReturnDateToReturnTicket(IdTicketBook).ToString();      // Lấy ngày trả
            dataGridView1.DataSource = GetFineMoneyToReturnTickett(IdTicketBook);
            lblTongtientt.Text = TicketBookDetailDAO.Instance.CalTinhTienPhat(idTicketBook).ToString();
        }
    }
}
