using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace Login
{
    public class Connections
    {
        SqlConnection Connect = new SqlConnection(@"Data Source=DESKTOP-RDD1CDR\SQLEXPRESS;Initial Catalog=Farmacia;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader Read;
        SqlDataAdapter adapt;

        public void CreateUser(string username, string password)
        {
            cmd = new SqlCommand("insert into Users(username,password) values(@username,@password)", Connect);
            Connect.Open();
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.ExecuteNonQuery();
            Connect.Close();
        }

        public void CreateItem(string Name, int Price, int Quantity)
        {
            cmd = new SqlCommand("insert into Items(nombre,precio,cantidad) values(@name,@price,@quantity)", Connect);
            Connect.Open();
            cmd.Parameters.AddWithValue("@name", Name);
            cmd.Parameters.AddWithValue("@price", Price);
            cmd.Parameters.AddWithValue("@quantity", Quantity);
            cmd.ExecuteNonQuery();
            Connect.Close();
        }

        public void UpdateItemQty(int Itemid, int Value)
        {
            Connect.Open();
            cmd = new SqlCommand("SELECT * FROM Items WHERE ItemID = @ID ", Connect);
            cmd.Parameters.AddWithValue("@ID", Itemid);
            Read = cmd.ExecuteReader();
            Read.Read();
            int Quantity = int.Parse(Read[3].ToString());
            Quantity -= Value;
            Connect.Close();

            Connect.Open();
            cmd = new SqlCommand("update Items set cantidad=@Quantity where ItemID=@ID", Connect);
            cmd.Parameters.AddWithValue("@ID", Itemid);
            cmd.Parameters.AddWithValue("@Quantity", Quantity);
            cmd.ExecuteNonQuery();
            Connect.Close();
        }

        public bool ValidateUser(string username, string password)
        {
            Connect.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("Select * from Users Where username = '" + username + "' and password = '" + password + "'", Connect);
            adapt.Fill(dt);
            Connect.Close();
            if (dt.Rows.Count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public DataTable DisplayOrders()
        {
            Connect.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("Select Orders.ordersID as OrderId, Orders.fecha as Purchase_Date, Items.nombre as Product_Name, Users.username as Username from Orders, Items,Users Where Orders.FK_Items=Items.ItemID and Orders.FK_Users=Users.userid order by Orders.ordersID", Connect);
            adapt.Fill(dt);
            Connect.Close();
            return dt;
        }

        public DataTable DisplayUsers()
        {
            Connect.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select userid, username from users", Connect);
            adapt.Fill(dt);
            Connect.Close();
            return dt;
        }

        public DataTable DisplayItems()
        {
            Connect.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select ItemID,nombre as Name,precio as Price,cantidad as Quantity from Items", Connect);
            adapt.Fill(dt);
            Connect.Close();
            return dt;
        }
        public DataTable SearchOrder(DateTime Date, int User)
        {
            Connect.Open();
            DataTable dt = new DataTable();
            string query = "Select Orders.ordersID as Order_Number, Orders.fecha as Purchase_Date, Items.nombre as Product_Name, Users.username as Username from Orders, Users, Items where Orders.fecha='" + Date.ToString() + "' and Users.userid=" + User.ToString() + " and  Orders.FK_Items=Items.ItemID and Orders.FK_Users=Users.userid";
            adapt = new SqlDataAdapter(query, Connect);
            adapt.Fill(dt);
            Connect.Close();
            return dt;
        }

        public int VerifyItemQty(int Itemid)
        {
            Connect.Open();
            cmd = new SqlCommand("SELECT * FROM Items WHERE ItemID = @ID ", Connect);
            cmd.Parameters.AddWithValue("@ID", Itemid);
            Read = cmd.ExecuteReader();
            Read.Read();

            int value = Validation.ValidateInt(Read[3].ToString());
            Connect.Close();

            return value;
        }

       

        public void CreateOrder(DateTime Date, int User, int Item)
        {
            cmd = new SqlCommand("insert into Orders(Fecha,FK_Users,FK_Items) values(@Fecha,@FK_Users,@FK_Items)", Connect);
            Connect.Open();

            cmd.Parameters.AddWithValue("@Fecha", Date.ToString());
            cmd.Parameters.AddWithValue("@FK_Users", User);
            cmd.Parameters.AddWithValue("@FK_Items", Item);
            cmd.ExecuteNonQuery();
            Connect.Close();
        }


    }
}
