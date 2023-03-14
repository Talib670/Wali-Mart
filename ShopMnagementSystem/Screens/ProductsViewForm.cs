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

namespace ShopMnagementSystem.Screens
{
    public partial class ProductsViewForm : Form
    {
        int maxcolumn;
        int inc = 0;
        int maxrow;
        DataClasses1DataContext d = new DataClasses1DataContext();
        public ProductsViewForm()
        {
            InitializeComponent();
        }

        private void ProductsViewForm_Load(object sender, EventArgs e)
        {
           
            button1.Visible = false;
            label1.Visible = false;

            this.KeyPreview = true;
            dataGridView1.DataSource = d.tblproducts.ToList();

            textBox2.Text = "0";
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                textBox2.Text = Convert.ToString(double.Parse(textBox2.Text) + (double.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString()) * double.Parse(dataGridView1.Rows[i].Cells[6].Value.ToString())));

            }
        }

        private void searchbutton_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == " ")
            {
                MessageBox.Show("Please Enter Valid Product Name OR Catagary OR Price t....!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                using (SqlConnection con = new SqlConnection((DecHelper.ConnectionString)))
                {

                    string str = "Select * FROM [ShopManage].[dbo].[tblproducts] WHERE [Products] LIKE '%" + textBox1.Text + "%' OR [Company Name] LIKE '%" + textBox1.Text + "%'OR [Price] LIKE '%" + textBox1.Text + "%' OR [Quantity] LIKE '%" + textBox1.Text + "%' OR [Catagary] LIKE '%" + textBox1.Text + "%' OR [Barcode] LIKE '%" + textBox1.Text + "%'";

                    SqlCommand cmd = new SqlCommand(str, con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.DataSource = new BindingSource(dt, null);

                }
                textBox1.Text = "";
            }
        }

        private void SaveRecordtoolStripButton_Click(object sender, EventArgs e)
        {
            AddProductForm a = new AddProductForm();
            a.ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do You Want Delete Product Record....!!!!", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
            {

                int tid = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                tblproduct item = d.tblproducts.Where(o => o.id == tid).FirstOrDefault();
                d.tblproducts.DeleteOnSubmit(item);

                d.SubmitChanges();
                MessageBox.Show("Product Record Delete SuccessFully....!!!!", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                var list = d.tblproducts.ToList();
                dataGridView1.DataSource = list;
            }

        }

        private void closetoolStripButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            AddProductForm ef = new AddProductForm();
            ef.Show();
            ef.producthnametextBox.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            ef.priceltextBox.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            ef.quantitytextBox.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            ef.catagorytextBox.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            ef.barcodetextBox2.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            ef.buytextBox1.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnfirst_Click(object sender, EventArgs e)
        {
            inc = 1;
            lblinc.Text = inc.ToString();
            inc = 0;
            //navigate_records(inc);
        }

        private void ProductsViewForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.N)
            {
                newRecordtoolStripButton.PerformClick();
            }
            if (e.Control == true && e.KeyCode == Keys.U)
            {
                toolStripButton2.PerformClick();
            }
            if (e.KeyCode == Keys.Escape)
            {
                closetoolStripButton.PerformClick();
            }
            if (e.KeyCode == Keys.Delete)
            {
             deletetoolStripButton1.PerformClick();
            }
            if (e.KeyCode == Keys.Enter)
            {
                searchbutton.PerformClick();
            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var query = from c in d.tblproducts
                        where System.Data.Linq.SqlClient.SqlMethods.Like(c.Products, "%" + textBox1.Text + "%")
                        select new
                        {
                            c.Products
                            ,
                             c.Price
            };
           /// var db = d.tblproducts.Where(o => o.Products.("%/cus/%")).ToList();
            dataGridView1.DataSource = query.ToList();
            //using (SqlConnection con = new SqlConnection((DecHelper.ConnectionString)))
            //{

            //    string str = "Select * FROM [ShopManage].[dbo].[tblproducts] WHERE [Products] LIKE '%" + textBox1.Text + "%' OR [Price] LIKE '%" + textBox1.Text + "%' OR [Quantity] LIKE '%" + textBox1.Text + "%' OR [Catagary] LIKE '%" + textBox1.Text + "%' OR [Barcode] LIKE '%" + textBox1.Text + "%'  OR [Buy Price] LIKE '%" + textBox1.Text + "%' OR [Company Name]  LIKE '%" + textBox1.Text + "%' ";
            //    SqlCommand cmd = new SqlCommand(str, con);
            //    SqlDataAdapter da = new SqlDataAdapter(cmd);
            //    DataTable dt = new DataTable();
            //    da.Fill(dt);

            //    dataGridView1.DataSource = new BindingSource(dt, null);
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "0";
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                label1.Text = Convert.ToString(double.Parse(label1.Text) + double.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString()) * double.Parse(dataGridView1.Rows[i].Cells[6].Value.ToString()));

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            // creating new WorkBook within Excel application  
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            // creating new Excelsheet in workbook  
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            // see the excel sheet behind the program  
            app.Visible = true;
            // get the reference of first sheet. By default its name is Sheet1.  
            // store its reference to worksheet  
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            // changing the name of active sheet  
            worksheet.Name = "Exported from gridview";
            // storing header part in Excel  
            for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
            }
            // storing Each row and column value to excel sheet  
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                }
            }
            // save the application  
            workbook.SaveAs("c:\\output.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            // Exit from the application  
            app.Quit();
        }
    }
}
