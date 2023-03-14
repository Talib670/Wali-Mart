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

namespace ShopMnagementSystem.Screens
{
    public partial class changepassForm : Form
    {
        public changepassForm()
        {
            InitializeComponent();
        }

        private void changepassForm_Load(object sender, EventArgs e)
        {

        }
        private bool ispasswordcorrect()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM [ShopManage].[dbo].[tblLogin] WHERE [User Name]=@username AND [Password]=@password;", new SqlConnection(DecHelper.ConnectionString));
            cmd.Parameters.AddWithValue("@username", fullnametextBox.Text.ToString());

            cmd.Parameters.AddWithValue("@password", txtOldPassword.Text.ToString());
            cmd.Connection.Open();
            using (cmd.Connection)
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {

                    SqlConnection con = new SqlConnection(DecHelper.ConnectionString);
                    con.Open();


                    string str = @" UPDATE tbllogin SET password = '" + txtConfirmPassword.Text + "'WHERE ( [User Name] = '" + fullnametextBox.Text + "' )";

                    SqlCommand cmb = new SqlCommand(str, con);
                    cmb.ExecuteNonQuery();


                    con.Close();
                    MessageBox.Show("User Password Change SuccessFully...!!!", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                    MessageBox.Show("User Full Name/ Old Password is incorrect..!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }

            return true;
        }
        private bool isformvalid()
        {

            if (fullnametextBox.Text == string.Empty)
            {
                MessageBox.Show("Full Name is required....!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                fullnametextBox.Focus();
                return false;
            }
            if (txtOldPassword.Text == string.Empty)
            {
                MessageBox.Show("old Password is required....!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtOldPassword.Focus();
                return false;
            }

            if (txtNewPassword.Text == string.Empty)
            {
                MessageBox.Show("New Password is required....!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNewPassword.Focus();
                return false;
            }

            if (txtConfirmPassword.Text == string.Empty)
            {
                MessageBox.Show("Confirm Password is required....!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtConfirmPassword.Focus();
                return false;
            }

            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("New And Confirm Password Are Not Same...!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;

        }

        private void fullnametextBox_TextChanged(object sender, EventArgs e)
        {
            toppanellabel.Text = fullnametextBox.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isformvalid())
            {


                ispasswordcorrect();
            }
            txtConfirmPassword.Text = string.Empty;
            txtNewPassword.Text = string.Empty;

            txtOldPassword.Text = string.Empty;
            fullnametextBox.Text = string.Empty;
        }
    }
}
