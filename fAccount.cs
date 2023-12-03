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
    public partial class fAccount : Form
    {
        public fAccount()
        {
            InitializeComponent();
        }

        private void fAccount_Load(object sender, EventArgs e)
        {
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtuserName.Text = "";
            txtPermission.Text = "";
            txtPass.Text = "";
            txtTimKiem.Text = "";
            txtName.Text = "";
        }

        private void dgvAccount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgvAccount.CurrentRow.Index;
            txtuserName.Text = dgvAccount.Rows[i].Cells[0].Value.ToString();
            txtPass.Text = dgvAccount.Rows[i].Cells[1].Value.ToString();
            txtName.Text = dgvAccount.Rows[i].Cells[2].Value.ToString();
            txtPermission.Text = dgvAccount.Rows[i].Cells[3].Value.ToString();
            
        }
    }
}
