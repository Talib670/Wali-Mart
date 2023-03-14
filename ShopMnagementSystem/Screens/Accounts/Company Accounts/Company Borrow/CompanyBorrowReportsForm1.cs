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

namespace ShopMnagementSystem.Screens.Accounts.Company_Accounts.Company_Borrow
{
    public partial class CompanyBorrowReportsForm1 : Form
    {
        public CompanyBorrowReportsForm1()
        {
            InitializeComponent();
        }

        private void CompanyBorrowReportsForm1_Load(object sender, EventArgs e)
        {
            DataClasses19DataContext d = new DataClasses19DataContext();

            dataGridView1.DataSource = d.companybarrows.ToList();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == " ")
            {
                MessageBox.Show("Please Enter Valid Company Name....!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                using (SqlConnection con = new SqlConnection((DecHelper.ConnectionString)))
                {

                    string str = "Select *  FROM [ShopManage].[dbo].[companybarrow] WHERE [Date] LIKE '%" + textBox1.Text + "%' OR [Company Name] LIKE '%" + textBox1.Text + "%'";
                    SqlCommand cmd = new SqlCommand(str, con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.DataSource = new BindingSource(dt, null);
                }
               // textBox1.Text = "";
            }
        }
    }
}
