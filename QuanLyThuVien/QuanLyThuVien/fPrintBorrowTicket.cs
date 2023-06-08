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

namespace QuanLyThuVien
{
    public partial class fPrintBorrowTicket : Form //-------------------------------------------- TAB IN PHIẾU MƯỢN Ở FORM THEO DÕI MƯỢN TRẢ  ------------------------------------------
    {
        int idTicketBook;
        public int IdTicketBook { get => idTicketBook; set => idTicketBook = value; }

        // Show dữ liệu lên form
        public fPrintBorrowTicket(int idTicketBook)
        {
            this.IdTicketBook = idTicketBook;
            InitializeComponent();
            DateTime now = DateTime.Now;                
            lblThoiGiantt.Text = now.ToString();        // Lấy thời điểm hiện tại khi cho xuất phiếu cho độc giả
            LoadData();
        }

        // Truyền data đã lấy được dưới Database truyền vào biến list thông qua hàm GetBookToBorrowTicket ở lớp TicketBookDetailDAO
        public DataTable GetBookToBorrowTickett(int idTicketBook)
        {
            DataTable list = new DataTable();
            list = TicketBookDetailDAO.Instance.GetBookToBorrowTicket(idTicketBook);
            return list;
        }

        // Hàm này dùng để lấy dữ liệu truyền vào dataGridView và các label
        void LoadData()
        {
            lblNhanVientt.Text = TicketBookDetailDAO.Instance.GetStaffToBorrowTicket(IdTicketBook);                     // Lấy tên nhân viên 
            dataGridView2.DataSource = GetBookToBorrowTickett(IdTicketBook);                                            // Lấy những cuốn truyện cho mượn đẩy lên dataGridView2                                
            lblNgayMuontt.Text = TicketBookDetailDAO.Instance.GetBorrowDateToBorrowTicket(IdTicketBook).ToString();     // Lấy ngày mượn
            lblNgayTratt.Text = TicketBookDetailDAO.Instance.GetReturnDateToBorrowTicket(IdTicketBook).ToString();      // Lấy ngày trả
        }
    }
}
