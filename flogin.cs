using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using phan_quan_ly_nhan_su.common;
using phan_quan_ly_nhan_su.Models;
using System.Diagnostics;

namespace phan_quan_ly_nhan_su
{
    public partial class flogin : Form 
    {   

        public flogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string username = txtTai_khoan.Text;
            string password = txtMat_khau.Text;

            UserModel userModel = new UserModel();
            dynamic user = userModel.getLogin(username,password);
            Console.WriteLine(user);

        }

        private void flogin_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void hide_Click(object sender, EventArgs e)
        {
        }

        private void show_Click(object sender, EventArgs e)
        {
            if(txtMat_khau.PasswordChar == '\0')
            {
                hide.BringToFront();
                txtMat_khau.PasswordChar = '*';
            }
        }

        private void hide_Click_1(object sender, EventArgs e)
        {
            if (txtMat_khau.PasswordChar == '*')
            {
                show.BringToFront();
                txtMat_khau.PasswordChar = '\0';
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            fmain main = new fmain();
            main.Show();
        }
    }
}
