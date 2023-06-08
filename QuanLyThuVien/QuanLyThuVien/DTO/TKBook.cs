using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DTO
{
    internal class TKBook
    {
        private int idBook;
        private string nameBook;
        private int theTimes;

        public TKBook(int idBook, string nameBook, int theTimes)
        {
            this.IdBook = idBook;
            this.NameBook = nameBook;
            this.TheTimes = theTimes;
        }

        public TKBook(DataRow row)
        {
            this.IdBook = (int)row["MaSach"];
            this.NameBook = row["TenSach"].ToString();
            this.TheTimes = (int)row["SoLanMuon"]; 
        }

        public int IdBook { get => idBook; set => idBook = value; }
        public string NameBook { get => nameBook; set => nameBook = value; }
        public int TheTimes { get => theTimes; set => theTimes = value; }
    }
}
