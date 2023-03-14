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
namespace ShopMnagementSystem.Screens.Accounts.Employees
{
    public partial class employeeForm : Form
    {
        DataClasses12DataContext d = new DataClasses12DataContext();
        public employeeForm()
        {
            InitializeComponent();
        }

        private void employeeForm_Load(object sender, EventArgs e)
        {
          //  timer1.Start();
            //timer1.Enabled = true;
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
                label5.Visible = false;
                {
                    SqlConnection conn = new SqlConnection(DecHelper.ConnectionString);
                    conn.Open();
                    string str = "  Select * FROM [ShopManage].[dbo].[employeebqayaamount]";
                    SqlCommand cmd = new SqlCommand(str, conn);
                    SqlDataReader da = cmd.ExecuteReader();
                    while (da.Read())
                    {
                        comboBox1.Items.Add(da[1].ToString());
                        //  purchasepricelabel.Text = da[6].ToString();
                    }
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            {
                SqlConnection conn = new SqlConnection(DecHelper.ConnectionString);
                conn.Open();
                string str = " Select * FROM [ShopManage].[dbo].[employeebqayaamount] WHERE  [nameemployee]= '" + comboBox1.Text + "'";
                SqlCommand cmd = new SqlCommand(str, conn);
                SqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {
                    label5.Text = da[2].ToString();
                    //  purchasepricelabel.Text = da[6].ToString();
                }
            }

        }

        private void newRecordtoolStripButton_Click(object sender, EventArgs e)
        {
            if (IsFormValid())
            {



                tblemployee t = new tblemployee();
                t.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                t.Details = detailtextBox.Text;
                t.Name_Amount = nametextBox2.Text;
                t.Jumma_Amount = jummatextBox.Text;
                t.Bqaya_Amount = bqayatextBox1.Text;
                t.Employee_Name = comboBox1.Text;

                d.tblemployees.InsertOnSubmit(t);
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

                    string str = @" UPDATE [ShopManage].[dbo].[employeebqayaamount]
SET [bqayaamount]= '" + bqayatextBox1.Text + "'  WHERE [nameemployee] = '" + comboBox1.Text + "'";

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
                    MessageBox.Show(" Details is Required..!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            employeereportForm ef = new employeereportForm();
            ef.ShowDialog();

        }

        private void nametextBox2_TextChanged(object sender, EventArgs e)
        {
         
            try
            {
                label7.Text = NumberToWord(Convert.ToInt32(nametextBox2.Text));
                if (nametextBox2.Text.Length > 0)
                {
                    total.Text = (Convert.ToDouble(grandtotal.Text) + Convert.ToDouble(jummatextBox.Text) - Convert.ToDouble(nametextBox2.Text)).ToString();

                }
            }
            catch (Exception)
            {

                MessageBox.Show("Please Select Digital Values as 123..!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {


                if (nametextBox2.Text.Length > 0)
                {
                    bqayatextBox1.Text = (Convert.ToDecimal(label5.Text) - Convert.
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
           
            try
            {
                label7.Text = NumberToWord(Convert.ToInt32(jummatextBox.Text));

                if (jummatextBox.Text.Length > 0)
                {
                    bqayatextBox1.Text = (Convert.ToDecimal(label5.Text) + Convert.
                           ToDecimal(jummatextBox.Text)).ToString();
                    total.Text = (Convert.ToDouble(grandtotal.Text) + Convert.ToDouble(jummatextBox.Text) - Convert.ToDouble(nametextBox2.Text)).ToString();
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
        public  static string NumberToWord(int numbers)
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
                var unitsmap = new[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Ninteen"};
                var tenmap = new[] { "Zero", "Ten", "Twenty", "Thirty", "Fourty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninty" };
                if (numbers<20) words +=unitsmap[numbers];
                else
                {
                    words += tenmap[numbers/10];
                    if ((numbers % 10) > 0) words += "-" + unitsmap[numbers % 10];
             
                }
               
               
            }
            return words;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //label7.Text = NumberToWord(Convert.ToInt32(nametextBox2.Text));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random rand = new Random();
            int one = rand.Next(0,255);
            int Two = rand.Next(0,255);
            int Three = rand.Next(0,255);
            int Four = rand.Next(0,255);
            label7.ForeColor = Color.FromArgb(one, Two, Three, Four);

        }
    }
}
