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
using ShopMnagementSystem.Screens;
using ShopMnagementSystem.Models;

namespace ShopMnagementSystem.Screens
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        public static string username;

        public static string recby
        {
            get { return username; }
            set { username = value; }

        }


        
        private void button1_Click(object sender, EventArgs e)
        {
            
            if (isformvalid())
            {

               

                SqlCommand cmd = new SqlCommand("SELECT * FROM [ShopManage].[dbo].[tblLogin] WHERE [User Name]=@username AND [Password]=@password;", new SqlConnection(DecHelper.ConnectionString));
                cmd.Parameters.AddWithValue("@username", usernametextBox.Text.ToString());

                cmd.Parameters.AddWithValue("@password", passtextBox.Text.ToString());
                cmd.Connection.Open();
                using (cmd.Connection)
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        recby = usernametextBox.Text;
                        this.Hide();
                        DashboardForm d = new DashboardForm();
                        d.Show();
                    }
                    else
                    {

                        MessageBox.Show("UserName/Password is incorrect..!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                }
            }

            bool isformvalid()
            {
                if (usernametextBox.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("User Name is Required..!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    usernametextBox.Clear();
                    usernametextBox.Focus();
                    return false;
                }
                if (passtextBox.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Password is Required..!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    usernametextBox.Clear();
                    usernametextBox.Focus();
                    return false;
                }
                return true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
            if (e.KeyCode == Keys.Escape)
            {
                button2.PerformClick();
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
           
            this.KeyPreview = true;
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox1.Checked)
            {
                passtextBox.UseSystemPasswordChar = false;
            }
            else
            {
                passtextBox.UseSystemPasswordChar = true;
            }
        }

        private void usernametextBox_TextChanged(object sender, EventArgs e)
        {
        
        }
    }
}
