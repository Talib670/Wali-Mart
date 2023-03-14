using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
    public partial class ExpiryForm : Form
    {
        public ExpiryForm()
        {
            InitializeComponent();
        }

        private void ExpiryForm_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(DecHelper.ConnectionString);
            conn.Open();
            string str = " Select  *  FROM [ShopManage].[dbo].[tblproducts]";
            SqlCommand cmd = new SqlCommand(str, conn);
            SqlDataReader da = cmd.ExecuteReader();
            while (da.Read())
            {
                label1.Text = da[7].ToString();
                //pricetextBox.Text = da[2].ToString();
                // comboBox1.Text = da[1].ToString();
                //quantitylabel.Text = da[3].ToString();
                // purchasepricelabel.Text = da[6].ToString();
                // string exp = "Select * FROM [ShopManage].[dbo].[tblproducts] WHERE  [Expirydate] ";
                ///  string d = DateTime.Now.ToShortDateString();
                // if (d<exp)



                using (SqlConnection con = new SqlConnection((DecHelper.ConnectionString)))
                {
                    int t = 15;
                    ///String exp =(Convert.ToInt32(DateTime.Now.ToShortDateString() -Convert.ToInt32( 15)).ToString();

                    string exp = "Select  *  FROM [ShopManage].[dbo].[tblproducts] WHERE  [Expirydate] < date_sub(now(), interval 3 month)";
                    ///  string str = "Select* FROM[ShopManage].[dbo].[tblproducts] WHERE[Expirydate]<='" +exp+ "'";
                    ///  
                    // TimeSpan t = Convert.ToDateTime(str) - Convert.ToDateTime(DateTime.Now.ToShortDateString());
                    ///   if (Convert.ToInt32(exp) > Convert.ToInt32((t)))



                    SqlCommand cmdd = new SqlCommand(exp, con);
                    SqlDataAdapter das = new SqlDataAdapter(cmdd);
                    DataTable dt = new DataTable();
                    das.Fill(dt);

                    dataGridView1.DataSource = new BindingSource(dt, null);
                }
            }


        }

        private void ExpiryForm_Load_1(object sender, EventArgs e)
        {
          
            SqlConnection conn = new SqlConnection(DecHelper.ConnectionString);
            conn.Open();
            string str = " Select  *  FROM [ShopManage].[dbo].[tblproducts]";
            SqlCommand cmd = new SqlCommand(str, conn);
            SqlDataReader da = cmd.ExecuteReader();
            while (da.Read())
            {
               label2.Text = da[7].ToString();
                //pricetextBox.Text = da[2].ToString();
                // comboBox1.Text = da[1].ToString();
                //quantitylabel.Text = da[3].ToString();
                // purchasepricelabel.Text = da[6].ToString();
                // string exp = "Select * FROM [ShopManage].[dbo].[tblproducts] WHERE  [Expirydate] ";
                ///  string d = DateTime.Now.ToShortDateString();
                // if (d<exp)



                using (SqlConnection con = new SqlConnection((DecHelper.ConnectionString)))
                {
                   // int t = 15;
                    ///String exp =(Convert.ToInt32(DateTime.Now.ToShortDateString() -Convert.ToInt32( 15)).ToString();

                   /// string exp = "Select  *  FROM [ShopManage].[dbo].[tblproducts] WHERE  [Expirydate] < date_sub('"+DateTime.Now.ToShortDateString()+"', interval 3 month)";
                    ///  string str = "Select* FROM[ShopManage].[dbo].[tblproducts] WHERE[Expirydate]<='" +exp+ "'";
                    ///  
                    // TimeSpan t = Convert.ToDateTime(str) - Convert.ToDateTime(DateTime.Now.ToShortDateString());
                    ///   if (Convert.ToInt32(exp) > Convert.ToInt32((t)))



                    ///SqlCommand cmdd = new SqlCommand(exp, con);
                    //SqlDataAdapter das = new SqlDataAdapter(cmdd);
                    //DataTable dt = new DataTable();
                    //das.Fill(dt);

                    //dataGridView1.DataSource = new BindingSource(dt, null);
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            {
                using (SqlConnection con = new SqlConnection((DecHelper.ConnectionString)))
                {
                    // int t = 15;
                    ///String exp =(Convert.ToInt32(DateTime.Now.ToShortDateString() -Convert.ToInt32( 15)).ToString();

                    /// string exp = "Select  *  FROM [ShopManage].[dbo].[tblproducts] WHERE  [Expirydate] < date_sub('"+DateTime.Now.ToShortDateString()+"', interval 3 month)";
                      string str = "select * FROM [ShopManage].[dbo].[tblproductsexpiry] where DATEDIFF(day, GETDATE(), [Expirydate]) <= 15  AND [Expirydate]>'" + DateTime.Now.ToShortDateString()+"' ";
                    ///  
                    // TimeSpan t = Convert.ToDateTime(str) - Convert.ToDateTime(DateTime.Now.ToShortDateString());
                    ///   if (Convert.ToInt32(exp) > Convert.ToInt32((t)))



                    SqlCommand cmdd = new SqlCommand(str, con);
                   SqlDataAdapter das = new SqlDataAdapter(cmdd);
                    DataTable dt = new DataTable();
                    das.Fill(dt);

                    dataGridView2.DataSource = new BindingSource(dt, null);
                }
                {

                }
                {
                    //var now = DateTime.Now;
                    //var expirationDate = DateTime.Parse(.Cells[7].Value.ToString());
                    //var TwentyOneDays = expirationDate.AddDays(-21);

                    //var TenDays = expirationDate.AddDays(-10);

                    //if (now > TwentyOneDays && now < expirationDate)
                    //{
                    //    row.DefaultCellStyle.BackColor = Color.LightSkyBlue;
                    //    row.Cells[2].Style.BackColor = Color.Yellow;

                    //    .....
                    //}
                    //c#
                }
            }
            /// {
            //   Try
            /// using (SqlConnection con = new SqlConnection((DecHelper.ConnectionString)))
            /// {
            ///      cmd.CommandText = "select * from medicine where expiry_date < date_sub(now(), interval 3 month)"
            ///dr = cmd.ExecuteReader
            ///count = 0
            //// While dr.Read
            /// count = count + 1
            //// While
            ///If count = 1 Then
            //// pop.Image = Image.FromFile("E:\asasda.png")
            /// pop.TitleText = "Notification Alert!!!"
            ///  pop.ContentText = "Medicine at Risk"
            ///  pop.AnimationDuration = 3000
            /// pop.Popup()
            ///Else
            // pop.Image = Image.FromFile("E:\asasda.png")
            ///pop.TitleText = "Notification Alert!!!"
            ///pop.ContentText = "No items for risk"
            ///pop.AnimationDuration = 3000
            /// pop.Popup()




            //     }
            /// }
            // string exp = "Select  * [Expirydate]  FROM [ShopManage].[dbo].[tblproducts] ";
            ///  var t = exp.ToString();
            // var ValidToDate = new DateTime(); // this date is just an example
            // var expiriesInDays = (int)(ValidToDate - DateTime.Now).TotalDays; // calculate remaining days
            /// if (expiriesInDays <= 30) // you can change the expression to equals if you just want show this message for the specific day when there are 30 days left
            /// {
            ///  MessageBox.Show($"Your subscription will end in {expiriesInDays} days");
            ///}
            ///  string d1 = DateTime.Today.ToString("yyyy-MM-dd");
            /// string d2 = DateTime.Now.AddDays(15).ToString("yyyy-MM-dd");
            //  string constr = ConfigurationManager.AppSettings("DEFAULT_PATH").ToString();
            /// SqlConnection con =  new SqlConnection(DecHelper.ConnectionString);
            // string sql = "SELECT COUNT ([Products]) FROM [ShopManage].[dbo].[tblproducts]  WHERE [Expirydate]>='" + d1 + "' and [Expirydate]<='" + d2 + "'";
            //con.Open();
            //SqlCommand cmd = new SqlCommand(sql, con);
            ///int temp = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            /// label1.Text = (temp).ToString();
            ///  con.Close();
            ///if ((temp > 0))
            /// {
            // SqlConnection con = new SqlConnection((DecHelper.ConnectionString))
            // gvpuc.Visible = true;
            ///    DataTable dt = new DataTable();
            /// string constr1 = ConfigurationManager.AppSettings("DEFAULT_PATH").ToString();
            /// SqlConnection con1 = new SqlConnection(DecHelper.ConnectionString);
            ///string sql1 = " Select  *  FROM [ShopManage].[dbo].[tblproducts] WHERE  [Expirydate] >='" + d1 + "' and [Expirydate]<='" + d2 + "'";
            ////SqlCommand cmd1 = new SqlCommand(sql1, con1);
            ///con1.Open();
            ///SqlDataAdapter da = new SqlDataAdapter(cmd1);
            ///DataTable dtt = new DataTable();
            ///da.Fill(dtt);

            ///dataGridView1.DataSource = new BindingSource(dt, null);

            /// lblmsg.Text = "PUC Due to Expire.";

            // else
            /// {
            ///   gvpuc.Visible = false;
            //lblmsg.Visible = true;
            /// lblmsg.Text = "No PUC that are Due to Expire.";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DateTime expdate = Convert.ToDateTime(label2.Text);
            DateTime crtdate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            TimeSpan t = expdate - crtdate;
            double ncrt = t.TotalDays;
            label3.Text = ncrt.ToString();
            if (ncrt<4)
            {
                MessageBox.Show("Product Expire");
            }
        }
    }
}


      ///  private void button1_Click(object sender, EventArgs e)
      //  {
           /// {
             //   Try
    /// using (SqlConnection con = new SqlConnection((DecHelper.ConnectionString)))
              /// {
              ///      cmd.CommandText = "select * from medicine where expiry_date < date_sub(now(), interval 3 month)"
    ///dr = cmd.ExecuteReader
    ///count = 0
   //// While dr.Read
       /// count = count + 1
    //// While
    ///If count = 1 Then
       //// pop.Image = Image.FromFile("E:\asasda.png")
       /// pop.TitleText = "Notification Alert!!!"
      ///  pop.ContentText = "Medicine at Risk"
      ///  pop.AnimationDuration = 3000
       /// pop.Popup()
    ///Else
       // pop.Image = Image.FromFile("E:\asasda.png")
        ///pop.TitleText = "Notification Alert!!!"
        ///pop.ContentText = "No items for risk"
        ///pop.AnimationDuration = 3000
       /// pop.Popup()
   



                   //     }
           /// }
           // string exp = "Select  * [Expirydate]  FROM [ShopManage].[dbo].[tblproducts] ";
          ///  var t = exp.ToString();
           // var ValidToDate = new DateTime(); // this date is just an example
           // var expiriesInDays = (int)(ValidToDate - DateTime.Now).TotalDays; // calculate remaining days
           /// if (expiriesInDays <= 30) // you can change the expression to equals if you just want show this message for the specific day when there are 30 days left
           /// {
              ///  MessageBox.Show($"Your subscription will end in {expiriesInDays} days");
            ///}
            ///  string d1 = DateTime.Today.ToString("yyyy-MM-dd");
            /// string d2 = DateTime.Now.AddDays(15).ToString("yyyy-MM-dd");
            //  string constr = ConfigurationManager.AppSettings("DEFAULT_PATH").ToString();
            /// SqlConnection con =  new SqlConnection(DecHelper.ConnectionString);
            // string sql = "SELECT COUNT ([Products]) FROM [ShopManage].[dbo].[tblproducts]  WHERE [Expirydate]>='" + d1 + "' and [Expirydate]<='" + d2 + "'";
            //con.Open();
            //SqlCommand cmd = new SqlCommand(sql, con);
            ///int temp = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            /// label1.Text = (temp).ToString();
            ///  con.Close();
            ///if ((temp > 0))
            /// {
            // SqlConnection con = new SqlConnection((DecHelper.ConnectionString))
            // gvpuc.Visible = true;
            ///    DataTable dt = new DataTable();
            /// string constr1 = ConfigurationManager.AppSettings("DEFAULT_PATH").ToString();
            /// SqlConnection con1 = new SqlConnection(DecHelper.ConnectionString);
            ///string sql1 = " Select  *  FROM [ShopManage].[dbo].[tblproducts] WHERE  [Expirydate] >='" + d1 + "' and [Expirydate]<='" + d2 + "'";
            ////SqlCommand cmd1 = new SqlCommand(sql1, con1);
            ///con1.Open();
            ///SqlDataAdapter da = new SqlDataAdapter(cmd1);
            ///DataTable dtt = new DataTable();
            ///da.Fill(dtt);

            ///dataGridView1.DataSource = new BindingSource(dt, null);
        
           /// lblmsg.Text = "PUC Due to Expire.";
            
           // else
           /// {
             ///   gvpuc.Visible = false;
                //lblmsg.Visible = true;
               /// lblmsg.Text = "No PUC that are Due to Expire.";
           
       
    

