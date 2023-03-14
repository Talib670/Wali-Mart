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
//using ShopMnagementSystem.Models;
using ShopMnagementSystem.Screens.Accounts.Company_Accounts;

namespace ShopMnagementSystem.Screens.Accounts
{
    public partial class CompanyAccountsForm : Form
    {
        DataClasses1DataContext d = new DataClasses1DataContext();
        DataClasses15DataContext db = new DataClasses15DataContext();
        public CompanyAccountsForm()
        {
            InitializeComponent();
        }
        public static string NumberToWord(int numbers)
        {
            if (numbers == 0) return "Zero";
            if (numbers < 0) return "Minus" + NumberToWord(Math.Abs(numbers));
            string words = "";
            if ((numbers / 1000000) > 0)

            {
                words += NumberToWord(numbers / 1000000) + " Millions ";
                numbers %= 1000000;

            }
            if ((numbers / 100000) > 0)
            {
                words += NumberToWord(numbers / 100000) + " Lac ";
                numbers %= 100000;

            }
            if ((numbers / 1000) > 0)
            {
                words += NumberToWord(numbers / 1000) + " Thousands ";
                numbers %= 1000;

            }
            if ((numbers / 100) > 0)
            {
                words += NumberToWord(numbers / 100) + " Hundreds ";
                numbers %= 100;

            }
            if (numbers > 0)
            {
                if (words != "") words += " AND ";
                var unitsmap = new[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Ninteen" };
                var tenmap = new[] { "Zero", "Ten", "Twenty", "Thirty", "Fourty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninty" };
                if (numbers < 20) words += unitsmap[numbers];
                else
                {
                    words += tenmap[numbers / 10];
                    if ((numbers % 10) > 0) words += "-" + unitsmap[numbers % 10];

                }


            }
            return words;
        }

        private void CompanyAccountsForm_Load(object sender, EventArgs e)
        {
            {
                SqlConnection conn = new SqlConnection(DecHelper.ConnectionString);
                conn.Open();
                string strrr = "  Select  DISTINCT [Catagary] From [ShopManage].[dbo].[tblproducts]";
                SqlCommand cmdddd = new SqlCommand(strrr, conn);
                SqlDataReader da = cmdddd.ExecuteReader();
                while (da.Read())
                {
                    catagorytextBox.Items.Add(da[0].ToString()
                                       );
                }
                        }
                total.Visible = false;
            label8.Visible = false;
            quantitylbl.Visible = false;
            dataGridView1.Visible = false;
            {
                SqlConnection conn = new SqlConnection(DecHelper.ConnectionString);
                conn.Open();
                string strrr = " SELECT * FROM [ShopManage].[dbo].[tbltotalsale]";
                SqlCommand cmddd = new SqlCommand(strrr, conn);
                SqlDataReader da = cmddd.ExecuteReader();
                while (da.Read())
                {

                    purcasetotllabel16.Text = da[5].ToString(); ;
                }
            }
                {
                SqlConnection conn = new SqlConnection(DecHelper.ConnectionString);
                conn.Open();
                string strrr = " SELECT *  FROM [ShopManage].[dbo].[companybqayaamount]";
                SqlCommand cmddd = new SqlCommand(strrr, conn);
                SqlDataReader da = cmddd.ExecuteReader();
                while (da.Read())
                {

                    comboBox1.Items.Add(da[1].ToString());
                }

            }
        }

        private void bqayatextBox1_TextChanged(object sender, EventArgs e)
        {
            //label15.Text = NumberToWord(Convert.ToInt32(bqayatextBox1.Text));
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void nametextBox2_TextChanged(object sender, EventArgs e)
        {
            //try
            //{

            //    if (nametextBox2.Text.Length > 0)
            //    {
            //        bqayatextBox1.Text = (Convert.ToDouble(grandtotal.Text) + Convert.ToDouble(jummatextBox.Text) - Convert.ToDouble(nametextBox2.Text)).ToString();

            //    }
            //}
            //catch (Exception)
            //{

            //    MessageBox.Show("Please Select Digital Values as 123..!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            try
            {


                if (nametextBox2.Text.Length > 0)
                {
                    bqayatextBox1.Text = (Convert.ToDecimal(label8.Text) + Convert.
                           ToDecimal(nametextBox2.Text)).ToString();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Please Select Digital Values as 123..!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void jummatextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            {
                /// string product = "Others";
                SqlConnection conn = new SqlConnection(DecHelper.ConnectionString);
                conn.Open();
                string str = "  Select * From [ShopManage].[dbo].[tblproducts] WHERE  Barcode= '" + barcodetextBox2.Text + "'";
                SqlCommand cmd = new SqlCommand(str, conn);
                SqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {
                    producthnametextBox.Text = da[1].ToString();
                    catagorytextBox.Text = da[4].ToString();
                    pricetextBox.Text = da[2].ToString();
                    //comboBox1.Text = da[1].ToString();
                    quantitylbl.Text = da[3].ToString();
                    buytextBox1.Text = da[6].ToString();
                    ///  comboBox1.Items.Add(da[0].ToString()
                    //  );
                }
                //  comboBox1.Items.Add("Small");
                //comboBox1.Items.Add("Mediam");
                //comboBox1.Items.Add("Full Size");


            }
            }
       
       

        private void newRecordtoolStripButton_Click(object sender, EventArgs e)
        {

            {
                var reg = producthnametextBox.Text;
                var barcode = barcodetextBox2.Text;
                var dc = d.tblproducts.Where(o => o.Products == reg).FirstOrDefault();
                var db = d.tblproducts.Where(o => o.Barcode == barcode).FirstOrDefault();


                if (dc != null || db != null)
                {
                    decimal quantity = Convert.ToDecimal(quantitylbl.Text) + Convert.ToDecimal(quantitytextBox.Text);

                    SqlConnection con = new SqlConnection(DecHelper.ConnectionString);
                    con.Open();
                    //StudentB s = new StudentB();
                    //MemoryStream ms = new MemoryStream();
                    //i.Save(ms, ImageFormat.Jpeg);
                    //byte[] arrrrr = ms.ToArray();

                    string str = @" UPDATE [ShopManage].[dbo].[tblproducts]
SET  [Price] = '" + pricetextBox.Text + "', [Quantity] = '" + quantity + "',  [Catagary] ='" + catagorytextBox.Text + "' ,  [Buy Price] ='" + buytextBox1.Text + "' ,  [Company Name] ='" + comboBox1.Text + "'  WHERE ([Barcode] = '" + barcodetextBox2.Text + "')";

                    SqlCommand cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();

                    con.Close();
                }
              
            
           
                else
                {
                    {
                        tblproduct t = new tblproduct();
                        t.Company_Name = comboBox1.Text;
                        t.Products = producthnametextBox.Text;
                        t.Price = pricetextBox.Text;
                        t.Quantity = quantitytextBox.Text;
                        t.Catagary = catagorytextBox.Text;
                        t.Barcode = barcodetextBox2.Text;
                        t.Buy_Price = buytextBox1.Text;
                        t.Company_Name = comboBox1.Text;
                        //  t.Expirydate = Convert.ToDateTime(dateTimePicker1.Value);
                        d.tblproducts.InsertOnSubmit(t);
                        d.SubmitChanges();
                        //  MessageBox.Show("Products Record Save SuccessFully...!!!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
        
            {

                    DataClasses15DataContext ds = new DataClasses15DataContext();
                    tblproductsexpiry t = new tblproductsexpiry();
                   
                t.Products = producthnametextBox.Text;
                t.Price = pricetextBox.Text;
                t.Quantity = quantitytextBox.Text;
                t.Catagary = catagorytextBox.Text;
                t.Barcode = barcodetextBox2.Text;
                t.Buy_Price = buytextBox1.Text;
                 t.Expirydate = Convert.ToDateTime(dateTimePicker1.Value);
                ds.tblproductsexpiries.InsertOnSubmit(t);
                ds.SubmitChanges();
               // MessageBox.Show("Products Record Save SuccessFully...!!!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
                {
                    DataClasses18DataContext dd = new DataClasses18DataContext();
                    tblcompanyaccount tc = new tblcompanyaccount();
                    tc.Date = Convert .ToDateTime(DateTime.Now.ToString());
                    tc.Company_Name = comboBox1.Text;
                    tc.Product_Name = producthnametextBox.Text;
                    tc.Buy_Price = buytextBox1.Text;
                    tc.Qunatity = quantitytextBox.Text;
                    tc.Name_Amount = nametextBox2.Text;
                    tc.Juma_Amount = jummatextBox.Text;
                    tc.Bqaya_Amount = bqayatextBox1.Text;
                    dd.tblcompanyaccounts.InsertOnSubmit(tc);
                    dd.SubmitChanges();
                    MessageBox.Show("Products Record Save SuccessFully...!!!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                {
                    {
                        SqlConnection conn = new SqlConnection(DecHelper.ConnectionString);
                        conn.Open();
                        //StudentB s = new StudentB();
                        //MemoryStream ms = new MemoryStream();
                        //i.Save(ms, ImageFormat.Jpeg);
                        //byte[] arrrrr = ms.ToArray();

                        string str = @" UPDATE [ShopManage].[dbo].[companybqayaamount]
SET [bqayaamount]= '" + bqayatextBox1.Text + "'  WHERE [namecompany] = '" + comboBox1.Text + "'";

                        SqlCommand cmd = new SqlCommand(str, conn);
                        cmd.ExecuteNonQuery();

                        conn.Close();

                    }
                }
                {

                    double totalp = Convert.ToDouble((Convert.ToDouble(purcasetotllabel16.Text) + Convert.ToDouble(nametextBox2.Text)));
                    // double total = Convert.ToDouble(RecieptNo.Text) + Convert.ToDouble(quantytextBox.Text);
                    SqlConnection con = new SqlConnection(DecHelper.ConnectionString);
                    con.Open();
                    //StudentB s = new StudentB();
                    //MemoryStream ms = new MemoryStream();
                    //i.Save(ms, ImageFormat.Jpeg);
                    //byte[] arrrrr = ms.ToArray();
                    // string strr = @" UPDATE [ShopManage].[dbo].[tbltotalsale]
                    //SET [totalsale] = '" + total + "', [datetime] = '" + DateTime.Now.ToShortDateString() + "' WHERE ([datetime] = '" + DateTime.Now.ToShortDateString() + "')";

                    string str = @" UPDATE [ShopManage].[dbo].[tbltotalsale]
SET [Totalpurchase]= '" + totalp + "'  WHERE [datetime] = '" + DateTime.Now.ToShortDateString() + "'";

                    SqlCommand cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();

                    con.Close();
                }
                total.Visible = false;
                label8.Visible = false;
                quantitylbl.Visible = false;
                {
                    SqlConnection conn = new SqlConnection(DecHelper.ConnectionString);
                    conn.Open();
                    string strrr = " SELECT * FROM [ShopManage].[dbo].[tbltotalsale]";
                    SqlCommand cmddd = new SqlCommand(strrr, conn);
                    SqlDataReader da = cmddd.ExecuteReader();
                    while (da.Read())
                    {

                        purcasetotllabel16.Text = da[5].ToString(); ;
                    }
                }
                {
                    {
                        SqlConnection conn = new SqlConnection(DecHelper.ConnectionString);
                        conn.Open();
                        string str = "  Select * FROM [ShopManage].[dbo].[companybqayaamount] WHERE  [namecompany]= '" + comboBox1.Text + "'";
                        SqlCommand cmd = new SqlCommand(str, conn);
                        SqlDataReader da = cmd.ExecuteReader();
                        while (da.Read())
                        {
                            label8.Text = da[2].ToString();
                            //  purchasepricelabel.Text = da[6].ToString();
                        }
                    }
                }

        }
        }
        private bool recordexist()
        {
            var reg = producthnametextBox.Text;
            var barcode = barcodetextBox2.Text;
            var dc = d.tblproducts.Where(o => o.Products == reg).FirstOrDefault();
            var db = d.tblproducts.Where(o => o.Barcode == barcode).FirstOrDefault();


            if (dc != null || db != null)
            {
                MessageBox.Show("Product Record Already Exist!!!!!..... Please Update .  ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;


            }
            return true;
        }

        private void producthnametextBox_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            try
            {

                {
                    using (SqlConnection con = new SqlConnection((DecHelper.ConnectionString)))
                    {

                        string str = "Select * FROM [ShopManage].[dbo].[tblproducts] WHERE [Products] LIKE '%" + producthnametextBox.Text + "%' OR [Price] LIKE '%" + producthnametextBox.Text + "%' OR [Barcode] LIKE '%" + producthnametextBox.Text + "%'  OR [Buy Price] LIKE '%" + producthnametextBox.Text + "%' ";
                        SqlCommand cmd = new SqlCommand(str, con);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dataGridView1.DataSource = new BindingSource(dt, null);
                    }

                }
                }
                 catch (Exception)
            {


            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            barcodetextBox2.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            
            dataGridView1.Visible = false;
        }

        private void producthnametextBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            {
                SqlConnection conn = new SqlConnection(DecHelper.ConnectionString);
                conn.Open();
                string str = "  Select * From [ShopManage].[dbo].[tblproducts] WHERE  [Products]= '" + producthnametextBox.Text + "'";
                SqlCommand cmd = new SqlCommand(str, conn);
                SqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {
                    quantitylbl.Text = da[3].ToString();
                    buytextBox1.Text = da[6].ToString();
                }
            }
    }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            barcodetextBox2.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();

            dataGridView1.Visible = false;
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void producthnametextBox_TextChanged_1(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            try
            {

                {
                    using (SqlConnection con = new SqlConnection((DecHelper.ConnectionString)))
                    {

                        string str = "Select * FROM [ShopManage].[dbo].[tblproducts] WHERE [Products] LIKE '%" + producthnametextBox.Text + "%' OR [Price] LIKE '%" + producthnametextBox.Text + "%' OR [Barcode] LIKE '%" + producthnametextBox.Text + "%'  OR [Buy Price] LIKE '%" + producthnametextBox.Text + "%' ";
                        SqlCommand cmd = new SqlCommand(str, con);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dataGridView1.DataSource = new BindingSource(dt, null);
                    }

                }
            }
            catch (Exception)
            {


            }
        }

        private void quantitytextBox_TextChanged(object sender, EventArgs e)
        {
            if (quantitytextBox.Text !=string.Empty)
            {

            
            nametextBox2.Text = (Convert.ToDecimal(buytextBox1.Text) * Convert.ToDecimal(quantitytextBox.Text)).ToString();
        }
    }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            {
                SqlConnection conn = new SqlConnection(DecHelper.ConnectionString);
                conn.Open();
                string str = "  Select * FROM [ShopManage].[dbo].[companybqayaamount] WHERE  [namecompany]= '" + comboBox1.Text + "'";
                SqlCommand cmd = new SqlCommand(str, conn);
                SqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {
                    label8.Text = da[2].ToString();
                    //  purchasepricelabel.Text = da[6].ToString();
                }
            }
            {
               producthnametextBox.Items.Clear();
                SqlConnection conn = new SqlConnection(DecHelper.ConnectionString);
                conn.Open();
                string str = "  Select  * From [ShopManage].[dbo].[tblproducts] WHERE  [Company Name]= '" + comboBox1.Text + "'";
                SqlCommand cmd = new SqlCommand(str, conn);
                SqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {

                    producthnametextBox.Items.Add(da[1].ToString());
                }
            }

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            newcmpacForm1 nc = new newcmpacForm1();
            nc.ShowDialog();
        }

        private void catagorytextBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            reportForm1 rf = new reportForm1();
            rf.ShowDialog();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            ExpireForm1 ef = new ExpireForm1();
            ef.ShowDialog();
        }

        private void closetoolStripButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    }
    
