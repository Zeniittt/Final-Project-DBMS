using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DTO
{
    public class CardReader
    {
        private string id;
        private string name;
        private DateTime StartDate;
        private DateTime EndDate;

        public CardReader(string id, string name, DateTime startDate, DateTime endDate)
        {
            this.Id = id;
            this.Name = name;
            this.StartDate = startDate;
            this.EndDate = endDate;
        }

        public CardReader(DataRow row)
        {
            this.Id = row["MaDG"].ToString();
            this.Name = row["TenDG"].ToString();
            this.StartDate = (DateTime)row["NgayBatDau"];
            this.EndDate = (DateTime)row["NgayHetHan"];
        }

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public DateTime StartDate1 { get => StartDate; set => StartDate = value; }
        public DateTime EndDate1 { get => EndDate; set => EndDate = value; }
    }
}
