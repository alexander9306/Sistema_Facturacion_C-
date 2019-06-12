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
    public partial class UserRegister : Form
    {
        public UserRegister()
        {
            InitializeComponent();
            ShowUsers();
        }
        Connections SQL = new Connections();


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SQL.CreateUser(txtUserName.Text, txtPassword.Text);
            MessageBox.Show("Usuario registrado con exito");
            ShowUsers();
        }

        private void UserRegister_Load(object sender, EventArgs e)
        {

        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }
        private void ShowUsers()
        {
            dtgUsers.DataSource = SQL.DisplayUsers();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void UserRegister_FormClosing(object sender, FormClosingEventArgs e)
        {
            Options obj = new Options();
            Hide();
            obj.Show();
        }
    }
}
