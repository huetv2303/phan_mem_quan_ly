using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace phan_quan_ly_nhan_su
{
    public partial class fmain : Form
    {
        public fmain()
        {
            InitializeComponent();
        }

        private void quảnLýHệThốngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void fmain_Load(object sender, EventArgs e)
        {

        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.IsMdiContainer)
            {
                // Đặt form hiện tại làm MdiContainer
                this.IsMdiContainer = true;
            }
            fAccount account = new fAccount();
            account.MdiParent = this;
            account.Show();
           
        }

        private void phòngBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.IsMdiContainer)
            {
                // Đặt form hiện tại làm MdiContainer
                this.IsMdiContainer = true;
            }
            fDepartment department = new fDepartment();
            department.MdiParent = this;
            department.Show();
        }

        private void bộToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.IsMdiContainer)
            {
                // Đặt form hiện tại làm MdiContainer
                this.IsMdiContainer = true;
            }
            fDivision division = new fDivision();
            division.MdiParent = this;
            division.Show();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            flogin login = new flogin();
            login.Show();
        }

        private void fmain_Click(object sender, EventArgs e)
        {
        }

        private void fmain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn chắc chắn muốn thoát không?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                e.Cancel = false;


            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
