using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        int final_cost = 0;
        int tax = 0;
        int SR_NO = 0;
        string cs = ConfigurationManager.ConnectionStrings["ShoppingMartConnectionString"].ConnectionString;

        public Form1()
        {
            InitializeComponent();
              getInvoiceID();
            GetItems();
            textBox2.Text = login.username;
            dataGridView1.ColumnCount = 8;
            dataGridView1.Columns[0].Name = "SR NO";
            dataGridView1.Columns[1].Name = "ITEM";
            dataGridView1.Columns[2].Name = "UNIT PRICE";
            dataGridView1.Columns[3].Name = "DISC/ITEM";
            dataGridView1.Columns[4].Name = "QUANTITY";
            dataGridView1.Columns[5].Name = "SUBTOTAL";
            dataGridView1.Columns[6].Name = "TAX";
            dataGridView1.Columns[7].Name = "TOTAL COST";

        }

        void GetItems()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from items_tbl";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string item_names = dr.GetString(1);
                comboBox1.Items.Add(item_names);
            }
            con.Close();
        }

        void GetPrice()
        {

            if (comboBox1.SelectedItem == null)
            {

            }
            else
            {


                int price = 0;
                using (SqlConnection con = new SqlConnection(cs))
                {
                    string query = "SELECT item_price FROM items_tbl WHERE item_name = @name";
                    SqlDataAdapter sda = new SqlDataAdapter(query, con);
                    sda.SelectCommand.Parameters.AddWithValue("@name", comboBox1.SelectedItem.ToString());
                    DataTable data = new DataTable();
                    sda.Fill(data);

                    if (data.Rows.Count > 0) // Fixed the 'if' statement
                    {
                        price = Convert.ToInt32(data.Rows[0]["item_price"]);
                        textBox3.Text = price.ToString(); // Set the price here
                    }
                }
            }
        }
        void GetDiscount()
        {
            int discount = 0;
            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "SELECT item_discount FROM items_tbl WHERE item_name = @name";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                sda.SelectCommand.Parameters.AddWithValue("@name", comboBox1.SelectedItem.ToString());
                DataTable data = new DataTable();
                sda.Fill(data);

                if (data.Rows.Count > 0) // Fixed the 'if' statement
                {
                    discount = Convert.ToInt32(data.Rows[0]["item_discount"]);
                    textBox4.Text = discount.ToString(); // Set the price here
                }
            }
        }
        private void label5_Click(object sender, EventArgs e)
        {
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
        }

        private void label8_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {

            }
            else
            {
                int subtotal = Convert.ToInt32(textBox6.Text);
                if (subtotal >= 10000)
                {
                    tax = (int)(subtotal * 0.15);
                    textBox7.Text = tax.ToString();

                }
                else if (subtotal >= 6000)
                {
                    tax = (int)(subtotal * 0.10);
                    textBox7.Text = tax.ToString();
                }

                else if (subtotal >= 3000)
                {
                    tax = (int)(subtotal * 0.07);
                    textBox7.Text = tax.ToString();
                }

                else if (subtotal >= 1000)
                {
                    tax = (int)(subtotal * 0.05);
                    textBox7.Text = tax.ToString();
                }

                else
                {
                    tax = (int)(subtotal * 0.03);
                    textBox7.Text = tax.ToString();

                }
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {

            }
            else
            {


                int subtotal = Convert.ToInt32(textBox6.Text);
                int tex = Convert.ToInt32(textBox7.Text);
                int totalcost = subtotal + tex;
                textBox8.Text = totalcost.ToString();
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {

            }
            else
            {
                int price = Convert.ToInt32(textBox3.Text);
                int discount = Convert.ToInt32(textBox4.Text);
                int quantity = Convert.ToInt32(textBox5.Text);
                int subtotal = (price * quantity);
                subtotal = subtotal - discount * quantity;
                textBox6.Text = subtotal.ToString();
            }
        }
        private void textBox5_KeyPressed(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;  // ❌ ERROR: 'EventArgs' does not have 'KeyChar'
            if (char.IsDigit(ch) == true)
            {
                e.Handled = false;  // ❌ ERROR: 'EventArgs' does not have 'Handled'
            }
            else
            {
                e.Handled = true;
            }
        }




        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                Console.WriteLine($"Selected Item: {comboBox1.SelectedItem.ToString()}"); // Debug line
                GetPrice();    //getting price from database;
                GetDiscount();  //getting discount from database; 
                textBox5.Enabled = true;


            }
        }

        void AddDatatoGridView(string sr_no, string item_name, string unit_price, string discount, string quantity, string subtotal, string tax, string total_cost)
        {
            string[] row = { sr_no, item_name, unit_price, discount, quantity, subtotal, tax, total_cost };
            dataGridView1.Rows.Add(row);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Ensure an item is selected in the comboBox
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select an item before adding.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ensure required textboxes are not empty
            if (string.IsNullOrWhiteSpace(textBox3.Text) ||  // Unit Price
                string.IsNullOrWhiteSpace(textBox4.Text) ||  // Discount
                string.IsNullOrWhiteSpace(textBox5.Text) ||  // Quantity
                string.IsNullOrWhiteSpace(textBox6.Text) ||  // Subtotal
                string.IsNullOrWhiteSpace(textBox7.Text) ||  // Tax
                string.IsNullOrWhiteSpace(textBox8.Text))    // Total Cost
            {
                MessageBox.Show("Please enter all required details before adding.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Safely add data to GridView
            AddDatatoGridView((++SR_NO).ToString(), comboBox1.SelectedItem.ToString(), textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text);

            ResetControls();
            CalculateFinalCost();
        }


        void ResetControls()
        {
            comboBox1.SelectedItem = null;
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox5.Enabled = false;

            CalculateFinalCost(); // Ensure final cost updates when resetting
        }


        private void button2_Click(object sender, EventArgs e)
        {
            int a = 0;
            ResetControls();
            textBox9.Text = a.ToString();
        }

        void CalculateFinalCost()
        {
            final_cost = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[7].Value != null)  // Ensure it's not null
                {
                    final_cost += Convert.ToInt32(row.Cells[7].Value);
                }
            }
            textBox9.Text = final_cost.ToString();  // Show final cost in the text box
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox10.Text))
            {
                textBox11.Clear();
                return;
            }

            int amountPaid, finalCost;

            // Validate input
            if (!int.TryParse(textBox10.Text, out amountPaid))
            {
                MessageBox.Show("Please enter a valid number in Amount Paid.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox10.Clear();
                return;
            }

            // Ensure textBox9 (final cost) is correctly parsed
            if (!int.TryParse(textBox9.Text, out finalCost))
            {
                finalCost = 0;
            }

            int change = amountPaid - finalCost;
            textBox11.Text = change.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            SR_NO = 0;
        }
        void getInvoiceID()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "SELECT invoice_id FROM order_master";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);

            if(data.Rows.Count<1)
            {
                int a = 1;
                textBox1.Text = a.ToString();
            }

            else
            {
                string query2 = "SELECT MAX(invoice_id) FROM order_master";
                SqlCommand cmd = new SqlCommand(query2, con);
                con.Open();
                object result = cmd.ExecuteScalar();
                int a = result != DBNull.Value ? Convert.ToInt32(result) + 1 : 1;
                textBox1.Text = a.ToString();
                con.Close();
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "insert into order_master values(@invoice_id,@user,@datetime,@finalcost)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@invoice_id", textBox1.Text);
            cmd.Parameters.AddWithValue("@user", textBox2.Text);
            cmd.Parameters.AddWithValue("@datetime", DateTime.Now.ToString());
            cmd.Parameters.AddWithValue("@finalcost", textBox9.Text);

            con.Open();
            int a = cmd.ExecuteNonQuery();
            if(a>0)
            {
                MessageBox.Show("inserted successfully !!", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                getInvoiceID();
                ResetControls();
            }
            else
            {
                MessageBox.Show("insertion failed !!", "failure", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            con.Close();


        }

        private void button5_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bmp = Properties.Resources.image;
            Image img = bmp;
            e.Graphics.DrawImage(img, 30, 5,800,250);
            e.Graphics.DrawString("Invoice ID:" + textBox1.Text,new Font("Arial",15,FontStyle.Bold),Brushes.Black,new Point(30,300));
            e.Graphics.DrawString("User Name:" + textBox2.Text, new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 330));
            e.Graphics.DrawString("Date:" + DateTime.Now.ToShortDateString(), new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 360));
            e.Graphics.DrawString("Time:" + DateTime.Now.ToLongTimeString(), new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 390));
            e.Graphics.DrawString("-----------------------------------------------------------------------------------------------------------------", new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 420));
            e.Graphics.DrawString("Item", new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 450));
            e.Graphics.DrawString("Price", new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(240, 450));
            e.Graphics.DrawString("Discount", new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(390, 450));
            e.Graphics.DrawString("Quantity", new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(590, 450));
            e.Graphics.DrawString("-----------------------------------------------------------------------------------------------------------------", new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 480));

            //item name...
            int gap = 510;
            if(dataGridView1.Rows.Count>0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].IsNewRow) continue; // skip the last empty row

                    string item = dataGridView1.Rows[i].Cells[1].Value?.ToString();
                    if (!string.IsNullOrEmpty(item))
                    {
                        e.Graphics.DrawString(item, new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, gap));
                        gap += 30;
                    }
                }

            }


            //item price...

            int gap1 = 510;
            if (dataGridView1.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].IsNewRow) continue; // skip the last empty row

                    string item = dataGridView1.Rows[i].Cells[2].Value?.ToString();
                    if (!string.IsNullOrEmpty(item))
                    {
                        e.Graphics.DrawString(item, new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(240, gap1));
                        gap1 += 30;
                    }
                }

            }

            //quantity...

            int gap2 = 510;
            if (dataGridView1.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].IsNewRow) continue; // skip the last empty row

                    string item = dataGridView1.Rows[i].Cells[3].Value?.ToString();
                    if (!string.IsNullOrEmpty(item))
                    {
                        e.Graphics.DrawString(item, new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(390, gap2));
                        gap2 += 30;
                    }
                }

            }

            //quantity...

            int gap3 = 510;
            if (dataGridView1.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].IsNewRow) continue; // skip the last empty row

                    string item = dataGridView1.Rows[i].Cells[4].Value?.ToString();
                    if (!string.IsNullOrEmpty(item))
                    {
                        e.Graphics.DrawString(item, new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(590, gap3));
                        gap3 += 30;
                    }
                }

            }

            int subtotalprint = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[7].Value != null)  // Ensure it's not null
                {
                    subtotalprint += Convert.ToInt32(row.Cells[5].Value);
                }
            }

            e.Graphics.DrawString("-----------------------------------------------------------------------------------------------------------------", new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 850));

            e.Graphics.DrawString("Sub Total:  "+subtotalprint.ToString(), new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 880));



            int taxprint = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[7].Value != null)  // Ensure it's not null
                {
                   taxprint += Convert.ToInt32(row.Cells[6].Value);
                }
            }


            e.Graphics.DrawString("Tax:  " + taxprint.ToString(), new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 910));

          


            e.Graphics.DrawString("Final Amount:  " + textBox9.Text.ToString(), new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 940));
            e.Graphics.DrawString("-----------------------------------------------------------------------------------------------------------------", new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 970));

            e.Graphics.DrawString("Amount Paid:  " + textBox10.Text.ToString(), new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 1000));

            e.Graphics.DrawString("Change:  " + textBox11.Text.ToString(), new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 1030));

        }

        private void button6_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }

        private void addItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddItemForm adf = new AddItemForm();
           

            adf.ShowDialog();

        }

       
    }
}