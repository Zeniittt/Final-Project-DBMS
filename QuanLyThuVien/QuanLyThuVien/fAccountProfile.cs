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
    public partial class fAccountProfile : Form
    {
        public fAccountProfile()
        {
            InitializeComponent();
        }

        void LoadAllAccount()
        {
            DataTable list = AccountDAO.Instance.ShowAllAccount();
            dataGridView1.DataSource = list;
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            LoadAllAccount();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtUsername.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtPassword.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtTypeUser.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtTypeUserName.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            int roleID = int.Parse(txtTypeUser.Text);
            if(AccountDAO.Instance.CheckUserName(username))
            {
                if (AccountDAO.Instance.InsertAccount(username, password, roleID))
                {
                    MessageBox.Show("Thêm tài khoản thành công", "Thông báo", MessageBoxButtons.OK);
                    LoadAllAccount();
                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không hợp lệ", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LoadAllAccount();
                }
            }
            else
            {
                MessageBox.Show("Tên Tài khoản đã tồn tại", "Lỗi tài khoản", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoadAllAccount();
            }    
               
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            if(AccountDAO.Instance.DeleteAccount(username))
            {
                MessageBox.Show("Xóa tài khoản thành công", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra trong quá trình xử lý!", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoadAllAccount();
            }
        }
    }
}
