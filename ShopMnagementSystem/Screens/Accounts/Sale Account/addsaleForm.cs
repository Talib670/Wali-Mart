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
using ShopMnagementSystem.Models;

namespace ShopMnagementSystem.Screens.Accounts.Sale_Account
{
    public partial class addsaleForm : Form
    {
        DataClasses9DataContext d = new DataClasses9DataContext();
        public addsaleForm()
        {
            InitializeComponent();
        }

        private void closetoolStripButton_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void newRecordtoolStripButton_Click(object sender, EventArgs e)
        {
            if (IsFormValid())
            {



                SaleAccount t = new SaleAccount();
                t.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                t.Computer_Sale = cmputersaletextBox.Text;
                t.Name_Amount = nametextBox2.Text;
                t.Jumma_Amount = jummatextBox1.Text;
                t.Baqaya_Amount = bqayatextBox2.Text;
                t.Biscuit_Tofee_Sale = biscuittextBox1.Text;
                t.Load_Sale = jazzloadtextBox.Text;

                d.SaleAccounts.InsertOnSubmit(t);
                d.SubmitChanges();
                MessageBox.Show("Products Record Save SuccessFully...!!!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            {
                SqlConnection conn = new SqlConnection(DecHelper.ConnectionString);
                conn.Open();
                //StudentB s = new StudentB();
                //MemoryStream ms = new MemoryStream();
                //i.Save(ms, ImageFormat.Jpeg);
                //byte[] arrrrr = ms.ToArray();

                string str = @" UPDATE  [ShopManage].[dbo].[tblshopgrandtotal]
SET [Grand Total] = '" + total.Text + "'";

                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            {
                SqlConnection conn = new SqlConnection(DecHelper.ConnectionString);
                conn.Open();
                //StudentB s = new StudentB();
                //MemoryStream ms = new MemoryStream();
                //i.Save(ms, ImageFormat.Jpeg);
                //byte[] arrrrr = ms.ToArray();

                string str = @" UPDATE  [ShopManage].[dbo].[saleaccountbqayaamount]
SET [bqayaamount] = '" + bqayatextBox2.Text + "'";

                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            {
                SqlConnection con = new SqlConnection(DecHelper.ConnectionString);
                con.Open();
                string str = "SELECT  * FROM [ShopManage].[dbo].[dtrwqrbqayaamount]  ";
                SqlCommand cmd = new SqlCommand(str, con);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    label5.Text = rd[1].ToString();

                    //txtbal.Text = "";
                    // textacno.Text = "";
                    // textuname.Text= "";
                    //   textnowbal.Visible = true;
                    // textacno.Focus();
                }
            }
                {
                    total.Visible = false;
                    grandtotal.Visible = false;
                    SqlConnection conn = new SqlConnection(DecHelper.ConnectionString);
                    conn.Open();
                    string strr = "SELECT  * FROM [ShopManage].[dbo].[tblshopgrandtotal]  ";
                    SqlCommand cmdd = new SqlCommand(strr, conn);
                    SqlDataReader rdd = cmdd.ExecuteReader();
                    while (rdd.Read())
                    {
                        grandtotal.Text = rdd[1].ToString();

                        //txtbal.Text = "";
                        // textacno.Text = "";
                        // textuname.Text= "";
                        //   textnowbal.Visible = true;
                        // textacno.Focus();
                    }
                }
                {
                    label5.Visible = false;
                    SqlConnection con = new SqlConnection(DecHelper.ConnectionString);
                    con.Open();
                    string str = "SELECT  * FROM [ShopManage].[dbo].[saleaccountbqayaamount] ";
                    SqlCommand cmd = new SqlCommand(str, con);
                    SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        label5.Text = rd[1].ToString();

                        //txtbal.Text = "";
                        // textacno.Text = "";
                        // textuname.Text= "";
                        //   textnowbal.Visible = true;
                        // textacno.Focus();
                    }
                    {
                        SqlConnection conn = new SqlConnection(DecHelper.ConnectionString);
                        conn.Open();
                        string strr = "SELECT  [totalsale] FROM [ShopManage].[dbo].[tbltotalsale] WHERE [datetime] = '" + DateTime.Now.ToShortDateString() + "' ";
                        SqlCommand cmdd = new SqlCommand(strr, conn);
                        SqlDataReader rdd = cmdd.ExecuteReader();
                        while (rdd.Read())
                        {
                            cmputersaletextBox.Text = rdd[0].ToString();
                            //txtbal.Text = "";
                            // textacno.Text = "";
                            // textuname.Text= "";
                            //   textnowbal.Visible = true;
                            // textacno.Focus();
                        }
                        conn.Close();
                    }
                }
            }
        }

