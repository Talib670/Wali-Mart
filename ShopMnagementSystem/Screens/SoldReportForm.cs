using ShopMnagementSystem.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;


namespace ShopMnagementSystem.Screens
{
    public partial class SoldReportForm : Form
    {
       DataClasses3DataContext d = new DataClasses3DataContext();
       DataClasses2DataContext db = new DataClasses2DataContext();
        public SoldReportForm()
        {
            InitializeComponent();
        }

        private void SoldReportForm_Load(object sender, EventArgs e)
        {
            {
                using (SqlConnection con = new SqlConnection((DecHelper.ConnectionString)))
                {

                    string str = "Select *  FROM [ShopManage].[dbo].[tbltotalsale] WHERE  [datetime] ='" + DateTime.Now.ToShortDateString() + "'";
                    SqlCommand cmd = new SqlCommand(str, con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView2.DataSource = new BindingSource(dt, null);
                }
            }
            button1.Visible = false;
            label3.Visible = false;
            this.KeyPreview = true;
            {
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
            }
            dateTimePicker2.Text = string.Empty;

            using (SqlConnection con = new SqlConnection((DecHelper.ConnectionString)))
            {

                string str = "Select *  FROM [ShopManage].[dbo].[tblSoldProduct] WHERE  [Date] ='" + DateTime.Now.ToShortDateString() + "'";
                SqlCommand cmd = new SqlCommand(str, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = new BindingSource(dt, null);
            }
        }

        private void searchbutton_Click(object sender, EventArgs e)
        {
            label4.Visible = true;
            button1.Visible = true;
            label3.Visible = true;
            profitlabel.Visible = true;
            label8.Visible = false;
            totalamount.Visible = false;
            label2.Visible = false;
            using (SqlConnection con = new SqlConnection((DecHelper.ConnectionString)))
            {
                string str = "Select * FROM [ShopManage].[dbo].[tblSoldProduct] WHERE  [Date] ='" + dateTimePicker1.Text + "'";
                string strr = "Select * FROM [ShopManage].[dbo].[tblSoldProduct] WHERE  [Date] >='" + dateTimePicker2.Text + "' And [Date] <= '" + dateTimePicker1.Text + "'";
                SqlCommand cmd = new SqlCommand(strr, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = new BindingSource(dt, null);
            }
            using (SqlConnection con = new SqlConnection((DecHelper.ConnectionString)))
            {
                string str = "Select * FROM [ShopManage].[dbo].[tbltotalsale] WHERE  [datetime] ='" + dateTimePicker1.Text + "'";
                string strr = "Select * FROM [ShopManage].[dbo].[tbltotalsale] WHERE [datetime] >='" + dateTimePicker2.Text + "' And [datetime] <= '" + dateTimePicker1.Text + "'";
                SqlCommand cmd = new SqlCommand(strr, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView2.DataSource = new BindingSource(dt, null);
            }
            SqlConnection conn = new SqlConnection(DecHelper.ConnectionString);
            conn.Open();
            string strrr = "Select  [totalsale] From [ShopManage].[dbo].[tbltotalsale] WHERE  [datetime] ='" + dateTimePicker1.Text + "'";
            SqlCommand cmdddd = new SqlCommand(strrr, conn);
            SqlDataReader daa = cmdddd.ExecuteReader();
            while (daa.Read())
            {
                totalamount.Text = (daa[0].ToString()
                                   );
            }


        }

        private void SoldReportForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchbutton.PerformClick();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label3.Text = "0";
            profitlabel.Text = "0";
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                label3.Text = Convert.ToString(double.Parse(label3.Text) + double.Parse(dataGridView2.Rows[i].Cells[1].Value.ToString()));
                profitlabel.Text = Convert.ToString(double.Parse(profitlabel.Text) + double.Parse(dataGridView2.Rows[i].Cells[4].Value.ToString()));

        }
    }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                {



                    if (MessageBox.Show("Do You Want Return Record....!!!!", "Return Product", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                    {
                        {
                            double rows = Convert.ToDouble(dataGridView1.SelectedRows[0].Cells[2].Value);
                            double totall = rows - Convert.ToDouble(purchasepricelabel.Text);
                            double totalprofit = Convert.ToDouble(profitlabel5.Text) - totall;
                            double row = Convert.ToDouble(dataGridView1.SelectedRows[0].Cells[4].Value);
                            double total = Convert.ToDouble(totalamount.Text) - Convert.ToDouble(row);
                            SqlConnection con = new SqlConnection(DecHelper.ConnectionString);
                            con.Open();
                            //StudentB s = new StudentB();
                            //MemoryStream ms = new MemoryStream();
                            //i.Save(ms, ImageFormat.Jpeg);
                            //byte[] arrrrr = ms.ToArray();
                            //  Convert.ToDateTime(DateTime.Now.ToShortDateString()

                            string str = @" UPDATE [ShopManage].[dbo].[tbltotalsale] SET [totalsale]= '" + total + "',[Profit]= '" + totalprofit + "'  WHERE [datetime] = '" + (Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells[5].Value)) + "'";

                            SqlCommand cmd = new SqlCommand(str, con);
                            cmd.ExecuteNonQuery();

                            con.Close();
                        }
                        {
                            double row = Convert.ToDouble(dataGridView1.SelectedRows[0].Cells[3].Value);
                            double total = Convert.ToDouble(quantitylabel.Text) + Convert.ToDouble(row);
                            SqlConnection con = new SqlConnection(DecHelper.ConnectionString);
                            con.Open();
                            //StudentB s = new StudentB();
                            //MemoryStream ms = new MemoryStream();
                            //i.Save(ms, ImageFormat.Jpeg);
                            //byte[] arrrrr = ms.ToArray();

                            string str = @" UPDATE [ShopManage].[dbo].[tblproducts]
SET [Quantity] = '" + total + "' WHERE  ([Products]= '" + dataGridView1.SelectedRows[0].Cells[1].Value.ToString() + "')";

                            SqlCommand cmd = new SqlCommand(str, con);
                            cmd.ExecuteNonQuery();

                            con.Close();
                        }
                        int tid = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                        ///  tblSoldProduct item=d.tblSoldProducts.where 
                        tblSoldProduct item = d.tblSoldProducts.Where(o => o.id == tid).FirstOrDefault();
                        d.tblSoldProducts.DeleteOnSubmit(item);

                        d.SubmitChanges();
                        MessageBox.Show("Product Record Return SuccessFully....!!!!", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        var list = d.tblSoldProducts.ToList();



                        //{
                        //    using (SqlConnection con = new SqlConnection((DecHelper.ConnectionString)))
                        //    {
                        //        string str = "Select * FROM [Mughluya].[dbo].[tblSoldProduct] WHERE  [Date] ='" + dateTimePicker1.Text + "'";
                        //        string strr = "Select * FROM [Mughluya].[dbo].[tblSoldProduct] WHERE  [Date] >='" + dateTimePicker2.Text + "' And [Date] <= '" + dateTimePicker1.Text + "'";
                        //        SqlCommand cmd = new SqlCommand(strr, con);
                        //        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        //        DataTable dt = new DataTable();
                        //        da.Fill(dt);

                        //        dataGridView1.DataSource = new BindingSource(dt, null);
                        //    }
                        SoldReportForm sf = new SoldReportForm();
                        this.Hide();

                        sf.ShowDialog();
                    }
                }
        }



             catch (Exception)
            {

                MessageBox.Show("Please Select Products..!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            SqlConnection conn = new SqlConnection(DecHelper.ConnectionString);
            conn.Open();
            string str = "  Select [Profit]  FROM [ShopManage].[dbo].[tbltotalsale]  WHERE  [datetime]= '" + Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells[5].Value.ToString()) + "'";
            SqlCommand cmd = new SqlCommand(str, conn);
            SqlDataReader da = cmd.ExecuteReader();
            while (da.Read())
            {
                //  catagrycombobox.Text = da[4].ToString();
                //pricetextBox.Text = da[3].ToString();
                //productnamecomboBox1.Text = da[2].ToString();
                profitlabel5.Text = da[0].ToString();
                // purchasepricelabel.Text = da[6].ToString();
                //purchasepricelabel.Text = da[4].ToString();
                ///  comboBox1.Items.Add(da[0].ToString()
                //  );
            }
            {
                SqlConnection connm = new SqlConnection(DecHelper.ConnectionString);
                connm.Open();
                string strm = "  Select * FROM [ShopManage].[dbo].[tblproducts]  WHERE  [Products]= '" + dataGridView1.SelectedRows[0].Cells[1].Value.ToString() + "'";
                SqlCommand cmdm = new SqlCommand(strm, connm);
                SqlDataReader dam = cmdm.ExecuteReader();
                while (dam.Read())
                {
                    //  catagrycombobox.Text = da[4].ToString();
                    //pricetextBox.Text = da[3].ToString();
                    //productnamecomboBox1.Text = da[2].ToString();
                    quantitylabel.Text = dam[3].ToString();
                    purchasepricelabel.Text = dam[6].ToString();
                    //purchasepricelabel.Text = da[4].ToString();
                    ///  comboBox1.Items.Add(da[0].ToString()
                    //  );
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection((DecHelper.ConnectionString)))
            {
                string str = "Select * FROM [ShopManage].[dbo].[tblSoldProduct] WHERE  [Invoice Num] ='" + textBox1.Text + "'";
              
                SqlCommand cmd = new SqlCommand(str, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = new BindingSource(dt, null);
            }
        }
    }
    }


