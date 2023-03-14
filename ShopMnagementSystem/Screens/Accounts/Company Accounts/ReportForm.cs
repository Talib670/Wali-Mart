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

namespace ShopMnagementSystem.Screens.Accounts.Company_Accounts
{
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            DataClasses7DataContext d = new DataClasses7DataContext();
            dataGridView1.DataSource = d.GenralPurchases.ToList();
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

                    string str = "Select *  FROM [ShopManage].[dbo].[GenralPurchase] WHERE [Date] LIKE '%" + textBox1.Text + "%' OR [Employee Name] LIKE '%" + textBox1.Text + "%' OR [Name Amount] LIKE '%" + textBox1.Text + "%' OR [Jumma Amount] LIKE '%" + textBox1.Text + "%' OR [Bqaya Amount] LIKE '%" + textBox1.Text + "%'";
                    SqlCommand cmd = new SqlCommand(str, con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.DataSource = new BindingSource(dt, null);
                }
                textBox1.Text = "";
            }
        }

        private void lblinc_Click(object sender, EventArgs e)
        {

        }

        private void Label9_Click(object sender, EventArgs e)
        {

        }

        private void btnlast_Click(object sender, EventArgs e)
        {

        }

        private void btnnext_Click(object sender, EventArgs e)
        {

        }

        private void btnprev_Click(object sender, EventArgs e)
        {

        }

        private void btnfirst_Click(object sender, EventArgs e)
        {

        }

        private void lblmax_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
