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

namespace ShopMnagementSystem.Screens.Accounts.Company_Accounts
{
    public partial class reportForm1 : Form
    {
        DataClasses18DataContext d = new DataClasses18DataContext();
        public reportForm1()
        {
            InitializeComponent();
        }

        private void reportForm1_Load(object sender, EventArgs e)
        {
            var a = d.tblcompanyaccounts.ToList();
            dataGridView1.DataSource = a;
        }

        private void searchbutton_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection((DecHelper.ConnectionString)))
            {
                string str = "Select * FROM [ShopManage].[dbo].[tblSoldProduct] WHERE  [Date] ='" + dateTimePicker1.Text + "'";
                string strr = "Select * FROM [ShopManage].[dbo].[tblcompanyaccount] WHERE  [Date] >='" + dateTimePicker2.Text + "' And [Date] <= '" + dateTimePicker1.Text + "'";
                SqlCommand cmd = new SqlCommand(strr, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = new BindingSource(dt, null);
            }
        }
    }
}
