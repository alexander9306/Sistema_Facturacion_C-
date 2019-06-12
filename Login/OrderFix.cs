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
    public partial class OrderFix : Form
    {
        Connections SQL = new Connections();

        public OrderFix()
        {
            InitializeComponent();
            ShowItems();
            ShowUsers();
            ShowOrders();
        }

        private void ShowOrders()
        {
            dtgOrders.DataSource = SQL.DisplayOrders();
        }
        private void ShowItems()
        {
            cBoxItems.DropDownStyle = ComboBoxStyle.DropDownList;
            cBoxItems.DataSource = SQL.DisplayItems();
            cBoxItems.DisplayMember = "nombre";
            cBoxItems.ValueMember = "ItemID";

        }

        private void ShowUsers()
        {
            listBoxUser.DataSource = SQL.DisplayUsers();
            listBoxUser.DisplayMember = "username";
            listBoxUser.ValueMember = "userid";
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //position = dtgOrder.CurrentRow.Index;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            int userid = int.Parse(listBoxUser.SelectedValue.ToString());
            int itemid = int.Parse(cBoxItems.SelectedValue.ToString());
            int quantity = Validation.ValidateInt(txtQuantity.Text);


            if (quantity == 0)
            {
                MessageBox.Show("Please verify the quantity of items selected");
            }
            else
            {
                if (SQL.VerifyItemQty(itemid) < 1)
                {
                    MessageBox.Show("Sorry! We do not have it in stock");
                }
                else
                {
                    txtQuantity.Clear();
                    SQL.UpdateItemQty(itemid, quantity);
                    SQL.CreateOrder(now, userid, itemid);
                    MessageBox.Show("A new order has been created");
                    ShowOrders();
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            
        }

        private void OrderFix_FormClosing(object sender, FormClosingEventArgs e)
        {
            Options obj = new Options();
            Hide();
            obj.Show();
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            DateTime lookfor = datetimePicker.Value;
            int userid = int.Parse(listBoxUser.SelectedValue.ToString());
            dtgOrders.DataSource = SQL.SearchOrder(lookfor, userid);
        }
    }
}
