using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DTO
{
    public class SearchBook
    {
        private int idBook;
        private string nameBook;
        private string writer;
        private string typeBook;
        private string language;
        private string nXB;
        private string khu;
        private string ngan;
        private string ke;
        private string status;
        private int amount;
        private int price;

        public SearchBook(int idBook, string nameBook, string writer, string typeBook, string language, string nXB, string khu, string ngan, string ke, string status, int amount, int price)
        { 
            this.IdBook = idBook;
            this.NameBook = nameBook;
            this.Writer = writer;
            this.TypeBook = typeBook;
            this.Language = language;
            this.NXB = nXB;
            this.Khu = khu;
            this.Ngan = ngan;
            this.Ke = ke;
            this.Status = status;
            this.Amount = amount;
            this.Price = price;
        }

        public SearchBook(DataRow row)
        {
            this.IdBook = (int)row["MaSach"];
            this.NameBook = row["TenSach"].ToString();
            this.writer = row["TenTG"].ToString();
            this.TypeBook = row["TenTheLoai"].ToString();
            this.Language = row["TenNN"].ToString();
            this.NXB = row["TenNXB"].ToString();
            this.Khu = row["Khu"].ToString();
            this.Ngan = row["Ngan"].ToString();
            this.Ke = row["Ke"].ToString();
            this.Status = row["TinhTrang"].ToString();
            this.Amount = (int)row["SoLuong"];
            this.Price = (int)row["GiaTien"];
        }

        public int IdBook { get => idBook; set => idBook = value; }
        public string NameBook { get => nameBook; set => nameBook = value; }
        public string Writer { get => writer; set => writer = value; }
        public string TypeBook { get => typeBook; set => typeBook = value; }
        public string Language { get => language; set => language = value; }
        public string NXB { get => nXB; set => nXB = value; }
        public string Khu { get => khu; set => khu = value; }
        public string Ngan { get => ngan; set => ngan = value; }
        public string Ke { get => ke; set => ke = value; }
        public string Status { get => status; set => status = value; }
        public int Amount { get => amount; set => amount = value; }
        public int Price { get => price; set => price = value; }
    }
}
