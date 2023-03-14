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
using ShopMnagementSystem.Models;
namespace ShopMnagementSystem.Screens.Accounts.Sale_Account
{
    public partial class SaleaccountForm : Form
    {
        DataClasses9DataContext d = new DataClasses9DataContext();
        public SaleaccountForm()
        {
            InitializeComponent();
        }

        private void SaleaccountForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = d.SaleAccounts.ToList();
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

                    string str = "Select * FROM [ShopManage].[dbo].[SaleAccount] WHERE [Date] LIKE '%" + textBox1.Text + "%' OR [Name Amount] LIKE '%" + textBox1.Text + "%' OR [Jumma Amount] LIKE '%" + textBox1.Text + "%' OR [Baqaya Amount] LIKE '%" + textBox1.Text + "%'";
                    SqlCommand cmd = new SqlCommand(str, con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.DataSource = new BindingSource(dt, null);
                }
                textBox1.Text = "";
            }
        }
    }
}
