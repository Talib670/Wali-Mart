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
namespace ShopMnagementSystem.Screens.Accounts.Clients_Accounts
{
    public partial class newclientreportForm : Form
    {
        DataClasses13DataContext d = new DataClasses13DataContext();
        public newclientreportForm()
        {
            InitializeComponent();
        }

        private void newclientreportForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = d.tblclientdetails.ToList();
        }

        private void searchbutton_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == " ")
            {
                MessageBox.Show("Please Enter Valid Client  Name OR Father Name OR  Address....!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                using (SqlConnection con = new SqlConnection((DecHelper.ConnectionString)))
                {

                    string str = "Select *  FROM [ShopManage].[dbo].[tblclientdetail] WHERE [Name] LIKE '%" + textBox1.Text + "%' OR [Father Name] LIKE '%" + textBox1.Text + "%' OR [CNIC] LIKE '%" + textBox1.Text + "%' OR [Phone No]LIKE '%" + textBox1.Text + "%' OR [Adress] LIKE '%" + textBox1.Text + "%'";
                    SqlCommand cmd = new SqlCommand(str, con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.DataSource = new BindingSource(dt, null);
                }
                textBox1.Text = "";
            }
    }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }

