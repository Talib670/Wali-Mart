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

namespace ShopMnagementSystem.Screens
{
    public partial class usersForm : Form
    {
        DataClasses4DataContext d = new DataClasses4DataContext();
        public usersForm()
        {
            InitializeComponent();
        }

        private void studentrecordtoolStripButton1_Click(object sender, EventArgs e)
        {
            changepassForm cf = new changepassForm();
            cf.ShowDialog();
        }

        private void closetoolStripButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void usersForm_Load(object sender, EventArgs e)
        {
            
            this.KeyPreview = true;
            var branch = d.tblLogins.ToList();
            foreach (var i in branch)
            {
                comboBox1.Items.Add(i.User_Name);
            }
        }

        private void usersForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                closetoolStripButton.PerformClick();
            } 
        }
    }
}
