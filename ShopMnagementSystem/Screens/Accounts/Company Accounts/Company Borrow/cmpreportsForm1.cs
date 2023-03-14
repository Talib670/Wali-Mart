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
namespace ShopMnagementSystem.Screens.Accounts.Company_Accounts.Company_Borrow
{
    public partial class cmpreportsForm1 : Form
    {
        DataClasses16DataContext d = new DataClasses16DataContext();
        public cmpreportsForm1()
        {
            InitializeComponent();
        }

        private void cmpreportsForm1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = d.tblcompanyacdetails.ToList();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            newcmpacForm1 c = new newcmpacForm1();
           
            c.cmpnynametextbox.Text= dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            c.obnamenametextBox2.Text= dataGridView1.SelectedRows[0].Cells[2].Value.ToString();

            c.obcontacttextBox.Text= dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            c.phonetextBox1.Text= dataGridView1.SelectedRows[0].Cells[4].Value.ToString();

            c.ShowDialog();
        }
    }
}
