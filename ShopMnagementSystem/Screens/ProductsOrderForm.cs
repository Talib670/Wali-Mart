using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShopMnagementSystem.Models;
using ShopMnagementSystem.Screens;

namespace ShopMnagementSystem
{
    public partial class Form1 : Form
    {
        DataClasses1DataContext d = new DataClasses1DataContext();
        DataClasses3DataContext db = new DataClasses3DataContext();

        public Form1()
        {
            InitializeComponent();
        }
        private List<cartitem> shopingcart = new List<cartitem>();
        private int numbersofitemsperpage = 0;
        private int numbersofitemsprintsofar = 0;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            {
                SqlConnection conn = new SqlConnection(DecHelper.ConnectionString);
                conn.Open();
                string str = "  Select * From [ShopManage].[dbo].[tblproducts] WHERE  [Products]= '" + comboBox1.Text + "'";
                SqlCommand cmd = new SqlCommand(str, conn);
                SqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {
                    quantitylabel.Text = da[3].ToString();
                    purchasepricelabel.Text = da[6].ToString();
                }
            }

            {


                string price = comboBox1.Text;
                SqlConnection conn = new SqlConnection(DecHelper.ConnectionString);
                conn.Open();
                string str = "  Select * From [ShopManage].[dbo].[tblproducts] WHERE  [Products]= '" + price + "'";
                SqlCommand cmd = new SqlCommand(str, conn);
                SqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {
                    pricetextBox.Text = da[2].ToString();
                }
            }

            ///  var cold = d.tblproducts.ToList();
            ////  if (comboBox1.SelectedItem.ToString()=="Coca Cola")
            ///    {
            ///     foreach (var i in cold)
            ///  {
            ///  pricetextBox.Text= i.Price;
            //}
            ///}
            ///


        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

            string product = "Cold Drinks";
            radioButton1.ForeColor = System.Drawing.Color.Red;
            nimkoradioButton.ForeColor = System.Drawing.Color.Green;

            comboBox1.Items.Clear();



            {
                SqlConnection conn = new SqlConnection(DecHelper.ConnectionString);
                conn.Open();
                string str = "  Select * From [ShopManage].[dbo].[tblproducts] WHERE  [Catagary]= '" + product + "'";
                SqlCommand cmd = new SqlCommand(str, conn);
                SqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {
                    comboBox1.Items.Add(da[1].ToString()
                                       );
                }

                ///foreach (var item in products)
                /// {
                //  comboBox1.Items.Add(item.Catagary.Where());
                //}


                //dc.StudentAttendences.Where(x => x.RegNo == tid).ToList()
            }
        }
        private void nimkoradioButton_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1.ForeColor = System.Drawing.Color.Green;
            nimkoradioButton.ForeColor = System.Drawing.Color.Red;

            comboBox1.Items.Clear();

