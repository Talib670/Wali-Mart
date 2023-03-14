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
using ShopMnagementSystem.Screens.Accounts.Company_Accounts;

namespace ShopMnagementSystem.Screens.Accounts
{
    public partial class GenralPurchasecompanyForm : Form
    {
        DataClasses7DataContext d = new DataClasses7DataContext();
        public GenralPurchasecompanyForm()
        {
            InitializeComponent();
        }

        private void newRecordtoolStripButton_Click(object sender, EventArgs e)
        {
            if (IsFormValid())
            {



                GenralPurchase t = new GenralPurchase();
                t.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                t.Details = detailtextBox.Text;
                t.Name_Amount = nametextBox2.Text;
                t.Jumma_Amount = jummatextBox.Text;
                t.Baqaya_Amount = bqayatextBox1.Text;

                d.GenralPurchases.InsertOnSubmit(t);
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

            }
        }
        private bool IsFormValid()
        {
            {
                if (detailtextBox.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Comapany Details is Required..!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    detailtextBox.Focus();
                    return false;
                }
                if (nametextBox2.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Name Amount is Required..!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    nametextBox2.Focus();
                    return false;
                }
                if (jummatextBox.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("jumma Amount is Required..!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    jummatextBox.Focus();
                    return false;
                }
                if (bqayatextBox1.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Buqaya Amount is Required..!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bqayatextBox1.Focus();
                    return false;
                }
                return true;
            }
        }

        private void jummatextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {


                if (jummatextBox.Text.Length > 0)
                {
                    label7.Text = NumberToWord(Convert.ToInt32(jummatextBox.Text));
                    bqayatextBox1.Text =  ( Convert.ToDecimal(nametextBox2.Text) - Convert.ToDecimal(jummatextBox.Text)).ToString();
                    total.Text = (Convert.ToDouble(grandtotal.Text) + Convert.ToDouble(jummatextBox.Text) - Convert.ToDouble(nametextBox2.Text)).ToString();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Please Select Digital Values as 123..!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ReportForm gf = new ReportForm();
            gf.ShowDialog();
        }

        private void closetoolStripButton_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void GenralPurchasecompanyForm_Load(object sender, EventArgs e)
        {
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
            }
           
        }

        private void nametextBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (nametextBox2.Text.Length > 0)
                {
                    label7.Text = NumberToWord(Convert.ToInt32(nametextBox2.Text));
                    total.Text = (Convert.ToDouble(grandtotal.Text) + Convert.ToDouble(jummatextBox.Text) - Convert.ToDouble(nametextBox2.Text)).ToString();

                }
            }
            catch (Exception)
            {

                MessageBox.Show("Please Select Digital Values as 123..!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
