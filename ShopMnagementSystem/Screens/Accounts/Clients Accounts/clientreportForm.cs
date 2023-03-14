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

namespace ShopMnagementSystem.Screens.Accounts.Clients_Accounts
{
    public partial class clientreportForm : Form
    {
        DataClasses10DataContext d = new DataClasses10DataContext();
        public clientreportForm()
        {
            InitializeComponent();
        }

        private void clientreportForm_Load(object sender, EventArgs e)
        {
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            // or even better, use .DisableResizing. Most time consuming enum is DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders

            // set it to false if not needed
            dataGridView1.RowHeadersVisible = false;
            //using (SqlConnection con = new SqlConnection((DecHelper.ConnectionString)))
            //{

            //    string str = "Select * FROM [ShopManage].[dbo].[tblclients]";
            //    SqlCommand cmd = new SqlCommand(str, con);
            //    SqlDataAdapter da = new SqlDataAdapter(cmd);
            //    DataTable dt = new DataTable();
            //    da.Fill(dt);

            //    dataGridView1.DataSource = new BindingSource(dt, null);
            //}
            dataGridView1.DataSource = d.tblclients.ToList();
        }

        private void searchbutton_Click(object sender, EventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Valid Client Name  ....!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                using (SqlConnection con = new SqlConnection((DecHelper.ConnectionString)))
                {

                    string str = "Select * FROM [ShopManage].[dbo].[tblclients] WHERE [Date] >='" + dateTimePicker2.Text + "' And [Date] <= '" + dateTimePicker1.Text + "'AND  [Client Name] LIKE '%" + textBox1.Text + "%'";
                    SqlCommand cmd = new SqlCommand(str, con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.DataSource = new BindingSource(dt, null);
                }
            }
            }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection((DecHelper.ConnectionString)))
            {

                string str = "Select * FROM [ShopManage].[dbo].[tblclients] WHERE [Date] LIKE '%" + textBox1.Text + "%' OR [Client Name] LIKE '%" + textBox1.Text + "%' OR [Name Amount] LIKE '%" + textBox1.Text + "%' OR [Jumma Amount] LIKE '%" + textBox1.Text + "%' OR [Bqaya Amount] LIKE '%" + textBox1.Text + "%'";
                SqlCommand cmd = new SqlCommand(str, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = new BindingSource(dt, null);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            printPreviewDialog.Document = printDocument;
            printDocument.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("custom", 280, 9000);
            printPreviewDialog.ShowDialog();
        }

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
      
            var Search = d.tblclients.Where(x => x.Client_Name == textBox1.Text & x.Date >= Convert.ToDateTime(dateTimePicker2.Text) & x.Date <= Convert.ToDateTime(dateTimePicker1.Text)).ToList();
            //print call image
            {
                int width = 10;

                //  Bitmap bmp = Properties.Resources.call_ringing_icon;
                // Image newimage = bmp;
                // newimage.Width = width;
                // e.Graphics.DrawImage(newimage, 65, 90, newimage.Width, newimage.Height);


            }
            //for whatsaap icon
            {
                //  Bitmap bmp = Properties.Resources.WhatsApp_icon;
                //Image newimage = bmp;
                //// newimage.Width = width;
                //e.Graphics.DrawImage(newimage, 65, 120, newimage.Width, newimage.Height);
            }
            //Brush brush = new SolidBrush(Color.Black);
            //Pen blackPen = new Pen(Color.Black, 1);
            //e.Graphics.PageUnit = GraphicsUnit.Millimeter;
            // e.PageSettings.Margins = new Margins(10, 10, 10, 10);
            //  Rectangle rect = new Rectangle(10, 10, 50, 90);
            //e.Graphics.DrawRectangle(blackPen, rect);
            ///    dataGridView1.Height = dataGridView1.RowCount * dataGridView1.RowTemplate.Height * 3;
            // int height = dataGridView1.Height;
            // e.PageSettings.PaperSize.Height = 12;


            ///   dataGridView1.Height = height;
            //e.PageSettings.PaperSize.Height = 1000;
            //e.PageSettings.PaperSize.Width = 200;
            // e.Graphics.DrawString("Al Basit Stores (Store No 1)", new Font("monotype corsiva", 30, FontStyle.Bold), Brushes.Black, new Point(200, 50));
            e.Graphics.DrawString("WALI MART", new Font("Arial", 16, FontStyle.Bold), Brushes.Black, new Point(70, 10));
            e.Graphics.DrawString("Al Noor Garden Phase-4 Shop#4 ", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(35, 40));
            e.Graphics.DrawString("Near Cival Hospital,Bahawalpur ", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(35, 60));
            // e.Graphics.DrawString("For Complaint", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(75, 60));
            // e.Graphics.DrawString("|", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(131, 75));
            //e.Graphics.DrawString("V", new Font("Arial", 9, FontStyle.Bold), Brushes.Black, new Point(129, 80));
          //  double total = (Convert.ToDouble(balancetextBox.Text) + (Convert.ToDouble(clientbqaya.Text)));
            // e.Graphics.DrawString(" 0300-6827284 ", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(85, 90));
            e.Graphics.DrawString("CELL : 0300-5576238 || 0300-6668166 ", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(20, 75));
            e.Graphics.DrawString("" + DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString()+" " , new Font("Arial", 7, FontStyle.Regular),Brushes.Black, new Point(5, 100));
            e.Graphics.DrawString("  Account Name:" + textBox1.Text, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(-0, 115));
            e.Graphics.DrawString("Record From:" + dateTimePicker2.Text + " To " + dateTimePicker1.Text, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(-0, 130));
            e.Graphics.DrawString("------------------------------------------------------------------------------", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(-5, 140));
            e.Graphics.DrawString("Details", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(0, 153));
            e.Graphics.DrawString("Debit", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(105, 153));
            e.Graphics.DrawString("Credit ", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(150, 153));
            e.Graphics.DrawString("Amount", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(220, 153));


            e.Graphics.DrawString("----------------------------------------------------------------------------------------", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(-5, 160));
            ///  e.Graphics.DrawImage(bmp, new Point(-45, 200));
            int ypos = 170;
            for (int i = 0; i < Search.Count; i++)
            {
                //    numbersofitemsperpage++;
                //    if (numbersofitemsperpage<=500)
                //    {
                //        numbersofitemsprintsofar++;
                //        if (numbersofitemsprintsofar<=shopingcart.Count)
                //        {

                e.Graphics.DrawString(Search[i].Products_Details, new Font("Arial", 7, FontStyle.Regular), Brushes.Black, new Point(-2, ypos));
                e.Graphics.DrawString(Search[i].Jumma_Amount.ToString(), new Font("Arial", 9, FontStyle.Regular), Brushes.Black, new Point(105, ypos));
                e.Graphics.DrawString(Search[i].Name_Amount.ToString(), new Font("Arial", 9, FontStyle.Regular), Brushes.Black, new Point(150, ypos));
                e.Graphics.DrawString(Search[i].Bqaya_Amount.ToString(), new Font("Arial", 9, FontStyle.Regular), Brushes.Black, new Point(220, ypos));
                ypos += 30;
                //    }
                //    else
                //    {
                //        e.HasMorePages = false;

                //    }
                //}
                //else
                //{
                //    numbersofitemsperpage = 0;
                //    e.HasMorePages = true;
                //    return;
                //}
            }

            e.Graphics.DrawString("----------------------------------------------------------------------------------------", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(-5, ypos - 15));
            //e.Graphics.DrawString(" _________________________________", new Font("Arial", 18, FontStyle.Bold), Brushes.Black, new Point(0, ypos));
            // e.Graphics.DrawString(" _________________________________", new Font("Arial", 18, FontStyle.Bold), Brushes.Black, new Point(0, height+160));
            //     e.Graphics.DrawString(" Total Items=  " + counterproducts.Text + "       " + "Sub Total:" + " " + subtotaltextBox.Text, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(40, ypos + 5));
            //   e.Graphics.DrawString(" ___________________", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(100, ypos + 10));
            //e.Graphics.DrawString(" Grand Total:  " + subtotaltextBox.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(100, ypos + 35));
            //e.Graphics.DrawString(" Client Name: " + comboBox2.Text, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(5, ypos + 110));
            //e.Graphics.DrawString(" Printed By: " + loginuser.Text, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(5, ypos + 95));
            //e.Graphics.DrawString(" Paid:              " + paidamounttextBox.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(100, ypos + 55));
            //e.Graphics.DrawString(" Total Amount:" + total, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(160, ypos + 110));

            // e.Graphics.DrawString(" ___________________", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(100, ypos + 55));
            // //e.Graphics.DrawString(" Returns:         " + balancetextBox.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(100, ypos + 77));
            // ///e.Graphics.DrawString(" Note:   1=>  Open & Frozen Items no exchange no return.", new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(5, 540));
            //// e.Graphics.DrawString("     2=> Exchange within 7-days of purchase with orignal Packing", new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(5, 560));
            // //e.Graphics.DrawString("              and item should be in saleable condition.", new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(5, 580));
            // //e.Graphics.DrawString("     3=> No Exchange without receipt.", new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(5, 600));
            // e.Graphics.DrawString("     Thanks For Visit.", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(50, ypos + 137));
            // e.Graphics.DrawString("      ___________________", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(20, ypos + 115));
            // e.Graphics.DrawString("     | ", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(20, ypos + 135));
            // e.Graphics.DrawString("     | ", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(230, ypos + 135));
            // e.Graphics.DrawString("      ___________________", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(20, ypos + 140));
            e.Graphics.DrawString(" Software Devolper : Munir Ahmad    Contact :0301-4854706", new Font("Arial", 7, FontStyle.Regular), Brushes.Black, new Point(10, ypos + 10));
            //e.Graphics.DrawString(" Products:    ", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(25, 290));
            //e.Graphics.DrawString(" Total Amount:", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
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


