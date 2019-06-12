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
    public partial class ItemRegister : Form
    {
        Connections SQL = new Connections();
        public ItemRegister()
        {
            InitializeComponent();
            ShowItems();
        }

        private void ShowItems()
        {
            dtgItems.DataSource = SQL.DisplayItems();
        }
        private void ClearText()
        {
            txtName.Clear();
            txtPrice.Clear();
            txtQuantity.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var price = Validation.ValidateInt(txtPrice.Text);
            var quantity = Validation.ValidateInt(txtQuantity.Text);
            if (price == 0 || quantity == 0)
            {
                MessageBox.Show("Upps! Please verify the values ");
            }
            else
            {
                SQL.CreateItem(txtName.Text, price, quantity);
                ShowItems();
                ClearText();
                MessageBox.Show("Product created succesfully! ");
            }
        }

        private void ItemRegister_FormClosing(object sender, FormClosingEventArgs e)
        {
            Options obj = new Options();
            Hide();
            obj.Show();
        }

        private void dtgItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
