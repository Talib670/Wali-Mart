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

namespace ShopMnagementSystem.Screens.Accounts
{
    public partial class Waqar : Form
    {
        DataClasses5DataContext d = new DataClasses5DataContext();
        public Waqar()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void Waqar_Load(object sender, EventArgs e)
        {
            {
                total.Visible = false;
                {
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
            label5.Visible = false;
            SqlConnection con = new SqlConnection(DecHelper.ConnectionString);
            con.Open();
            string str = "SELECT  * FROM [ShopManage].[dbo].[dtrwqrbqayaamount]  ";
            SqlCommand cmd = new SqlCommand(str, con);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                comboBox1.Items.Add(rd[1].ToString());
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


                dtrwqar t = new dtrwqar();
                t.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                t.Details = comboBox1.Text;
                t.Name_Amount = nametextBox2.Text;
                t.Jumma_Amount = jummatextBox.Text;
                t.Baqaya_Amount = bqayatextBox1.Text;

                d.dtrwqars.InsertOnSubmit(t);
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

                    string str = @" UPDATE  [ShopManage].[dbo].[dtrwqrbqayaamount]
SET [bqayaamount] = '" + bqayatextBox1.Text + "'";

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

            }

        }

        private bool IsFormValid()
        {
            {
                if (comboBox1.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Invester Details is Required..!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   comboBox1.Focus();
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
                bqayatextBox1.Text = (Convert.ToDecimal(label5.Text) - Convert.
                       ToDecimal(nametextBox2.Text) + Convert.ToDecimal(jummatextBox.Text)).ToString();
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
            waqarreportForm wf = new waqarreportForm();
            wf.ShowDialog();
        }

        private void closetoolStripButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nametextBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (nametextBox2.Text.Length > 0)
            {
                total.Text = (Convert.ToDouble(grandtotal.Text) + Convert.ToDouble(jummatextBox.Text) - Convert.ToDouble(nametextBox2.Text)).ToString();
                    bqayatextBox1.Text = (Convert.ToDecimal(label5.Text) - Convert.
                        ToDecimal(nametextBox2.Text) + Convert.ToDecimal(jummatextBox.Text)).ToString();
                } 
        }
            catch (Exception)
            {

                MessageBox.Show("Please Select Digital Values as 123..!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void total_Click(object sender, EventArgs e)
        {

        }

        private void grandtotal_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            {
                SqlConnection conn = new SqlConnection(DecHelper.ConnectionString);
                conn.Open();
                string str = "  SELECT  * FROM [ShopManage].[dbo].[dtrwqrbqayaamount]  WHERE  [nameclient]= '" + comboBox1.Text + "'";
                SqlCommand cmd = new SqlCommand(str, conn);
                SqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {
                    label5.Text = da[2].ToString();
                    //  purchasepricelabel.Text = da[6].ToString();
                }
            }

        }
    }
}
    