        private bool IsFormValid()
        {
            {
                if (cmputersaletextBox.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Computer Sale is Required..!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmputersaletextBox.Focus();
                    return false;
                }
                if (nametextBox2.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Name Amount is Required..!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    nametextBox2.Focus();
                    return false;
                }
                if (jummatextBox1.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("jumma Amount is Required..!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    jummatextBox1.Focus();
                    return false;
                }
                if (bqayatextBox2.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Buqaya Amount is Required..!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bqayatextBox2.Focus();
                    return false;
                }
                if (jazzloadtextBox.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Jaz Sale is Required..!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    jazzloadtextBox.Focus();
                    return false;
                }
                if (biscuittextBox1.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Biscuit Tofee  Sale is Required..!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    biscuittextBox1.Focus();
                    return false;
                }
                return true;
            }
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
                var unitsmap = new[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Ninteen" };
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
        private void addsaleForm_Load(object sender, EventArgs e)
        {
            {
                total.Visible = false;
                grandtotal.Visible = false;
                SqlConnection conn = new SqlConnection(DecHelper.ConnectionString);
                conn.Open();
                string strr = "SELECT  * FROM [ShopManage].[dbo].[tblshopgrandtotal]  ";
                SqlCommand cmdd = new SqlCommand(strr, conn);
                SqlDataReader rdd = cmdd.ExecuteReader();
                while (rdd.Read())
                {
                    grandtotal.Text = rdd[1].ToString();

                    //txtbal.Text = "";
                    // textacno.Text = "";
                    // textuname.Text= "";
                    //   textnowbal.Visible = true;
                    // textacno.Focus();
                }
            }
            {
                label5.Visible = false;
                SqlConnection con = new SqlConnection(DecHelper.ConnectionString);
                con.Open();
                string str = "SELECT  * FROM [ShopManage].[dbo].[saleaccountbqayaamount] ";
                SqlCommand cmd = new SqlCommand(str, con);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    label5.Text = rd[1].ToString();

                    //txtbal.Text = "";
                    // textacno.Text = "";
                    // textuname.Text= "";
                    //   textnowbal.Visible = true;
                    // textacno.Focus();
                }
                {
                    SqlConnection conn = new SqlConnection(DecHelper.ConnectionString);
                    conn.Open();
                    string strr = "SELECT  [totalsale] FROM [ShopManage].[dbo].[tbltotalsale] WHERE [datetime] = '" + DateTime.Now.ToShortDateString() + "' ";
                    SqlCommand cmdd = new SqlCommand(strr, conn);
                    SqlDataReader rdd = cmdd.ExecuteReader();
                    while (rdd.Read())
                    {
                        cmputersaletextBox.Text = rdd[0].ToString();
                        //txtbal.Text = "";
                        // textacno.Text = "";
                        // textuname.Text= "";
                        //   textnowbal.Visible = true;
                        // textacno.Focus();
                    }
                    conn.Close();
                }
            }
        }
        private void jazzloadtextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {


                if (jazzloadtextBox.Text.Length > 0)
                    jummatextBox1.Text = (Convert.ToDecimal(cmputersaletextBox.Text) + Convert.
       ToDecimal(nametextBox2.Text)  + Convert.ToDecimal(jazzloadtextBox.Text) + Convert.ToDecimal(biscuittextBox1.Text)).ToString();
            }

            catch (Exception)
            {

                MessageBox.Show("Please Select Digital Values as 123..!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void jummatextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {


                if (jummatextBox1.Text.Length > 0)
                {
                    bqayatextBox2.Text = (Convert.ToDecimal(jummatextBox1.Text) + Convert.
       ToDecimal(label5.Text)).ToString();
                    total.Text = (Convert.ToDouble(grandtotal.Text) + Convert.ToDouble(jummatextBox1.Text) - Convert.ToDouble(nametextBox2.Text)).ToString();

                }
            }

            catch (Exception)
            {

                MessageBox.Show("Please Select Digital Values as 123..!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            SaleaccountForm sf = new SaleaccountForm();
            sf.ShowDialog();
        }

        private void nametextBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (nametextBox2.Text.Length > 0)
                {
                    total.Text = (Convert.ToDouble(grandtotal.Text) + Convert.ToDouble(jummatextBox1.Text) - Convert.ToDouble(nametextBox2.Text)).ToString();

                }
            }
            catch (Exception)
            {

                MessageBox.Show("Please Select Digital Values as 123..!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bqayatextBox2_TextChanged(object sender, EventArgs e)
        {
            label8.Text = NumberToWord(Convert.ToInt32(bqayatextBox2.Text));
        }
    }
}
