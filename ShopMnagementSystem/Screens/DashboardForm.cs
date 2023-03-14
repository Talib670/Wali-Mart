using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

using ShopMnagementSystem.Models;
using ShopMnagementSystem.Screens.Accounts;
using ShopMnagementSystem.Screens.Accounts.Clients_Accounts;

namespace ShopMnagementSystem.Screens
{
    public partial class DashboardForm : Form
    {
        DataClasses2DataContext d = new DataClasses2DataContext();
        public DashboardForm()
        {
            InitializeComponent();
        }

        private void ManageBranchestoolStripButton_Click(object sender, EventArgs e)
        {
            ProductsViewForm a = new ProductsViewForm();
            a.ShowDialog();
        }

        private void newstudenttoolStripButton_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.loginuser.Text = textBox1.Text;
            f.ShowDialog();
            
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            {
                using (System.Data.SqlClient.SqlConnection con = new SqlConnection((DecHelper.ConnectionString)))
                {
                    // int t = 15;
                    ///String exp =(Convert.ToInt32(DateTime.Now.ToShortDateString() -Convert.ToInt32( 15)).ToString();

                    /// string exp = "Select  *  FROM [ShopManage].[dbo].[tblproducts] WHERE  [Expirydate] < date_sub('"+DateTime.Now.ToShortDateString()+"', interval 3 month)";
                    string str = "select * FROM [ShopManage].[dbo].[tblproductsexpiry] where DATEDIFF(day, GETDATE(), [Expirydate]) <= 15  AND [Expirydate]>'" + DateTime.Now.ToShortDateString() + "' ";
                    ///  
                    // TimeSpan t = Convert.ToDateTime(str) - Convert.ToDateTime(DateTime.Now.ToShortDateString());
                    ///   if (Convert.ToInt32(exp) > Convert.ToInt32((t)))



                    SqlCommand cmdd = new SqlCommand(str, con);
                    SqlDataAdapter das = new SqlDataAdapter(cmdd);
                    DataTable dt = new DataTable();
                    das.Fill(dt);

                    dataGridView1.DataSource = new BindingSource(dt, null);
                }
                textBox1.Visible = false;
                loginuser.Text = LoginForm.recby;
                textBox1.Text = LoginForm.recby;

                if (recordexist())
                {

                    tbltotalsale t = new tbltotalsale();

                    t.datetime = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                    t.totalsale = "0";
                    t.Recipt_No = "1";
                    t.Profit = "0";
                    t.Totalpurchase = "0";
                    d.tbltotalsales.InsertOnSubmit(t);
                    d.SubmitChanges();

                }
               
            }
        }
        private bool recordexist()
        {
            DateTime reg = Convert.ToDateTime(DateTime.Now.ToShortDateString());

            var dc = d.tbltotalsales.Where(o => o.datetime == reg).FirstOrDefault();
           


            if (dc != null)
            {
              ///  MessageBox.Show("Product Record Already Exist!!!!!..... Please Update .  ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;


            }
            return true;
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void abouStudentManagemrntSystemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm af = new AboutForm();
            af.ShowDialog();
        }

        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
            Application.Exit();
        }

        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            HelpForm hf = new HelpForm();
            hf.ShowDialog();
        }

        private void calculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Calc.exe");
        }

        private void notpadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Notepad.exe");
        }

        private void taskManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("TaskMgr.exe");
        }

        private void mToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Winword.exe");
        }

        private void wordPadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Wordpad.exe");
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void ts_StockOut_Click(object sender, EventArgs e)
        {
            ManageReports mp = new ManageReports();
            mp.ShowDialog();
        }

        private void EditProfiletoolStripButton_Click(object sender, EventArgs e)
        {
            changepassForm cf = new changepassForm();
            cf.ShowDialog();
        }

        private void SystemSetuptoolStripButton_Click(object sender, EventArgs e)
        {
            usersForm uf = new usersForm();
                uf.ShowDialog();
        }

        private void HelpandSupporttoolStripButton_Click(object sender, EventArgs e)
        {
            HelpForm hf = new HelpForm();
            hf.ShowDialog();
        }

        private void ManageUserstoolStripButton_Click(object sender, EventArgs e)
        {
            AccountsdashboardForm cf = new AccountsdashboardForm();
            cf.ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
          CompanyAccountsForm  cf = new CompanyAccountsForm();
            cf.ShowDialog();
        }
    }
}
