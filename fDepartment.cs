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
    public partial class fDepartment : Form
    {
        public fDepartment()
        {
            InitializeComponent();
        }

        private void fDepartment_Load(object sender, EventArgs e)
        {

        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaBoPhan.Text = " ";
            txtMaPhong.Text = " ";
            txtTenPhong.Text = " ";
            txtGhiChu.Text = " ";
            txtTimKiem.Text = " ";
        }

        private void dgvDepartment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgvDepartment.CurrentRow.Index;
            txtMaBoPhan.Text = dgvDepartment.Rows[i].Cells[0].Value.ToString();
            txtTenPhong.Text = dgvDepartment.Rows[i].Cells[1].Value.ToString();
            txtMaPhong.Text = dgvDepartment.Rows[i].Cells[2].Value.ToString();
            dtpNgayThanhLap.Text = dgvDepartment.Rows[i].Cells[3].Value.ToString();
            txtGhiChu.Text = dgvDepartment.Rows[i].Cells[4].Value.ToString();
        }
    }
}
