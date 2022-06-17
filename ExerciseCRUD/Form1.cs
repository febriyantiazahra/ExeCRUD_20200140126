using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExerciseCRUD
{
    public partial class fLogin : Form
    {
        readonly string username = "Febriyanti";
        readonly string password = "12345";
        public fLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == username && txtPass.Text == password)
            {
                this.Hide();
                MessageBox.Show("Berhasil Login");
                fMain data = new fMain();
                data.Show();
            }
            else if (txtUser.Text == "" && txtPass.Text == "")
            {
                MessageBox.Show("Masukkan Username dan Password!!!");
            }
            else
            {
                MessageBox.Show("Username atau Password Anda Salah");
            }
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cekpass_CheckedChanged(object sender, EventArgs e)
        {
            if (cekpass.Checked)
            {
                txtPass.UseSystemPasswordChar = false;
            }
            else
            {
                txtPass.UseSystemPasswordChar = true;
            }
        }

        private void txtPass_TextChanged_1(object sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar = true;
        }
    }
}
