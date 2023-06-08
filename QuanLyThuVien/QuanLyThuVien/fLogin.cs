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
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if(rbtnManager.Checked == true)
            {
                string username = textBoxUserName.Text;
                string password = textBoxPassword.Text;
                DataProvider.InstanceGetPermission(username, password);
                string query = "EXEC dbo.LoginAsQuanLy @userName  , @passWord ";
                if (AccountDAO.Instance.Login(username, password, query))
                {
                    //xử lý tác vụ phân quyền giao diện
                    Account account = AccountDAO.Instance.GetAccountManager(username, password);


                    //Giấu Form này đi thay vì Close() để có thể gọi lại
                    this.Hide();

                    //Gọi Form mới
                    fTableManager mainForm = new fTableManager(account);
                    mainForm.ShowDialog(this);

                    //Khi tắt Form mới sẽ gọi lại form cũ
                    mainForm = null;
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không hợp lệ", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (rbtnStaff.Checked == true)
            {
                //Get Form Info
                string query = "EXEC dbo.LoginAsNhanVien @userName , @passWord ";
                string username = textBoxUserName.Text;
                string password = textBoxPassword.Text;
                DataProvider.InstanceGetPermission(username, password);
                if (AccountDAO.Instance.Login(username, password, query))
                {
                    //xử lý tác vụ phân quyền giao diện
                    Account account = AccountDAO.Instance.GetAccountStaff(username, password);
                    //Giấu Form này đi thay vì Close() để có thể gọi lại
                    this.Hide();

                    //Gọi Form mới
                    fTableManager mainForm = new fTableManager(account);
                    mainForm.ShowDialog(this);

                    //Khi tắt Form mới sẽ gọi lại form cũ
                    mainForm = null;
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không hợp lệ", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn loại tài khoản! ", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn thật sự muốn thoát khỏi chương trình?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }   
        }



        //private void buttonLogin_Click(object sender, EventArgs e) // Xử lý bấm vào nút đăng nhập sẽ hiện ra form Phần mềm quản lý
        //{
        //    string username = textBoxUserName.Text;
        //    string password = textBoxPassword.Text;
        //    if (Login(username, password) == true)
        //    {
        //        fTableManager ftableManager = new fTableManager();
        //        this.Hide();
        //        ftableManager.ShowDialog();
        //        this.Show();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Bạn đã điền sai tên tài khoản hoặc mật khẩu!");
        //    }
        //}

        //bool Login(string username, string password)
        //{
        //    return AccountDAO.Instance.Login(username, password);
        //}

        //private void buttonExit_Click(object sender, EventArgs e)
        //{
        //    Application.Exit();
        //}

        //private void fLogin_FormClosing(object sender, FormClosingEventArgs e) // Xử lý thoát chương trình
        //{
        //    if(MessageBox.Show("Bạn thật sự muốn thoát khỏi chương trình?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK )
        //    {
        //        e.Cancel = true;
        //    }    
        //}

    }
}
