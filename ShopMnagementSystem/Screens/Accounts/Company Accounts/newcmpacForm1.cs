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
using ShopMnagementSystem.Screens.Accounts.Company_Accounts.Company_Borrow;

namespace ShopMnagementSystem.Screens.Accounts.Company_Accounts
{
    public partial class newcmpacForm1 : Form
    {
        DataClasses16DataContext d = new DataClasses16DataContext();
        DataClasses17DataContext db = new DataClasses17DataContext();
        public newcmpacForm1()
        {
            InitializeComponent();
        }

        private void newRecordtoolStripButton_Click(object sender, EventArgs e)
        {
            if (IsFormValid())
            {
                if (recordexist())
                { 
                {

                    tblcompanyacdetail t = new tblcompanyacdetail();
                    t.Company_Name = cmpnynametextbox.Text;
                    t.Order_Booker_Name = obnamenametextBox2.Text;
                    t.OB_Contact = obcontacttextBox.Text;
                    t.SO_Phone_No = phonetextBox1.Text;


                    d.tblcompanyacdetails.InsertOnSubmit(t);
                    d.SubmitChanges();
                    MessageBox.Show("New Company Account Created SuccessFully...!!!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                {
                    companybqayaamount s = new companybqayaamount();
                    s.namecompany = cmpnynametextbox.Text;
                    s.bqayaamount = "0";
                    db.companybqayaamounts.InsertOnSubmit(s);
                    db.SubmitChanges();
                }
                {
                    DataClasses20DataContext ds = new DataClasses20DataContext();
                    companyborrowbqayaamount nu = new companyborrowbqayaamount();
                    nu.namecompany = cmpnynametextbox.Text;
                    nu.bqayaamount = "0";
                    ds.companyborrowbqayaamounts.InsertOnSubmit(nu);
                    ds.SubmitChanges();
                }
            }
        }
        }
        private bool IsFormValid()
        {
            {
                if (cmpnynametextbox.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Company Name is Required..!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmpnynametextbox.Focus();
                    return false;
                }
           
                if (obcontacttextBox.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Sale Officer Contact is Required..!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    obcontacttextBox.Focus();
                    return false;
                }
                if (obnamenametextBox2.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Sale Officer Name Name is Required..!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    obnamenametextBox2.Focus();
                    return false;
                }
                if (phonetextBox1.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("SO Phone Phone Number is Required..!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    phonetextBox1.Focus();
                    return false;
                }
                return true;
            }
        }
        private bool recordexist()
        {
            var reg =cmpnynametextbox.Text;
           // var f = fnametextBox2.Text;
           
            var db = d.tblcompanyacdetails.Where(o => o.Company_Name == reg).FirstOrDefault();
           // var dc = d.tblcompanyacdetails.Where(o => o.Order_Booker_Name == f).FirstOrDefault();


            if (db != null)
            {
                MessageBox.Show("Company Account  Already Exist!!!!!..... Please Update .  ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;


            }
            return true;
        }


        private void closetoolStripButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            cmpreportsForm1 cf = new cmpreportsForm1();
            cf.ShowDialog();
        }

        private void newcmpacForm1_Load(object sender, EventArgs e)
        {

        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(DecHelper.ConnectionString);
            con.Open();
            //StudentB s = new StudentB();
            //MemoryStream ms = new MemoryStream();
            //i.Save(ms, ImageFormat.Jpeg);
            //byte[] arrrrr = ms.ToArray();

            string str = @" UPDATE [ShopManage].[dbo].[tblcompanyacdetail]
SET  [Order Booker Name] = '" + obnamenametextBox2.Text + "', [OB Contact] = '" + obcontacttextBox.Text + "',  [SO Phone No] ='" + phonetextBox1.Text + "'   WHERE ([Company Name] = '" + cmpnynametextbox.Text + "')";

            SqlCommand cmd = new SqlCommand(str, con);
            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Company Record Update SuccessFully...!!!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }
    }
    }