            {
                string product = "Others";
                SqlConnection conn = new SqlConnection(DecHelper.ConnectionString);
                conn.Open();
                string str = "  Select * From [ShopManage].[dbo].[tblproducts] WHERE  [Catagary]= '" + product + "'";
                SqlCommand cmd = new SqlCommand(str, conn);
                SqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {
                    comboBox1.Items.Add(da[1].ToString()
                                       );
                }
                //  comboBox1.Items.Add("Small");
                //comboBox1.Items.Add("Mediam");
                //comboBox1.Items.Add("Full Size");

            }
        }

        private void quantytextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {



                if (quantytextBox.Text.Length > 0)
                {


                    totaltextBox.Text = (Convert.ToDecimal(quantytextBox.Text) * Convert.
                       ToDecimal(pricetextBox.Text)).ToString();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Please Select Digital Values as 123..!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void additembutton_Click(object sender, EventArgs e)
        {
                    try
            {
               /// barcodetextBox2.Focus();


            //  if (IsFormValid())
                {
                    {
                        cartitem item = new cartitem()
                        {
                         ProductName = comboBox1.Text,
                            Quantity =Convert.ToDecimal( quantytextBox.Text),
                            Price =Convert.ToDecimal(pricetextBox.Text),
                            Total = Convert.ToDecimal(totaltextBox.Text),
                            
                        };
                        shopingcart.Add(item);
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = shopingcart;
                    }
                    {
                        counterproducts.Text = (Convert.ToDouble(counterproducts.Text) +Convert.ToDouble( quantytextBox.Text)).ToString();
                        double total = Convert.ToDouble(quantitylabel.Text) - Convert.ToDouble(quantytextBox.Text);
                        SqlConnection con = new SqlConnection(DecHelper.ConnectionString);
                        con.Open();
                        //StudentB s = new StudentB();
                        //MemoryStream ms = new MemoryStream();
                        //i.Save(ms, ImageFormat.Jpeg);
                        //byte[] arrrrr = ms.ToArray();

                        string str = @" UPDATE [ShopManage].[dbo].[tblproducts]
SET [Quantity] = '" + total + "' WHERE ([Products] = '" + comboBox1.Text + "')";

                        SqlCommand cmd = new SqlCommand(str, con);
                        cmd.ExecuteNonQuery();

                        con.Close();
                    }
                    {
                        SqlConnection conn = new SqlConnection(DecHelper.ConnectionString);
                        conn.Open();
                        string str = "  Select  [Quantity] From [ShopManage].[dbo].[tblproducts] WHERE  [Products]= '" + comboBox1.Text + "'";
                        SqlCommand cmd = new SqlCommand(str, conn);
                        SqlDataReader da = cmd.ExecuteReader();
                        while (da.Read())
                        {
                            quantitylabel.Text = da[0].ToString();
                        }
                    }
                    {
                        double totalprofit = Convert.ToDouble(pricetextBox.Text) - Convert.ToDouble(purchasepricelabel.Text);
                        double pro = totalprofit * Convert.ToDouble(quantytextBox.Text);
                        profitlabel.Text = (Convert.ToDouble(profitlabel.Text) + pro).ToString();
                        double total = Convert.ToDouble(quantitylabel.Text) - Convert.ToDouble(quantytextBox.Text);
                        SqlConnection con = new SqlConnection(DecHelper.ConnectionString);
                        con.Open();
                        //StudentB s = new StudentB();
                        //MemoryStream ms = new MemoryStream();
                        //i.Save(ms, ImageFormat.Jpeg);
                        //byte[] arrrrr = ms.ToArray();

                        string str = @" UPDATE [ShopManage].[dbo].[tbltotalsale]
SET [Profit] = '" + profitlabel.Text + "' WHERE ([datetime] = '" + DateTime.Now.ToShortDateString() + "')";

                        SqlCommand cmd = new SqlCommand(str, con);
                        cmd.ExecuteNonQuery();

                        con.Close();
                    }
                    // {
                    ///   tblSoldProduct ts = new tblSoldProduct();
                    //ts.Product_Name = comboBox1.Text;
                    //ts.Price = pricetextBox.Text;
                    //ts.Quantity = quantytextBox.Text;
                    ///ts.Grand_Price = totaltextBox.Text;
                    // ts.Date =Convert.ToDateTime( DateTime.Now.ToShortDateString());
                    //db.tblSoldProducts.InsertOnSubmit(ts);
                    //db.SubmitChanges();
                    //}


                    subtotaltextBox.Text = (Convert.ToDouble(totaltextBox.Text) + Convert.ToDouble(subtotaltextBox.Text)).ToString();
                    //string[] arr = new string[4];
                    //arr[0] = comboBox1.Text.ToString();
                    //arr[1] = quantytextBox.Text;
                    //arr[2] = pricetextBox.Text;
                    //arr[3] = totaltextBox.Text;
                    //ListViewItem lvi = new ListViewItem(arr);


                    //listView1.Items.Add(lvi);

                    //dataGridView1.Rows.Add(arr);


        
                }
            }
            catch
            {


            }
           totaltextBox.Text = string.Empty;
            quantytextBox.Text = string.Empty;
            ///barcodetextBox2.Text = string.Empty;
            barcodetextBox2.Focus();
        }

        private bool IsFormValid()

        {
            try
            {


                if (quantytextBox.Text == string.Empty)
                {
                    MessageBox.Show("Product Quantity is Unavailable..!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    quantytextBox.Focus();
                    return false;
                }



                if (Convert.ToDouble(quantytextBox.Text) > Convert.ToDouble(quantitylabel.Text))
                {
                    MessageBox.Show("Product UnAvailable Please Bought New Stock..!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    quantytextBox.Focus();
                    return false;
                }
            }


            catch
            {


            }

            return true;
        }


     



        private void button1_Click(object sender, EventArgs e)
        {
            {
                {
                    int index = dataGridView1.CurrentCell.RowIndex;
                    shopingcart.RemoveAt(index);
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = shopingcart;
                    counterproducts.Text = (Convert.ToDouble(counterproducts.Text) - Convert.ToDouble(quantytextBox.Text)).ToString();
                 // subtotaltextBox.Text = (Convert.ToDouble(subtotaltextBox.Text) - Convert.ToDouble(dataGridView1.SelectedRows[0].Cells[3].Value)).ToString();
                }
            }
            {
                double row = Convert.ToDouble(quantytextBox.Text);
                double total = Convert.ToDouble(quantitylabel.Text) + Convert.ToDouble(row);
                SqlConnection con = new SqlConnection(DecHelper.ConnectionString);
                con.Open();
                //StudentB s = new StudentB();
                //MemoryStream ms = new MemoryStream();
                //i.Save(ms, ImageFormat.Jpeg);
                //byte[] arrrrr = ms.ToArray();

                string str = @" UPDATE [ShopManage].[dbo].[tblproducts]
SET [Quantity] = '" + total + "' WHERE ([Products] = '" + comboBox1.Text + "')";

                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();

                con.Close();
            }
            {
                SqlConnection conn = new SqlConnection(DecHelper.ConnectionString);
                conn.Open();
                string str = "  Select  [Quantity] From [ShopManage].[dbo].[tblproducts] WHERE  [Products]= '" + comboBox1.Text + "'";
                SqlCommand cmd = new SqlCommand(str, conn);
                SqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {
                    quantitylabel.Text = da[0].ToString();
                }
            }
            {
                double totalprofit = Convert.ToDouble(pricetextBox.Text) - Convert.ToDouble(purchasepricelabel.Text);
                double pro = totalprofit * Convert.ToDouble(quantytextBox.Text);
                profitlabel.Text = (Convert.ToDouble(profitlabel.Text) - pro).ToString();
                //  double total = Convert.ToDouble(quantitylabel.Text) - Convert.ToDouble(quantytextBox.Text);
                SqlConnection con = new SqlConnection(DecHelper.ConnectionString);
                con.Open();
                //StudentB s = new StudentB();
                //MemoryStream ms = new MemoryStream();
                //i.Save(ms, ImageFormat.Jpeg);
                //byte[] arrrrr = ms.ToArray();

                string str = @" UPDATE [ShopManage].[dbo].[tbltotalsale]
SET [Profit] = '" + profitlabel.Text + "' WHERE ([datetime] = '" + DateTime.Now.ToShortDateString() + "')";

                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();

                con.Close();
            }
    
            // {
            ///   string name = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            //string quntity = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            // string price = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            //{
            //  SqlConnection con = new SqlConnection(DecHelper.ConnectionString); //
            // con.Open();
            //string str = "DELETE FROM [ShopManage].[dbo].[tblSoldProduct] WHERE [Product Name] ='" + name.ToString() + "' And [Price] = '" + price +"' And [Quantity] = '"+ quntity +"' ";
            //SqlCommand cmd = new SqlCommand(str, con);
            //cmd.ExecuteNonQuery();

            //}
            //  }
            if (listView1.Items.Count > 0)
            {
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    if (listView1.Items[i].Selected)
                    {
                       // subtotaltextBox.Text = (Convert.ToDouble(subtotaltextBox.Text) - Convert.ToDouble(listView1.Items[i].SubItems[2].Text)).ToString();
                        listView1.Items[i].Remove();


                    }


                }

                totaltextBox.Text = string.Empty;
                quantytextBox.Text = string.Empty;
               
            }
            {
                subtotaltextBox.Text = "0";
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    subtotaltextBox.Text = Convert.ToString(double.Parse(subtotaltextBox.Text) + double.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString()));

                }
            }

            //{
            //    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            //    {
            //        shopingcart.Remove(row);
            //        //if (!row.IsNewRow)
            //        //{
            //        //    counterproducts.Text = (Convert.ToDouble(counterproducts.Text) - 1).ToString();
            //        //    subtotaltextBox.Text = (Convert.ToDouble(subtotaltextBox.Text) - Convert.ToDouble(dataGridView1.SelectedRows[0].Cells[3].Value)).ToString();
            //        //    dataGridView1.Rows.Remove(row);
            //        //}
            //    }
            }
        

        private void pricetextBox_TextChanged(object sender, EventArgs e)
        {
            //if (barcodetextBox2.Text == string.Empty)
            //{
            //    quantytextBox.Text = string.Empty;
            //}
            //else
            //{
            //    totaltextBox.Text = pricetextBox.Text;
            //    quantytextBox.Text = "1";
            //}
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            listView1.Visible = false;
            {
                SqlConnection conn = new SqlConnection(DecHelper.ConnectionString);
                conn.Open();
                string strrr = "  Select  * From [ShopManage].[dbo].[tblclientdetail]";
                SqlCommand cmddd = new SqlCommand(strrr, conn);
                SqlDataReader da = cmddd.ExecuteReader();
                while (da.Read())
                {

                    clientscomboBox2.Items.Add(da[1].ToString());
                }
            }
            this.KeyPreview = true;
            dataGridView2.DataSource = d.tblproducts.ToList();
            dataGridView2.Visible = false;
            {
                SqlConnection conn = new SqlConnection(DecHelper.ConnectionString);
                conn.Open();
                string strrr = "  Select  DISTINCT [Catagary] From [ShopManage].[dbo].[tblproducts]";
                SqlCommand cmdddd = new SqlCommand(strrr, conn);
                SqlDataReader da = cmdddd.ExecuteReader();
                while (da.Read())
                {
                    catagrycombobox.Items.Add(da[0].ToString()
                                       );
                }
            }
            loginuser.Visible = false;
            radioButton1.Visible = false;
            nimkoradioButton.Visible = false;
            this.KeyPreview = true;
            SqlConnection con = new SqlConnection(DecHelper.ConnectionString);
            con.Open();
            string str = "SELECT  * FROM [ShopManage].[dbo].[tbltotalsale] WHERE [datetime] = '" + DateTime.Now.ToShortDateString() + "' ";
            SqlCommand cmd = new SqlCommand(str, con);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                totalamount.Text = rd[1].ToString();
                profitlabel.Text = rd[4].ToString();
                //txtbal.Text = "";
                // textacno.Text = "";
                // textuname.Text= "";
                //   textnowbal.Visible = true;
                // textacno.Focus();
            }
            {
                SqlConnection conn = new SqlConnection(DecHelper.ConnectionString);
                conn.Open();
                string strr = "SELECT  [Recipt No]  FROM [ShopManage].[dbo].[tbltotalsale] WHERE [datetime] = '" + DateTime.Now.ToShortDateString() + "' ";
                SqlCommand cmdd = new SqlCommand(strr, conn);
                SqlDataReader rdd = cmdd.ExecuteReader();
                while (rdd.Read())
                {
                    RecieptNo.Text = rdd[0].ToString();
                    //txtbal.Text = "";
                    // textacno.Text = "";
                    // textuname.Text= "";
                    //   textnowbal.Visible = true;
                    // textacno.Focus();
                }
                conn.Close();
            }
            RecieptNo.Visible = false;
            counterproducts.Visible = false;
            profitlabel.Visible = false;
        }

        private void discounttextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {


                if (discounttextBox.Text.Length > 0)
                {


                    netamiounttextBox.Text = (Convert.ToDouble(subtotaltextBox.Text) - Convert.ToDouble(discounttextBox.Text)).ToString();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Please Select Digital Values as 123..!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void paidamounttextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {


                if (paidamounttextBox.Text.Length > 0)
                {


                    balancetextBox.Text = (Convert.ToDouble(netamiounttextBox.Text) - Convert.ToDouble(paidamounttextBox.Text)).ToString();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Please Select Digital Values as 123..!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void closetoolStripButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveRecordtoolStripButton_Click(object sender, EventArgs e)
        {
            {
               
                // DateTime d =Convert.ToDateTime(DateTime.Now.ToShortDateString());
                //DateTime t = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                //string total =(d.ToString() + t.ToString());
                SqlConnection con = new SqlConnection(DecHelper.ConnectionString);

                for (int i = 0; i < dataGridView1.Rows.Count - 0; i++)
                {
                    SqlCommand cmd = new SqlCommand(@"INSERT INTO [ShopManage].[dbo].[tblSoldProduct]([Product Name],[Price],[Quantity],[Grand Price],[Date])Values('" + dataGridView1.Rows[i].Cells[0].Value + "','" + dataGridView1.Rows[i].Cells[2].Value + "','" + dataGridView1.Rows[i].Cells[1].Value + "','" + dataGridView1.Rows[i].Cells[3].Value + "','" + DateTime.Now.ToShortDateString() + "')", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            {
                double total = Convert.ToDouble(totalamount.Text) + Convert.ToDouble(netamiounttextBox.Text);
                SqlConnection con = new SqlConnection(DecHelper.ConnectionString);
                con.Open();
                //StudentB s = new StudentB();
                //MemoryStream ms = new MemoryStream();
                //i.Save(ms, ImageFormat.Jpeg);
                //byte[] arrrrr = ms.ToArray();

                string str = @" UPDATE [ShopManage].[dbo].[tbltotalsale]
SET [totalsale] = '" + total + "', [datetime] = '" + DateTime.Now.ToShortDateString() + "' WHERE ([datetime] = '" + DateTime.Now.ToShortDateString() + "')";

                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();

                con.Close();
            }
            {
                SqlConnection conn = new SqlConnection(DecHelper.ConnectionString);
                conn.Open();
                string strr = "SELECT  [totalsale] FROM [ShopManage].[dbo].[tbltotalsale] WHERE [datetime] = '" + DateTime.Now.ToShortDateString() + "' ";
                SqlCommand cmdd = new SqlCommand(strr, conn);
                SqlDataReader rd = cmdd.ExecuteReader();
                while (rd.Read())
                {
                    totalamount.Text = rd[0].ToString();
                    //txtbal.Text = "";
                    // textacno.Text = "";
                    // textuname.Text= "";
                    //   textnowbal.Visible = true;
                    // textacno.Focus();
                }
                conn.Close();
            }


        }

        private void totalamount_Click(object sender, EventArgs e)
        {

        }

        private void resettoolStripButton_Click(object sender, EventArgs e)
        {
            //    totaltextBox.Text = "0";
            //    comboBox1.Text = " ";
            //    quantytextBox.Text = " ";
            //    totalamount.Text = "0";
            //    subtotaltextBox.Text = "0";
            //    netamiounttextBox.Text = "0";
            //    balancetextBox.Text = "0";
            //    pricetextBox.Text = "0";
            //    paidamounttextBox.Text = "0";
            //    discounttextBox.Text = "0";
            //    balancetextBox.Text = "0";
            //    barcodetextBox2.Text = " ";
            //    listView1.Items.Clear();
            //    dataGridView1.Rows.Clear();
            this.Hide();
            Form1 f = new Form1();
            f.ShowDialog();


        }
        Bitmap bmp;
   //     private PaperKind c;

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {


                if (dataGridView1.DataSource != null  && subtotaltextBox.Text != string.Empty && netamiounttextBox.Text != string.Empty)
                {
                    if (clientscomboBox2.Text != "Mr.Walky Talky"&& netamiounttextBox.Text!=paidamounttextBox.Text)
                    {

                    
                    //Record Save Function
                    {
                        {
                            DateTime d = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                            DateTime t = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                            string total = (d.ToString() + t.ToString());
                            SqlConnection con = new SqlConnection(DecHelper.ConnectionString);
                            double totall = (Convert.ToDouble(balancetextBox.Text) + (Convert.ToDouble(clientbqaya.Text)));
                            for (int i = 0; i < dataGridView1.Rows.Count - 0; i++)
                            {

                                SqlCommand cmd = new SqlCommand(@"INSERT INTO [ShopManage].[dbo].[tblclients]([Products Details],[Client Name],[Name Amount],[Date],[Bqaya Amount])Values('" + dataGridView1.Rows[i].Cells[0].Value + "','" + clientscomboBox2.Text + "','" + dataGridView1.Rows[i].Cells[3].Value + "','" + DateTime.Now.ToShortDateString() + "','" + totall + "')", con);
                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();
                            }
                        }
                    }
                    }
                    {
                        SqlConnection conn = new SqlConnection(DecHelper.ConnectionString);
                        conn.Open();
                        string strr = "SELECT  [Recipt No]  FROM [ShopManage].[dbo].[tbltotalsale] WHERE [datetime] = '" + DateTime.Now.ToShortDateString() + "' ";
                        SqlCommand cmdd = new SqlCommand(strr, conn);
                        SqlDataReader rd = cmdd.ExecuteReader();
                        while (rd.Read())
                        {
                            RecieptNo.Text = rd[0].ToString();
                            //txtbal.Text = "";
                            // textacno.Text = "";
                            // textuname.Text= "";
                            //   textnowbal.Visible = true;
                            // textacno.Focus();
                        }
                        conn.Close();
                    }
                    {

                        double total = Convert.ToDouble((Convert.ToDouble(RecieptNo.Text) + 1).ToString());
                        // double total = Convert.ToDouble(RecieptNo.Text) + Convert.ToDouble(quantytextBox.Text);
                        SqlConnection con = new SqlConnection(DecHelper.ConnectionString);
                        con.Open();
                        //StudentB s = new StudentB();
                        //MemoryStream ms = new MemoryStream();
                        //i.Save(ms, ImageFormat.Jpeg);
                        //byte[] arrrrr = ms.ToArray();
                        // string strr = @" UPDATE [ShopManage].[dbo].[tbltotalsale]
                        //SET [totalsale] = '" + total + "', [datetime] = '" + DateTime.Now.ToShortDateString() + "' WHERE ([datetime] = '" + DateTime.Now.ToShortDateString() + "')";

                        string str = @" UPDATE [ShopManage].[dbo].[tbltotalsale] SET [Recipt No]= '" + total + "'  WHERE [datetime] = '" + DateTime.Now.ToShortDateString() + "'";

                        SqlCommand cmd = new SqlCommand(str, con);
                        cmd.ExecuteNonQuery();

                        con.Close();
                    }
                    {

                        double total = (Convert.ToDouble(balancetextBox.Text) + (Convert.ToDouble(clientbqaya.Text)));
                        // double total = Convert.ToDouble(RecieptNo.Text) + Convert.ToDouble(quantytextBox.Text);
                        SqlConnection con = new SqlConnection(DecHelper.ConnectionString);
                        con.Open();
                        //StudentB s = new StudentB();
                        //MemoryStream ms = new MemoryStream();
                        //i.Save(ms, ImageFormat.Jpeg);
                        //byte[] arrrrr = ms.ToArray();
                        // string strr = @" UPDATE [ShopManage].[dbo].[tbltotalsale]
                        //SET [totalsale] = '" + total + "', [datetime] = '" + DateTime.Now.ToShortDateString() + "' WHERE ([datetime] = '" + DateTime.Now.ToShortDateString() + "')";

                        string str = @" UPDATE [ShopManage].[dbo].[clientbqayaamount]
SET [bqayaamount]= '" + total + "'  WHERE [nameclient] = '" + clientscomboBox2.Text + "'";

                        SqlCommand cmd = new SqlCommand(str, con);
                        cmd.ExecuteNonQuery();

                        con.Close();
                    }


                    ///Record Save Function
                    {
                        {
                            double total = Convert.ToDouble((Convert.ToDouble(RecieptNo.Text) + 1).ToString());
                            // DateTime d =Convert.ToDateTime(DateTime.Now.ToShortDateString());
                            //DateTime t = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                            //string total =(d.ToString() + t.ToString());
                            SqlConnection con = new SqlConnection(DecHelper.ConnectionString);

                            for (int i = 0; i < dataGridView1.Rows.Count - 0; i++)
                            {
                                SqlCommand cmd = new SqlCommand(@"INSERT INTO [ShopManage].[dbo].[tblSoldProduct]([Product Name],[Price],[Quantity],[Grand Price],[Date],[Sale Man],[Invoice Num])Values('" + dataGridView1.Rows[i].Cells[0].Value + "','" + dataGridView1.Rows[i].Cells[2].Value + "','" + dataGridView1.Rows[i].Cells[1].Value + "','" + dataGridView1.Rows[i].Cells[3].Value + "','" + DateTime.Now.ToShortDateString() + "','" + loginuser.Text + "','" +total + "')", con);
                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();
                            }
                        }
                        {
                            double total = Convert.ToDouble(totalamount.Text) + Convert.ToDouble(netamiounttextBox.Text);
                            SqlConnection con = new SqlConnection(DecHelper.ConnectionString);
                            con.Open();
                            //StudentB s = new StudentB();
                            //MemoryStream ms = new MemoryStream();
                            //i.Save(ms, ImageFormat.Jpeg);
                            //byte[] arrrrr = ms.ToArray();

                            string str = @" UPDATE [ShopManage].[dbo].[tbltotalsale]
SET [totalsale] = '" + total + "', [datetime] = '" + DateTime.Now.ToShortDateString() + "' WHERE ([datetime] = '" + DateTime.Now.ToShortDateString() + "')";

                            SqlCommand cmd = new SqlCommand(str, con);
                            cmd.ExecuteNonQuery();

                            con.Close();
                        }
                        {
                            SqlConnection conn = new SqlConnection(DecHelper.ConnectionString);
                            conn.Open();
                            string strr = "SELECT  [totalsale] FROM [ShopManage].[dbo].[tbltotalsale] WHERE [datetime] = '" + DateTime.Now.ToShortDateString() + "' ";
                            SqlCommand cmdd = new SqlCommand(strr, conn);
                            SqlDataReader rd = cmdd.ExecuteReader();
                            while (rd.Read())
                            {
                                totalamount.Text = rd[0].ToString();
                                //txtbal.Text = "";
                                // textacno.Text = "";
                                // textuname.Text= "";
                                //   textnowbal.Visible = true;
                                // textacno.Focus();
                            }
                            conn.Close();
                        }

                    }

                    //PRINTING FUNCTIONALITY....

                    //if (Convert.ToInt32(counterproducts.Text) > 7)
                    //{
                    //    int heightt = dataGridView1.Height;
                    //    dataGridView1.Height = dataGridView1.RowCount * dataGridView1.RowTemplate.Height * 3;
                    //    bmp = new Bitmap(dataGridView1.Width, dataGridView1.Height);
                    //    dataGridView1.DrawToBitmap(bmp, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));

                    //    dataGridView1.Height = heightt;

                    //    printPreviewDialog.Document = printDocumentbigerthen7;
                    //    printDocumentbigerthen7.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("custom", 280, 790);
                    //    printPreviewDialog.ShowDialog();
                    //}
                    //else
                    //{
                    //    //   dataGridView1.RowCount *
                    //    int height = dataGridView1.Height;
                    //    dataGridView1.Height = dataGridView1.RowCount * dataGridView1.RowTemplate.Height * 3;
                    //    bmp = new Bitmap(dataGridView1.Width, dataGridView1.Height);
                    //    dataGridView1.DrawToBitmap(bmp, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));

                    //    dataGridView1.Height = height;
                  //  printPreviewDialog pd  = new printPreviewDialog();
                        printPreviewDialog.Document = printDocument;
                        printDocument.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("custom", 280, 4000);
                        printPreviewDialog.ShowDialog();

                    }




                
               


                else

                {
                    MessageBox.Show("Products And Total Balance Required...!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception)
            {

                MessageBox.Show("Please Connect Printer With Your Pc..!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //print call image
            {
               // int width = 10;

                Bitmap bmp = Properties.Resources.call_ringing_icon;
                Image newimage = bmp;
                // newimage.Width = width;
               // e.Graphics.DrawImage(newimage, 65, 90, newimage.Width, newimage.Height);


            }
            //for whatsaap icon
            {
                Bitmap bmp = Properties.Resources.WhatsApp_icon;
                Image newimage = bmp;
                // newimage.Width = width;
              //  e.Graphics.DrawImage(newimage, 65, 120, newimage.Width, newimage.Height);
            }
            //Brush brush = new SolidBrush(Color.Black);
            //Pen blackPen = new Pen(Color.Black, 1);
            //e.Graphics.PageUnit = GraphicsUnit.Millimeter;
           // e.PageSettings.Margins = new Margins(10, 10, 10, 10);
          //  Rectangle rect = new Rectangle(10, 10, 50, 90);
            //e.Graphics.DrawRectangle(blackPen, rect);
        ///    dataGridView1.Height = dataGridView1.RowCount * dataGridView1.RowTemplate.Height * 3;
           // int height = dataGridView1.Height;
            // e.PageSettings.PaperSize.Height = 12;


         ///   dataGridView1.Height = height;
            //e.PageSettings.PaperSize.Height = 1000;
            //e.PageSettings.PaperSize.Width = 200;
            // e.Graphics.DrawString("Al Basit Stores (Store No 1)", new Font("monotype corsiva", 30, FontStyle.Bold), Brushes.Black, new Point(200, 50));
              Brush brush = new SolidBrush(Color.Black);
            Pen blackPenn = new Pen(Color.Black, 2);

            // Create location and size of rectangle.
            int xz = 1;
            int yz = 110;
            int widthh = 278;
            int heighth = 25;

            // Draw rectangle to screen.
            e.Graphics.DrawRectangle(blackPenn, xz, yz, widthh, heighth);
            int ypos = 140;
            e.Graphics.DrawString("WALI MART", new Font("Arial", 16,FontStyle.Bold), Brushes.Black, new Point(70, 10));
            e.Graphics.DrawString("Al Noor Garden Phase-4 Shop#4 ", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(35, 40));
            e.Graphics.DrawString("Near Cival Hospital,Bahawalpur ", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(35, 60));
           // e.Graphics.DrawString("For Complaint", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(75, 60));
           // e.Graphics.DrawString("|", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(131, 75));
            //e.Graphics.DrawString("V", new Font("Arial", 9, FontStyle.Bold), Brushes.Black, new Point(129, 80));
            double total = (Convert.ToDouble(balancetextBox.Text) + (Convert.ToDouble(clientbqaya.Text)));
           // e.Graphics.DrawString(" 0300-6827284 ", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(85, 90));
            e.Graphics.DrawString("CELL : 0300-5576238 || 0300-6668166 ", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(20, 75));
            e.Graphics.DrawString("" + DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString() + " " + "Invoice No" + ": " + RecieptNo.Text, new Font("Arial", 7, FontStyle.Regular), Brushes.Black, new Point(5, 90));
         //   e.Graphics.DrawString("------------------------------------------------------------------------------", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(-5, 147));
            e.Graphics.DrawString("Product Name", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(0, 115));
            e.Graphics.DrawString("Qty", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(145, 115));
            e.Graphics.DrawString("Rate", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(175, 115));
            e.Graphics.DrawString("Amount", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(220, 115));


          //  e.Graphics.DrawString("----------------------------------------------------------------------------------------", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(-5, 170));
            ///  e.Graphics.DrawImage(bmp, new Point(-45, 200));
         
           for (int i = 0; i < shopingcart.Count; i++)
            {
            //    numbersofitemsperpage++;
            //    if (numbersofitemsperpage<=500)
            //    {
            //        numbersofitemsprintsofar++;
            //        if (numbersofitemsprintsofar<=shopingcart.Count)
            //        {

                        e.Graphics.DrawString(shopingcart [i].ProductName, new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(-2, ypos));
                        e.Graphics.DrawString(shopingcart[i].Quantity.ToString(), new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(145, ypos));
                        e.Graphics.DrawString(shopingcart[i].Price.ToString(), new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(175, ypos));
                        e.Graphics.DrawString(shopingcart[i].Total.ToString(), new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(220, ypos));
                        ypos += 30;
                //    }
                //    else
                //    {
                //        e.HasMorePages = false;

                //    }
                //}
                //else
                //{
                //    numbersofitemsperpage = 0;
                //    e.HasMorePages = true;
                //    return;
                //}
            }
           
           // e.Graphics.DrawString("----------------------------------------------------------------------------------------", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(-5, ypos-15));
            e.Graphics.DrawString("_________________________________________________________________________________________", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(-5, ypos-15));
            //e.Graphics.DrawString(" _________________________________", new Font("Arial", 18, FontStyle.Bold), Brushes.Black, new Point(0, ypos));
           // e.Graphics.DrawString(" _________________________________", new Font("Arial", 18, FontStyle.Bold), Brushes.Black, new Point(0, height+160));
            e.Graphics.DrawString(" Total Items:  " + dataGridView1.RowCount + "   " + "Gross Amount:" + "      " + subtotaltextBox.Text, new Font("Arial", 9, FontStyle.Bold), Brushes.Black, new Point(10,ypos+5));
            e.Graphics.DrawString(" Discount:               " + discounttextBox.Text , new Font("Arial", 9, FontStyle.Bold), Brushes.Black, new Point(109,ypos+17));
            // Create pen.
            {
                Pen blackPennn = new Pen(Color.Black, 3);

                // Create location and size of rectangle.
                int xx = 30;
                int yy = ypos+35;
                int widthhh = 250;
                int heightt = 25;
                // Draw rectangle to screen.
                e.Graphics.DrawRectangle(blackPennn, xx, yy, widthhh, heightt);
            }
           /// e.Graphics.DrawString(" ___________________", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(100, ypos+10));
            e.Graphics.DrawString(" Net Amount:                 " + netamiounttextBox.Text, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(35, ypos+40));
           e.Graphics.DrawString(" Client Name: " + clientscomboBox2.Text, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(5, ypos+65));
            e.Graphics.DrawString(" Remaining Rs:" + total, new Font("Arial", 7, FontStyle.Bold), Brushes.Black, new Point(160, ypos + 65));
            e.Graphics.DrawString(" Printed By: " + loginuser.Text, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(5, ypos+80));
            e.Graphics.DrawString(" Free Home Delivery Within 2KM", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(5, ypos+95));
            e.Graphics.DrawString(" At Minimum Order 1000Rs", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(5, ypos+110));
           // e.Graphics.DrawString(" Paid:              " + paidamounttextBox.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(100, ypos+55));
           // e.Graphics.DrawString(" Total Amount:" + total, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(160, ypos+110));

          //  e.Graphics.DrawString(" ___________________", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(100, ypos+55));
           // e.Graphics.DrawString(" Returns:         " + balancetextBox.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(100, ypos+77));
            ///e.Graphics.DrawString(" Note:   1=>  Open & Frozen Items no exchange no return.", new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(5, 540));
           // e.Graphics.DrawString("     2=> Exchange within 7-days of purchase with orignal Packing", new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(5, 560));
            //e.Graphics.DrawString("              and item should be in saleable condition.", new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(5, 580));
            //e.Graphics.DrawString("     3=> No Exchange without receipt.", new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(5, 600));
           // e.Graphics.DrawString("     Thanks For Visit.", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(50, ypos+137));
          //  e.Graphics.DrawString("      ___________________", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(20, ypos+115));
          //  e.Graphics.DrawString("     | ", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(20, ypos+135));
          //  e.Graphics.DrawString("     | ", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(230, ypos+135));
           // e.Graphics.DrawString("      ___________________", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(20, ypos+140));
           // e.Graphics.DrawString(" Software Devolper : Munir Ahmad    Contact :0301-4854706", new Font("Arial", 7, FontStyle.Regular), Brushes.Black, new Point(10, ypos+170));
            //e.Graphics.DrawString(" Products:    ", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(25, 290));
            //e.Graphics.DrawString(" Total Amount:", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(180, 290));
            //e.Graphics.DrawString("Discount:", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(25, 290));
            //e.Graphics.DrawString("", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(25, 210));
            //e.Graphics.DrawString(" ", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(25, 240));
            Pen blackPen = new Pen(Color.Black, 3);

            // Create location and size of rectangle.
            int x =55 ;
            int y = ypos+135;
            int width = 200;
            int height = 25;

            // Draw rectangle to screen.
         //   e.Graphics.DrawRectangle(blackPen, x, y, width, height);
            /////////////////////////////////////////
            //printDocument1.OriginAtMargins = true;
            //Graphics g = e.Graphics;
            //Pen blackPen = new Pen(Color.Black, 1);
            //e.Graphics.PageUnit = GraphicsUnit.Millimeter;
            //e.Graphics.PageUnit = ypos + 135;
            //e.PageSettings.Margins = new Margins(ypos + 135, ypos + 135, ypos + 135, ypos + 135);
            //Rectangle rect = new Rectangle(5, 5, 5, 5);
            //e.Graphics.DrawRectangle(blackPen, rect);
            ////////////////////////////////
            //  e.Graphics.DrawString("ABC", new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(200, 100));
            ///  e.Graphics.DrawImage(bmp, new Point(25, 160));
            // e.Graphics.DrawString(" " + subtotaltextBox.Text, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(330, 290));
            //e.Graphics.DrawString(" " + discounttextBox.Text, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(130, 290));
            //e.Graphics.DrawString("آپ کی آمد کا شکریہ۔۔۔ " , new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(100, 320));
            //e.Graphics.DrawString("Software Devolper:", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(130, 350));

            //e.Graphics.DrawString("Munir Ahmad", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(260, 350));
            //e.Graphics.DrawString("Contact:", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(150, 380));
            //e.Graphics.DrawString("0301-4854706", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(260, 380));
            //  e.Graphics.DrawString(" " + discounttextBox.Text, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(130, 290));
            //e.Graphics.DrawString(" ", new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(200, 190));
            //e.Graphics.DrawString(" ", new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(200, 210));
            //e.Graphics.DrawString(" ", new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(200, 240));
            //  e.Graphics.DrawString("--------------------------------------------------------------------------------------------------------------", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(25, 270));
            //  e.Graphics.DrawString(" " , new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(25, 300));
            // e.Graphics.DrawImage(bmp, new Point(25, 300));
            /// e.Graphics.DrawString("--------------------------------------------------------------------------------------------------------------", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(25, 370));








        }

        private void netamiounttextBox_TextChanged(object sender, EventArgs e)
        {
            paidamounttextBox.Text = Convert.ToDouble(netamiounttextBox.Text).ToString();
        }

        private void totaltextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void printPreviewDialog_Load(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // if (e.Control == true && e.KeyCode ==Keys.S)
            //{
            //  SaveRecordtoolStripButton.PerformClick();
            //}
            if (e.KeyCode == Keys.Enter)
            {
               // dataGridView2.PerformLayout();

            }
            if (e.Control == true && e.KeyCode == Keys.P)
            {
                toolStripButton2.PerformClick();
            }
            if (e.Control == true && e.KeyCode == Keys.R)
            {
                resettoolStripButton.PerformClick();
            }
            if (e.KeyCode == Keys.Escape)
            {
                closetoolStripButton.PerformClick();
            }
            if (e.KeyCode == Keys.F10)
            {
                button1.PerformClick();
            }
            if (e.Control == true && e.KeyCode == Keys.M)
            {
                toolStripButton2.PerformClick();
            }
            if (e.KeyCode == Keys.Enter)
            {
               additembutton.PerformClick();
            }
        }

        private void printDocument_QueryPageSettings(object sender, System.Drawing.Printing.QueryPageSettingsEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void barcodetextBox2_TextChanged(object sender, EventArgs e)
        {
            dataGridView2.Visible = true;
            dataGridView2.Columns[1].Width = 250;
            dataGridView2.Columns[0].Width = -10;
          //  dataGridView2.Focus();
            barcodetextBox2.Focus();

            try
            {

                {
                    using (SqlConnection con = new SqlConnection((DecHelper.ConnectionString)))
                    {

                        string str = "Select * FROM [ShopManage].[dbo].[tblproducts] WHERE [Products] LIKE '%" + barcodetextBox2.Text + "%' OR [Price] LIKE '%" + barcodetextBox2.Text + "%' OR [Quantity] LIKE '%" + barcodetextBox2.Text + "%' OR [Catagary] LIKE '%" + barcodetextBox2.Text + "%' OR [Barcode] LIKE '%" + barcodetextBox2.Text + "%'  OR [Buy Price] LIKE '%" + barcodetextBox2.Text + "%' ";
                        SqlCommand cmd = new SqlCommand(str, con);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dataGridView2.DataSource = new BindingSource(dt, null);
                    }
                    
                }

                {
                    /// string product = "Others";
                    SqlConnection conn = new SqlConnection(DecHelper.ConnectionString);
                    conn.Open();
                    string str = "  Select * From [ShopManage].[dbo].[tblproducts] WHERE  Barcode= '" + barcodetextBox2.Text + "'";
                    SqlCommand cmd = new SqlCommand(str, conn);
                    SqlDataReader da = cmd.ExecuteReader();
                    while (da.Read())
                    {
                        catagrycombobox.Text = da[4].ToString();
                        pricetextBox.Text = da[2].ToString();
                        comboBox1.Text = da[1].ToString();
                        quantitylabel.Text = da[3].ToString();
                       purchasepricelabel.Text = da[6].ToString();
                        ///  comboBox1.Items.Add(da[0].ToString()
                        //  );
                    }
                    //  comboBox1.Items.Add("Small");
                    //comboBox1.Items.Add("Mediam");
                    //comboBox1.Items.Add("Full Size");

               
            }
            }
            catch (Exception)
            {

              
            }
        }

        private void catagrycombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            {
                 comboBox1.Items.Clear();
                SqlConnection conn = new SqlConnection(DecHelper.ConnectionString);
                conn.Open();
                string str = "  Select  * From [ShopManage].[dbo].[tblproducts] WHERE  [Catagary]= '" + catagrycombobox.Text + "'";
                SqlCommand cmd = new SqlCommand(str, conn);
                SqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {
                   
                    comboBox1.Items.Add(da[1].ToString());
                }
            }

        }

        private void printDocumentbigerthen7_PrintPage(object sender, PrintPageEventArgs e)
        {
            
            foreach (var item in dataGridView1.Rows)
            {
              //  e.Graphics.DrawString(item.ToString(), new Point(-45, 200));
            }
            //print call image
            {
                int width = 10;

                Bitmap bmp = Properties.Resources.call_ringing_icon;
                Image newimage = bmp;
                // newimage.Width = width;
                e.Graphics.DrawImage(newimage, 65, 90, newimage.Width, newimage.Height);


            }
            //for whatsaap icon
            {
                Bitmap bmp = Properties.Resources.WhatsApp_icon;
                Image newimage = bmp;
                // newimage.Width = width;
                e.Graphics.DrawImage(newimage, 65, 120, newimage.Width, newimage.Height);
            }
            //Brush brush = new SolidBrush(Color.Black);
            //Pen blackPen = new Pen(Color.Black, 1);
            //e.Graphics.PageUnit = GraphicsUnit.Millimeter;
            // e.PageSettings.Margins = new Margins(10, 10, 10, 10);
            //  Rectangle rect = new Rectangle(10, 10, 50, 90);
            //e.Graphics.DrawRectangle(blackPen, rect);
            dataGridView1.Height = dataGridView1.RowCount * dataGridView1.RowTemplate.Height * 3;
            int height = dataGridView1.Height;
            // e.PageSettings.PaperSize.Height = 12;


            dataGridView1.Height = height;
            //e.PageSettings.PaperSize.Height = 1000;
            //e.PageSettings.PaperSize.Width = 200;
            // e.Graphics.DrawString("Al Basit Stores (Store No 1)", new Font("monotype corsiva", 30, FontStyle.Bold), Brushes.Black, new Point(200, 50));
            e.Graphics.DrawString("ALLAh HOO SUPER MART", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(-6, 10));
            e.Graphics.DrawString("Pull Diwan, Bahawalpur ", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(45, 40));
            e.Graphics.DrawString("For Complaint", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(75, 60));
            e.Graphics.DrawString("|", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(131, 75));
            e.Graphics.DrawString("V", new Font("Arial", 9, FontStyle.Bold), Brushes.Black, new Point(129, 80));
            double total = (Convert.ToDouble(balancetextBox.Text) + (Convert.ToDouble(clientbqaya.Text)));
            e.Graphics.DrawString(" 0300-6827284 ", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(85, 90));
            e.Graphics.DrawString("0303-5050508 -> 0300-2952759  ", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(20, 120));
            e.Graphics.DrawString("" + DateTime.Now.ToLongDateString() + "  " + DateTime.Now.ToLongTimeString() + " " + "Invoice No" + ": " + RecieptNo.Text, new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(5, 160));
            e.Graphics.DrawString(" _________________________________", new Font("Arial", 18, FontStyle.Bold), Brushes.Black, new Point(0, 167));
            e.Graphics.DrawImage(bmp, new Point(-45, 200));
            e.Graphics.DrawString(" _________________________________", new Font("Arial", 18, FontStyle.Bold), Brushes.Black, new Point(0, 550));
            e.Graphics.DrawString(" Total Items=  " + counterproducts.Text + "              " + "Sub Total" + "    " + subtotaltextBox.Text, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(5, 580));
            e.Graphics.DrawString(" ___________________", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(100, 645));
            e.Graphics.DrawString(" Grand Total:  " + subtotaltextBox.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(100, 610));
            e.Graphics.DrawString(" Client Name: " + clientscomboBox2.Text, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(0, 700));
            e.Graphics.DrawString(" Total Amount:" + total, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(160, 700));

            e.Graphics.DrawString(" Printed By: " + loginuser.Text, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(0, 730));
            e.Graphics.DrawString(" Paid:         " + paidamounttextBox.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(100, 640));
            e.Graphics.DrawString(" ___________________", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(100, 585));
            e.Graphics.DrawString(" Returns:   " + balancetextBox.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(100, 670));
            ///e.Graphics.DrawString(" Note:   1=>  Open & Frozen Items no exchange no return.", new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(5, 540));
           // e.Graphics.DrawString("     2=> Exchange within 7-days of purchase with orignal Packing", new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(5, 560));
            //e.Graphics.DrawString("              and item should be in saleable condition.", new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(5, 580));
            //e.Graphics.DrawString("     3=> No Exchange without receipt.", new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(5, 600));
            e.Graphics.DrawString("     Thanks For Visit.", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(50, 735));
            e.Graphics.DrawString("      ___________________", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(20, 710));
            e.Graphics.DrawString("     | ", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(20, 730));
            e.Graphics.DrawString("     | ", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(230, 730));
            e.Graphics.DrawString("      ___________________", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(20, 740));
            e.Graphics.DrawString(" Software Devolper : Munir Ahmad    Contact :0301-4854706", new Font("Arial", 7, FontStyle.Regular), Brushes.Black, new Point(10, 770));
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            quantytextBox.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            ///.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          //  comboBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
           // quantytextBox.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
           // comboBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            //quantytextBox.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            {
                SqlConnection conn = new SqlConnection(DecHelper.ConnectionString);
                conn.Open();
                string str = "  Select  [Quantity] From [ShopManage].[dbo].[tblproducts] WHERE  [Products]= '" + comboBox1.Text + "'";
                SqlCommand cmd = new SqlCommand(str, conn);
                SqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {
                    quantitylabel.Text = da[0].ToString();
                }
            }
        }

        private void dataGridView2_Click(object sender, EventArgs e)
        {
           // comboBox1.Text = dataGridView2.SelectedRows[0].Cells[1].Value.ToString();
         // pricetextBox.Text = dataGridView2.SelectedRows[0].Cells[2].Value.ToString();
         // quantytextBox.Text = dataGridView2.SelectedRows[0].Cells[3].Value.ToString();
           // catagrycombobox.Text = dataGridView2.SelectedRows[0].Cells[4].Value.ToString();
          // barcodetextBox2.Text = dataGridView2.SelectedRows[0].Cells[5].Value.ToString();
         // buytextBox1.Text = dataGridView2.SelectedRows[0].Cells[6].Value.ToString();
        }

        private void dataGridView2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //barcodetextBox2.Text = dataGridView2.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void dataGridView2_Enter(object sender, EventArgs e)
        {
         //  barcodetextBox2.Text = dataGridView2.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void dataGridView2_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void dataGridView2_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
          ///  barcodetextBox2.Text = dataGridView2.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        {
            barcodetextBox2.Text = dataGridView2.SelectedRows[0].Cells[5].Value.ToString();
            dataGridView2.Visible = false;
            quantytextBox.Focus();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            {
                SqlConnection conn = new SqlConnection(DecHelper.ConnectionString);
                conn.Open();
                string strrr = "  Select * FROM [ShopManage].[dbo].[clientbqayaamount] Where [nameclient]='" + clientscomboBox2.Text + "'";
                SqlCommand cmdddd = new SqlCommand(strrr, conn);
                SqlDataReader da = cmdddd.ExecuteReader();
                while (da.Read())
                {
                    clientbqaya.Text = da[2].ToString();
                }
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ProductsViewForm p = new ProductsViewForm();
            p.ShowDialog();
        }
    }
}