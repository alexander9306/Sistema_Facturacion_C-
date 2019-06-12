using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class Options : Form
    {
        public Options()
        {
            InitializeComponent();
        }

        private void Options_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserRegister objUserRegister = new UserRegister();
            Hide();
            objUserRegister.Show();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            ItemRegister objUserRegister = new ItemRegister();
            Hide();
            objUserRegister.Show();
        }

        private void BtnOrders_Click(object sender, EventArgs e)
        {
            OrderFix obj = new OrderFix();
            Hide();
            obj.Show();
        }

        private void Options_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
