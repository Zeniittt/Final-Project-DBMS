using QuanLyThuVien.DAO;
using QuanLyThuVien.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace QuanLyThuVien
{
    public partial class fStaffManage : Form //-------------------------------------------- NHÂN VIÊN ---------------------------------------------------------------
    {
        public fStaffManage()
        {
            InitializeComponent();
            LoadStaff();
        }

        // Load dữ liệu lấy được từ Database lên dataGridView1
        void LoadStaff()
        {
            DataTable listStaff = StaffDAO.Instance.GetStaff();
            dataGridView1.DataSource = listStaff;
        }

        // Xử lý khi double click vào 1 Row bất kỳ thì dữ liệu sẽ được truyền vào các textBox
        private void dataGridView1_CellContentDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txtStaffID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtStaffName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            dateTimePicker1.Value = (DateTime)dataGridView1.CurrentRow.Cells[2].Value;
            if ((dataGridView1.CurrentRow.Cells[3].Value.ToString() == "Nam"))
            {
                RbtnNam.Checked = true;
                RbtnNu.Checked = false;
            }
            else
            {
                RbtnNam.Checked = false;
                RbtnNu.Checked = true;
            }
            txtPhone.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        // Hàm xử lý nút Thêm 
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string id = txtStaffID.Text;
            string name = txtStaffName.Text;
            DateTime birthdate = dateTimePicker1.Value;
            string sex = "Nam";
            if (RbtnNu.Checked)
            {
                sex = "Nữ";
            }
            string phone = txtPhone.Text;

            try
            {
                if (StaffDAO.Instance.InsertStaff(id, name, birthdate, sex, phone))
                {                        
                }
            } catch(Exception ex)
            {
                LoadStaff();
                MessageBox.Show(ex.Message, "Thông báo!",MessageBoxButtons.OK);
            }
        }

        // Hàm xử lý nút Sửa
        private void btnEdit_Click(object sender, EventArgs e)
        {
            string id = txtStaffID.Text;
            string name = txtStaffName.Text;
            DateTime birthdate = dateTimePicker1.Value;
            string sex = "Nam";
            if (RbtnNu.Checked)
            {
                sex = "Nữ";
            }
            string phone = txtPhone.Text;
            string idStaff = txtStaffID.Text;
            try
            {
                if (StaffDAO.Instance.UpdateStaff(id, name, birthdate, sex, phone))
                {
                }
            } catch (Exception ex)
            {
                LoadStaff();
                MessageBox.Show(ex.Message, "Thông báo!", MessageBoxButtons.OK);
            }
        }

        // Hàm xử lý nút Xóa
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = txtStaffID.Text;
            try
            {
                if (StaffDAO.Instance.DeleteStaff(id))
                {
                }
            }
            catch(Exception ex)
            {
                LoadStaff();
                MessageBox.Show(ex.Message);
            }
                
        }
    }
}
