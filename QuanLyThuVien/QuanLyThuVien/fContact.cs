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
    public partial class fContact : Form
    {
        public fContact()
        {
            InitializeComponent();
        }

        private void linklblWebsite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linklblWebsite.LinkVisited = true;
            System.Diagnostics.Process.Start("http://nhomhht.liveblog365.com/");
        }
    }
}
