using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DTO
{
    public class Book
    {
        private int idBook;
        private string nameBook;
        private string idWriter;
        private int idTypeBook;
        private int idTypeLanguage;
        private string idNXB;
        private string idPos;
        private int idStatus;
        private int amount;
        private int price;

        public Book(int idBook, string nameBook, string idWriter, int idTypeBook, int idTypeLanguage, string idNXB, string idPos, int idStatus, int amount, int price)
        { 
            this.IdBook = idBook;
            this.NameBook = nameBook;
            this.IdWriter = idWriter;
            this.IdTypeBook = idTypeBook;
            this.IdTypeLanguage = idTypeLanguage;
            this.IdNXB = idNXB;
            this.IdPos = idPos;
            this.IdStatus = idStatus;
            this.Amount = amount;
            this.Price = price;         
        }

        public Book(DataRow row)
        {
            this.IdBook = (int)row["MaSach"];
            this.NameBook = row["TenSach"].ToString();
            this.IdWriter = row["MaTG"].ToString();
            this.IdTypeBook = (int)row["MaTL"];
            this.IdTypeLanguage = (int)row["MaNN"];
            this.IdNXB = row["MaNXB"].ToString();
            this.IdPos = row["MaVT"].ToString();
            this.IdStatus = (int)row["MaTT"];
            this.Amount = (int)row["SoLuong"];
            this.Price = (int)row["GiaTien"];
        }

        public int IdBook { get => idBook; set => idBook = value; }
        public string NameBook { get => nameBook; set => nameBook = value; }
        public string IdWriter { get => idWriter; set => idWriter = value; }
        public int IdTypeBook { get => idTypeBook; set => idTypeBook = value; }
        public int IdTypeLanguage { get => idTypeLanguage; set => idTypeLanguage = value; }
        public string IdNXB { get => idNXB; set => idNXB = value; }
        public string IdPos { get => idPos; set => idPos = value; }
        public int IdStatus { get => idStatus; set => idStatus = value; }
        public int Amount { get => amount; set => amount = value; }
        public int Price { get => price; set => price = value; }
    }
}
