using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DTO
{
    public class Reader
    {
        private string id;
        private string name;
        private string sex;
        private DateTime birthdate;
        private string address;
        private string phone;

        public Reader(string id, string name, string sex, DateTime birthdate, string address, string phone)
        {
            this.Id = id;
            this.Name = name;
            this.Sex = sex;
            this.Birthdate = birthdate;
            this.Address = address;
            this.Phone = phone;
        }

        public Reader(DataRow row)
        {
            this.Id = row["MaDG"].ToString();
            this.Name = row["TenDG"].ToString();
            this.Sex = row["GioiTinh"].ToString();
            this.Birthdate = (DateTime)row["NgaySinh"];
            this.Address = row["DiaChi"].ToString();
            this.Phone = row["SDT"].ToString();
        }

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Sex { get => sex; set => sex = value; }
        public DateTime Birthdate { get => birthdate; set => birthdate = value; }
        public string Address { get => address; set => address = value; }
        public string Phone { get => phone; set => phone = value; }
    }
}
