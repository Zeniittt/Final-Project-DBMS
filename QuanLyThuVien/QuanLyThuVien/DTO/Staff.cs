using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DTO
{
    public class Staff
    {
        private string id;
        private string name;
        private DateTime birthdate;
        private string sex;
        private string phone;

        public Staff(string id, string name, DateTime birthdate, string sex, string phone)
        {
            this.Id = id;
            this.Name = name;
            this.Birthdate = birthdate;
            this.Sex = sex;
            this.Phone = phone;
        }

        public Staff(DataRow row)
        {
            this.Id = row["MaNV"].ToString();
            this.Name = row["TenNV"].ToString();
            this.Birthdate = (DateTime)row["NgaySinh"];
            this.Sex = row["GioiTinh"].ToString();
            this.Phone = row["SDT"].ToString();
        }

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public DateTime Birthdate { get => birthdate; set => birthdate = value; }
        public string Sex { get => sex; set => sex = value; }
        public string Phone { get => phone; set => phone = value; }
    }
}
