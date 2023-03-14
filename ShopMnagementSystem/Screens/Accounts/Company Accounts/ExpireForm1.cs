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
    public partial class ExpireForm1 : Form
    {
        public ExpireForm1()
        {
            InitializeComponent();
        }

        private void ExpireForm1_Load(object sender, EventArgs e)
        {
            {
                using (SqlConnection con = new SqlConnection((DecHelper.ConnectionString)))
                {
                    // int t = 15;
                    ///String exp =(Convert.ToInt32(DateTime.Now.ToShortDateString() -Convert.ToInt32( 15)).ToString();

                    /// string exp = "Select  *  FROM [ShopManage].[dbo].[tblproducts] WHERE  [Expirydate] < date_sub('"+DateTime.Now.ToShortDateString()+"', interval 3 month)";
                    string str = "select * FROM [ShopManage].[dbo].[tblproductsexpiry] where DATEDIFF(day, GETDATE(), [Expirydate]) <= 15  AND [Expirydate]>'" + DateTime.Now.ToShortDateString() + "' ";
                    ///  
                    // TimeSpan t = Convert.ToDateTime(str) - Convert.ToDateTime(DateTime.Now.ToShortDateString());
                    ///   if (Convert.ToInt32(exp) > Convert.ToInt32((t)))



                    SqlCommand cmdd = new SqlCommand(str, con);
                    SqlDataAdapter das = new SqlDataAdapter(cmdd);
                    DataTable dt = new DataTable();
                    das.Fill(dt);

                    dataGridView1.DataSource = new BindingSource(dt, null);
                }
            }
        }

        private void closetoolStripButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void deletetoolStripButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do You Want Delete Product Record....!!!!", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
            {
             
                {
                    DataClasses15DataContext d = new DataClasses15DataContext();

                    int tid = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                    tblproductsexpiry item = d.tblproductsexpiries.Where(o => o.id == tid).FirstOrDefault();
                    d.tblproductsexpiries.DeleteOnSubmit(item);

                    d.SubmitChanges();
                    MessageBox.Show("Product Record Delete SuccessFully....!!!!", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    var list = d.tblproductsexpiries.ToList();
                    dataGridView1.DataSource = list;
                }

            }

        }
    }
}
