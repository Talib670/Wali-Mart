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

namespace ShopMnagementSystem.Screens.Accounts.Expenditures
{
    public partial class AddexpensesForm : Form
    {
        DataClasses11DataContext d = new DataClasses11DataContext();
        public AddexpensesForm()
        {
            InitializeComponent();
        }

        private void closetoolStripButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddexpensesForm_Load(object sender, EventArgs e)
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
            SqlConnection con = new SqlConnection(DecHelper.ConnectionString);
            con.Open();
            string str = "SELECT  * FROM [ShopManage].[dbo].[expensisbqayaamount]  ";
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

        private void newRecordtoolStripButton_Click(object sender, EventArgs e)
        {
            if (IsFormValid())
            {



               tblexpensi t = new tblexpensi();
                t.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                t.Details = detailtextBox.Text;
                t.Name_Amount = nametextBox2.Text;
                t.Jumma_Amount = jummatextBox.Text;
                t.Baqaya_Amount = bqayatextBox1.Text;

                d.tblexpensis.InsertOnSubmit(t);
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

                string str = @" UPDATE [ShopManage].[dbo].[expensisbqayaamount] 
SET [bqayaamount] = '" + bqayatextBox1.Text + "'";

                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            {
                SqlConnection con = new SqlConnection(DecHelper.ConnectionString);
                con.Open();
                string str = "SELECT  * FROM [ShopManage].[dbo].[expensisbqayaamount]   ";
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
                    bqayatextBox1.Text = (Convert.ToDecimal(label5.Text) + Convert.
                           ToDecimal(nametextBox2.Text) - Convert.ToDecimal(jummatextBox.Text)).ToString();
                    total.Text = (Convert.ToDouble(grandtotal.Text) + Convert.ToDouble(jummatextBox.Text) - Convert.ToDouble(nametextBox2.Text)).ToString();

                }
            }
            catch (Exception)
            {

                MessageBox.Show("Please Select Digital Values as 123..!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void nametextBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {

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
                    bqayatextBox1.Text = (Convert.ToDecimal(label5.Text) + Convert.
                           ToDecimal(nametextBox2.Text) - Convert.ToDecimal(jummatextBox.Text)).ToString();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Please Select Digital Values as 123..!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            expensisreportsForm ef = new expensisreportsForm();
            ef.ShowDialog();
        }
    }
    }
   
    

