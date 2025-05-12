using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Configuration;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class signup : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["ShoppingMartConnectionString"].ConnectionString;

        public signup()
        {
            InitializeComponent();
            this.Load += new EventHandler(signup_Load); // Ensure Load event is registered
            this.StartPosition = FormStartPosition.CenterScreen;
           // this.tableLayoutPanel1.Location = new System.Drawing.Point(704, 495);

        }

        private void signup_Load(object sender, EventArgs e)
        {
            // Merge the first two columns in the first row
          //  tableLayoutPanel1.SetColumnSpan(label1, 2);

            // Ensure the label is centered and fills the space
          //  label1.TextAlign = ContentAlignment.MiddleCenter;
          //  label1.Dock = DockStyle.Fill;
        }

        private void signup_Load_1(object sender, EventArgs e)
        {

        }
    }
}
