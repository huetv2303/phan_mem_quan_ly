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
    public partial class fDivision : Form
    {
        public fDivision()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
           
            txtMaBP.Text = " ";
            txtTenBP.Text = " ";
            txtGhiChu.Text = " ";   
            txtTimKiem.Text = " ";  
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgvDivision.CurrentRow.Index;
            txtMaBP.Text = dgvDivision.Rows[i].Cells[0].Value.ToString();
            txtTenBP.Text = dgvDivision.Rows[i].Cells[1].Value.ToString();
            dtpNgayTL.Text = dgvDivision.Rows[i].Cells[2].Value.ToString();
            txtGhiChu.Text = dgvDivision.Rows[i].Cells[3].Value.ToString();
        }
    }
}
