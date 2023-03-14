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

namespace ShopMnagementSystem.Screens
{
    public partial class ManageReports : Form
    {
        DataClasses1DataContext d = new DataClasses1DataContext();
        public ManageReports()
        {
            InitializeComponent();
        }

        private void resettoolStripButton_Click(object sender, EventArgs e)
        {
          
            
            using (SqlConnection con = new SqlConnection((DecHelper.ConnectionString)))
            {

              string strr = "Select * FROM [ShopManage].[dbo].[tblproducts] WHERE  [Quantity] <=10";
              string str = "SELECT * FROM [ShopManage].[dbo].[tblproducts] Where  ,(Case When Isnumeric([Quantity])>=4 ";
               
                SqlCommand cmd = new SqlCommand(str, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = new BindingSource(dt, null);
            }
            }

        private void closetoolStripButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ManageReports_Load(object sender, EventArgs e)
        {

            using (SqlConnection con = new SqlConnection((DecHelper.ConnectionString)))
            {
                double crit = Convert.ToDouble(4);
                string str = "Select * FROM [ShopManage].[dbo].[tblproducts] WHERE  [Quantity] <='"+crit+"'";
                SqlCommand cmd = new SqlCommand(str, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = new BindingSource(dt, null);
            }
          
          //  System.Data.SqlClient.SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection(DecHelper.ConnectionString);

          //  sqlConnection.Open();
           // System.Data.SqlClient.SqlCommand sqlCommand = new System.Data.SqlClient.SqlCommand("SELECT COUNT(*)  FROM [ShopManage].[dbo].[tblproducts] WHERE [Quantity] <=4");
           // sqlCommand.Connection = sqlConnection;

          //label1.Text = (Convert.ToSByte(sqlCommand.ExecuteScalar())).ToString();

        }

        private void SaveRecordtoolStripButton_Click(object sender, EventArgs e)
        {
            SoldReportForm mp = new SoldReportForm();
            mp.ShowDialog();
        }
    }
}
