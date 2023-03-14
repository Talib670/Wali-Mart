using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShopMnagementSystem.Models;

namespace ShopMnagementSystem.Screens.Accounts.Clients_Accounts
{
    public partial class newclientForm : Form
    {
        DataClasses13DataContext d = new DataClasses13DataContext();
        DataClasses14DataContext db = new DataClasses14DataContext();
        public newclientForm()
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
                if (recordexist())
                {
                    {

                        tblclientdetail t = new tblclientdetail();
                        t.Name = clientnametextBox.Text;
                        t.Father_Name = fnametextBox2.Text;
                        t.CNIC = cnictextBox.Text;
                        t.Phone_No = phonetextBox1.Text;
                        t.Adress = adressrichTextBox1.Text;

                        d.tblclientdetails.InsertOnSubmit(t);
                        d.SubmitChanges();
                        MessageBox.Show("New Client Account Created SuccessFully...!!!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    {
                        clientbqayaamount s = new clientbqayaamount();
                        s.nameclient = clientnametextBox.Text;
                        s.bqayaamount = "0";
                        db.clientbqayaamounts.InsertOnSubmit(s);
                        db.SubmitChanges();
                    }
                }
            }
    }
        private bool recordexist()
        {
            var reg = clientnametextBox.Text;
            var fa = fnametextBox2.Text;


            var dc = d.tblclientdetails.Where(o => o.Name == reg).FirstOrDefault();
            var df = d.tblclientdetails.Where(o => o.Father_Name == fa).FirstOrDefault();



            if (dc != null || df!=null)
            {
                  MessageBox.Show("Client Name  Already Exist!!!!!... .  ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;


            }
            return true;
        }
        private bool IsFormValid()
        {
            {
                if (clientnametextBox.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Client Name is Required..!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    clientnametextBox.Focus();
                    return false;
                }
                if (adressrichTextBox1.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("client Address is Required..!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    adressrichTextBox1.Focus();
                    return false;
                }
                if (cnictextBox.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("client cnic is Required..!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cnictextBox.Focus();
                    return false;
                }
                if (fnametextBox2.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Client Father Name is Required..!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   fnametextBox2.Focus();
                    return false;
                }
                if (phonetextBox1.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Client Phone Number is Required..!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    phonetextBox1.Focus();
                    return false;
                }
                return true;
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            newclientreportForm nf = new newclientreportForm();
            nf.ShowDialog();
        }
    }
}
