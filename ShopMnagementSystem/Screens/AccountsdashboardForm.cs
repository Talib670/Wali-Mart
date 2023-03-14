using ShopMnagementSystem.Models;
using ShopMnagementSystem.Screens.Accounts;
using ShopMnagementSystem.Screens.Accounts.Clients_Accounts;
using ShopMnagementSystem.Screens.Accounts.Company_Accounts.Company_Borrow;
using ShopMnagementSystem.Screens.Accounts.Employees;
using ShopMnagementSystem.Screens.Accounts.Expenditures;
using ShopMnagementSystem.Screens.Accounts.Purchase_Accounts;
using ShopMnagementSystem.Screens.Accounts.Sale_Account;
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

namespace ShopMnagementSystem.Screens
{
    public partial class AccountsdashboardForm : Form
    {
   

        public AccountsdashboardForm()
        {
            InitializeComponent();
        }

        private void mToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void taskManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void notpadToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void SystemSetuptoolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void calculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void abouStudentManagemrntSystemToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void newRecordtoolStripButton_Click(object sender, EventArgs e)
        {
            Waqar wf = new Waqar();
            wf.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            GenralPurchasecompanyForm gf = new GenralPurchasecompanyForm();
            gf.ShowDialog();
        }

        private void closetoolStripButton_Click(object sender, EventArgs e)
        {
            PurchaseAccountForm pf = new PurchaseAccountForm();
            pf.ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            addsaleForm af = new addsaleForm();
            af.ShowDialog();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            ClientsForm cf = new ClientsForm();
            cf.ShowDialog();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            AddexpensesForm af = new AddexpensesForm();
            af.ShowDialog();

        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            employeeForm ef = new employeeForm();
            ef.ShowDialog();
        }

        private void AccountsdashboardForm_Load(object sender, EventArgs e)
        {
            {

                SqlConnection con = new SqlConnection(DecHelper.ConnectionString);
                con.Open();
                string str = "SELECT  * FROM [ShopManage].[dbo].[tbltotalsale] Where [datetime]='" + DateTime.Now.ToShortDateString() + "' ";
                SqlCommand cmd = new SqlCommand(str, con);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    totalsale.Text = rd[1].ToString();
                    profitlabel4.Text = rd[4].ToString();
                    purchaselabel4.Text = rd[5].ToString();

                    //txtbal.Text = "";
                    // textacno.Text = "";
                    // textuname.Text= "";
                    //   textnowbal.Visible = true;
                    // textacno.Focus();
                }
            }
            //SqlConnection con = new SqlConnection(DecHelper.ConnectionString);
            //con.Open();
            //string str = "SELECT  * FROM [ShopManage].[dbo].[tblshopgrandtotal]  ";
            //SqlCommand cmd = new SqlCommand(str, con);
            //SqlDataReader rd = cmd.ExecuteReader();
            //while (rd.Read())
            //{
            //    totalsale.Text = rd[1].ToString();

            //    txtbal.Text = "";
            //    textacno.Text = "";
            //    textuname.Text = "";
            //    textnowbal.Visible = true;
            //    textacno.Focus();
            //}
        }

        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
            Company_Borrow_Account ca = new Company_Borrow_Account();
            ca.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //{

            //    SqlConnection con = new SqlConnection(DecHelper.ConnectionString);
            //    con.Open();
            //    string str = "SELECT  * FROM [ShopManage].[dbo].[tbltotalsale] Where [datetime]='" + DateTime.Now.ToShortDateString() + "' ";
            //    SqlCommand cmd = new SqlCommand(str, con);
            //    SqlDataReader rd = cmd.ExecuteReader();
            //    while (rd.Read())
            //    {
            //        totalsale.Text = rd[1].ToString();
            //        profitlabel4.Text = rd[4].ToString();
            //        purchaselabel4.Text = rd[5].ToString();

            //        txtbal.Text = "";
            //        textacno.Text = "";
            //        textuname.Text = "";
            //        textnowbal.Visible = true;
            //        textacno.Focus();
            //    }
            //}
        }
    }
}
