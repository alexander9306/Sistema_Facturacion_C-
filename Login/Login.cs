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

namespace Login
{
    public partial class Login : Form
    {
        Connections SQL = new Connections();
        public Login()
        {
            InitializeComponent();
        }


        public void btnButton_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (SQL.ValidateUser(username,password))
            {
                Options objUserRegister = new Options();
                Hide();
                objUserRegister.Show();
            }
            else
            {
                MessageBox.Show("Please verify your username and password");
            }
        }
        
        private void lblPassword_Click(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Tab))
            {
                txtPassword.Focus();
            }
        }
    }
}
