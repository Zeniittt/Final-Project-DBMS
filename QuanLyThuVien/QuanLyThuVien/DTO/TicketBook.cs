using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DTO
{
    internal class TicketBook
    {
        int idTicket;
        string idStaff;
        string idReader;
        int amount;

        public TicketBook(int idTicket, string idStaff, string idReader, int amount)
        {
            this.IdTicket = idTicket;
            this.IdStaff = idStaff;
            this.IdReader = idReader;
            this.Amount = amount;
        }

        public TicketBook(DataRow row)
        {
            this.IdTicket = (int)row["MaPhieu"];
            this.IdStaff = row["MaNV"].ToString();
            this.IdReader = row["MaDG"].ToString();
            this.Amount = (int)row["SoSachMuon"];
        }

        public int IdTicket { get => idTicket; set => idTicket = value; }
        public string IdStaff { get => idStaff; set => idStaff = value; }
        public string IdReader { get => idReader; set => idReader = value; }
        public int Amount { get => amount; set => amount = value; }
    }
}
