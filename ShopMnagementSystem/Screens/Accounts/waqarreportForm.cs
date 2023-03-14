using ShopMnagementSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopMnagementSystem.Screens.Accounts
{
    public partial class waqarreportForm : Form
    {
        public waqarreportForm()
        {
            InitializeComponent();
        }

        private void waqarreportForm_Load(object sender, EventArgs e)
        {
            DataClasses5DataContext d = new DataClasses5DataContext();
            dataGridView1.DataSource = d.dtrwqars.ToList();
        }

        private void searchbutton_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == " ")
            {
                MessageBox.Show("Please Enter Valid Product Name OR Catagary OR Price t....!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                using (SqlConnection con = new SqlConnection((DecHelper.ConnectionString)))
                {

                    string str = "Select * FROM [ShopManage].[dbo].[dtrwqar] WHERE [Date] LIKE '%" + textBox1.Text + "%' OR [Name Amount] LIKE '%" + textBox1.Text + "%' OR [Jumma Amount] LIKE '%" + textBox1.Text + "%' OR [Baqaya Amount] LIKE '%" + textBox1.Text + "%'";
                    SqlCommand cmd = new SqlCommand(str, con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.DataSource = new BindingSource(dt, null);
                }
                textBox1.Text = " ";
            }
        }
    }
}
