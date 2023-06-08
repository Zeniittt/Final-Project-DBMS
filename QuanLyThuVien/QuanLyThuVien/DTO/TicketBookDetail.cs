using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DTO
{
    internal class TicketBookDetail
    {
        private int sTT;
        private int idTicket;
        private int idBook;
        private int idStatus;
        private string nameStaff;
        private string nameReader;
        private DateTime startDate;
        private DateTime endDate;

        public TicketBookDetail(int sTT, int idTicket, int idBook, int idStatus, string nameStaff, string nameReader, DateTime startDate, DateTime endDate)
        { 
            this.IdTicket = idTicket;
            this.sTT = sTT;
            this.IdBook = idBook;
            this.idStatus = idStatus;
            this.NameStaff = nameStaff;
            this.NameReader = nameReader;
            this.StartDate = startDate;
            this.EndDate = endDate;
        }

        public TicketBookDetail(DataRow row)
        {

            this.IdTicket = (int)row["MaPhieu"];
            this.STT = (int)row["STT"];
            this.IdBook = (int)row["MaSach"];
            this.IdStatus = (int)row["MaTT"];
            this.NameStaff = row["TenNV"].ToString();
            this.NameReader = row["TenDG"].ToString();
            this.StartDate = (DateTime)row["NgayMuon"];
            this.EndDate = (DateTime)row["NgayTra"];
        }

        public int IdTicket { get => idTicket; set => idTicket = value; }
        public int IdBook { get => idBook; set => idBook = value; }
        public int STT { get => sTT; set => sTT = value; }
        public int IdStatus { get => idStatus; set => idStatus = value; }
        public string NameStaff { get => nameStaff; set => nameStaff = value; }
        public string NameReader { get => nameReader; set => nameReader = value; }
        public DateTime StartDate { get => startDate; set => startDate = value; }
        public DateTime EndDate { get => endDate; set => endDate = value; }
        
        
    }
}
