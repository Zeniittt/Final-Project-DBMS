using QuanLyThuVien.DAO;
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

namespace QuanLyThuVien
{
    public partial class fCardReaderManage : Form //-------------------------------------------- THẺ ĐỘC GIẢ ---------------------------------------------------------------
    {
        public fCardReaderManage()
        {
            InitializeComponent();
            LoadCardReader();
        }

        void LoadCardReader()
        {
            DataTable listCardReader = CardReaderDAO.Instance.GetCardReader();
            dataGridView1.DataSource = listCardReader;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtReaderID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtReaderName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            dateTimePicker1.Value = (DateTime)dataGridView1.CurrentRow.Cells[2].Value;
            dateTimePicker2.Value = (DateTime)dataGridView1.CurrentRow.Cells[3].Value;
        }
    }
}
