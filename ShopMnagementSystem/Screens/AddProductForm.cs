using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShopMnagementSystem.Models;
namespace ShopMnagementSystem.Screens
{

    public partial class AddProductForm : Form
    {
        DataClasses1DataContext d = new DataClasses1DataContext();
        public AddProductForm()
        {
            InitializeComponent();
        }

        private void Toppanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SaveRecordtoolStripButton_Click(object sender, EventArgs e)
        {

            if (IsFormValid())
            {
                if (recordexist())
                {


                    tblproduct t = new tblproduct();
                    t.Products = producthnametextBox.Text;
                    t.Price = priceltextBox.Text;
                    t.Quantity = quantitytextBox.Text;
                    t.Catagary = catagorytextBox.Text;
                    t.Barcode = barcodetextBox2.Text;
                    t.Buy_Price = buytextBox1.Text;
                  //  t.Expirydate = Convert.ToDateTime(dateTimePicker1.Value);
                    d.tblproducts.InsertOnSubmit(t);
                    d.SubmitChanges();
                    MessageBox.Show("Products Record Save SuccessFully...!!!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private bool recordexist()
        {
            var reg = producthnametextBox.Text;
            var barcode = barcodetextBox2.Text;
            var dc = d.tblproducts.Where(o => o.Products == reg).FirstOrDefault();
            var db = d.tblproducts.Where(o => o.Barcode == barcode).FirstOrDefault();


            if (dc != null || db != null)
            {
                MessageBox.Show("Product Record Already Exist!!!!!..... Please Update .  ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;


            }
            return true;
        }

        private bool IsFormValid()
        {
            if (producthnametextBox.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Product Name is Required..!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                producthnametextBox.Focus();
                return false;
            }
            if (quantitytextBox.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Quantity Of Product is Required..!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                quantitytextBox.Focus();
                return false;
            }
            if (catagorytextBox.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Catagary of Product is Required..!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                catagorytextBox.Focus();
                return false;
            }
            if (buytextBox1.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Buy Price of Product is Required..!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                buytextBox1.Focus();
                return false;
            }
            return true;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(DecHelper.ConnectionString);
            con.Open();
            //StudentB s = new StudentB();
            //MemoryStream ms = new MemoryStream();
            //i.Save(ms, ImageFormat.Jpeg);
            //byte[] arrrrr = ms.ToArray();

            string str = @" UPDATE [ShopManage].[dbo].[tblproducts]
SET  [Price] = '" + priceltextBox.Text + "', [Quantity] = '" + quantitytextBox.Text + "',  [Catagary] ='" + catagorytextBox.Text + "' ,  [Buy Price] ='" + buytextBox1.Text + "',[Barcode]='" + barcodetextBox2.Text + "'  WHERE ([Products] = '" + producthnametextBox.Text + "')";

            SqlCommand cmd = new SqlCommand(str, con);
            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Product Record Update SuccessFully...!!!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Stop);

        }

        private void closetoolStripButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void resettoolStripButton_Click(object sender, EventArgs e)
        {
            producthnametextBox.Text = " ";
            catagorytextBox.Text = " ";
            priceltextBox.Text = " ";
            quantitytextBox.Text = " ";
            barcodetextBox2.Text = " ";
            buytextBox1.Text = " ";
        }

        private void AddProductForm_Load(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            this.KeyPreview = true;
            SqlConnection conn = new SqlConnection(DecHelper.ConnectionString);
            conn.Open();
            string str = "  Select  DISTINCT [Catagary] From [ShopManage].[dbo].[tblproducts]";
            SqlCommand cmd = new SqlCommand(str, conn);
            SqlDataReader da = cmd.ExecuteReader();
            while (da.Read())
            {
                catagorytextBox.Items.Add(da[0].ToString()
                                   );
            }
        }

        private void AddProductForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.S)
            {
                //SaveRecordtoolStripButton.PerformClick();
            }
            if (e.Control == true && e.KeyCode == Keys.U)
            {
                //toolStripButton2.PerformClick();
            }
            if (e.KeyCode == Keys.Escape)
            {

                closetoolStripButton.PerformClick();
            }
            if (e.Control == true && e.KeyCode == Keys.R)
            {
                resettoolStripButton.PerformClick();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string barcode = barcodetextBox2.Text;
            Bitmap bitmap = new Bitmap(barcode.Length * 40, 150);

            using (Graphics gra = Graphics.FromImage(bitmap))
            {
                Font ofont = new System.Drawing.Font("IDAHC39M Code 39 Barcode", 20);

                PointF point = new PointF(2f, 2f);
                SolidBrush black = new SolidBrush(Color.Black);
                SolidBrush white = new SolidBrush(Color.White);
                gra.FillRectangle(white, 0, 0, bitmap.Width, bitmap.Height);
                gra.DrawString("" + barcode + "", ofont, black, point);

            }
            using (MemoryStream ms = new MemoryStream())
            {
                bitmap.Save(ms, ImageFormat.Png);
                pictureBox1.Image = bitmap;
                pictureBox1.Height = bitmap.Height;
                pictureBox1.Width = bitmap.Width;
            }
            {
                printPreviewDialog1.Document = printDocument1;
                printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("custom", 280, 720);
                printPreviewDialog1.ShowDialog();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            {
                int width = 10;

                Bitmap bmpp = Properties.Resources.call_ringing_icon;
                Image newimagee = bmpp;
                // newimage.Width = width;
                e.Graphics.DrawImage(newimagee, 65, 90, newimagee.Width, newimagee.Height);


            }
            //for whatsaap icon
            {
                Bitmap bmppp = Properties.Resources.WhatsApp_icon;
                Image newimagi = bmppp;
                // newimage.Width = width;
                e.Graphics.DrawImage(newimagi, 65, 120, newimagi.Width, newimagi.Height);
            }
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Image newimage = bmp;
            e.Graphics.DrawImage(newimage, 25, 200, newimage.Width, newimage.Height);
            {
                e.Graphics.DrawString("AMEER HAMZA SUPERMART", new Font("Arial", 14,FontStyle.Bold), Brushes.Black, new Point(4, 0));
                e.Graphics.DrawString("PULL DIWAN, Bahawalpur, ", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(45, 40));
                e.Graphics.DrawString("For Home Delivery", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(75, 60));
                e.Graphics.DrawString("|", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(131, 75));
                e.Graphics.DrawString("V", new Font("Arial", 9, FontStyle.Bold), Brushes.Black, new Point(129, 80));

                e.Graphics.DrawString(" 0303-5050508 ", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(85, 90));
                e.Graphics.DrawString(" 0300-2952759 ", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(80, 120));
                e.Graphics.DrawString(" Product Name:  " + producthnametextBox.Text, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(30, 140));

                e.Graphics.DrawString(" Quantity:  " + quantitytextBox.Text, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(30, 160));
                e.Graphics.DrawString(" Price:  " + priceltextBox.Text, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(30, 180));
                e.Graphics.DrawString("     Thanks For Visit.", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(20, 335));
                e.Graphics.DrawString("      ________________", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(5, 310));
                e.Graphics.DrawString("     | ", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(0, 330));
                e.Graphics.DrawString("     | ", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(185, 330));
                e.Graphics.DrawString("      ________________", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(5, 340));
                e.Graphics.DrawString(" Software Devolper : Munir Ahmad    Contact :0301-4854706", new Font("Arial", 7, FontStyle.Regular), Brushes.Black, new Point(10, 370));
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripSeparator5_Click(object sender, EventArgs e)
        {

        }

        private void toolStripSeparator2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripSeparator1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripSeparator3_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void filenametext_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void catagorytextBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CityNamecomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DistrictcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buytextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void priceltextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void barcodetextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void quantitytextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void producthnametextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void labelpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toppanellabel_Click(object sender, EventArgs e)
        {

        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
            string barcode = barcodetextBox2.Text;
            Bitmap bitmap = new Bitmap(barcode.Length * 40, 150);

            using (Graphics gra = Graphics.FromImage(bitmap))
            {
                Font ofont = new System.Drawing.Font("IDAHC39M Code 39 Barcode",20);

                PointF point = new PointF(2f, 2f);
                SolidBrush black = new SolidBrush(Color.Black);
                SolidBrush white = new SolidBrush(Color.White);
                gra.FillRectangle(white, 0, 0, bitmap.Width, bitmap.Height);
                gra.DrawString("" + barcode + "", ofont, black, point);

            }
            using (MemoryStream ms = new MemoryStream())
            {
                bitmap.Save(ms, ImageFormat.Png);
                pictureBox1.Image = bitmap;
                pictureBox1.Height = bitmap.Height;
                pictureBox1.Width = bitmap.Width;
            }
            {
                printPreviewDialog1.Document = printDocument2;
                printDocument2.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("custom", 200,200);
                printPreviewDialog1.ShowDialog();
            }
        }

        private void printDocument2_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //{
            //    int width = 10;

            //    Bitmap bmpp = Properties.Resources.call_ringing_icon;
            //    Image newimagee = bmpp;
            //    // newimage.Width = width;
            //    e.Graphics.DrawImage(newimagee, 65, 90, newimagee.Width, newimagee.Height);


            //}
            //for whatsaap icon
            //{
            //    Bitmap bmppp = Properties.Resources.WhatsApp_icon;
            //    Image newimagi = bmppp;
            //    // newimage.Width = width;
            //    e.Graphics.DrawImage(newimagi, 65, 120, newimagi.Width, newimagi.Height);
            //}
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Image newimage = bmp;
           e.Graphics.DrawImage(newimage,60,5, newimage.Width/2, newimage.Height/2);
            {
           //  e.Graphics.DrawString("Poduct Name", new Font("Arial", 3, FontStyle.Bold), Brushes.Black, new Point(70,60));
              ///  e.Graphics.DrawString("PULL DIWAN, Bahawalpur, ", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(45, 40));
             //   e.Graphics.DrawString("For Home Delivery", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(75, 60));
              //  e.Graphics.DrawString("|", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(131, 75));
               // e.Graphics.DrawString("V", new Font("Arial", 9, FontStyle.Bold), Brushes.Black, new Point(129, 80));

                //e.Graphics.DrawString(" 0303-5050508 ", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(85, 90));
                //e.Graphics.DrawString(" 0300-2952759 ", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(80, 120));
                //e.Graphics.DrawString(" Product Name:  " + producthnametextBox.Text, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(30, 140));

                //e.Graphics.DrawString(" Quantity:  " + quantitytextBox.Text, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(30, 160));
                //e.Graphics.DrawString(" Price:  " + priceltextBox.Text, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(30, 180));
                //e.Graphics.DrawString("     Thanks For Visit.", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(20, 335));
                //e.Graphics.DrawString("      ________________", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(5, 310));
                //e.Graphics.DrawString("     | ", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(0, 330));
                //e.Graphics.DrawString("     | ", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(185, 330));
                //e.Graphics.DrawString("      ________________", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(5, 340));
                //e.Graphics.DrawString(" Software Devolper : Munir Ahmad    Contact :0301-4854706", new Font("Arial", 7, FontStyle.Regular), Brushes.Black, new Point(10, 370));
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            //Add PrintPage event handler  
            pd.PrintPage += new PrintPageEventHandler(this.PrintTextFileHandler);
            //Call Print Method  
            pd.Print();
        }
        private void PrintTextFileHandler(object sender, PrintPageEventArgs eventArgs)
        {
            //Bitmap bmp = new Bitmap(pictureBox1.Image);
            //Image newimage = bmp;
            //int size = eventArgs.MarginBounds.Width;
            ////Create a graphics with the size of the printer page's width
            //Bitmap imageToPr = new Bitmap(size, size);
            //Graphics graphics = Graphics.FromImage(imageToPr);
            //graphics.DrawImage(bmp.(bmp.Size), new Rectangle(0, 0, size, size));
            ////Draw barcode image into the printer graphics
            //eventArgs.Graphics.DrawImage(imageToPr, new Rectangle((int)eventArgs.MarginBounds.Left, (int)eventArgs.MarginBounds.Top, imageToPr.Width, imageToPr.Height), 0, 0, size, size, GraphicsUnit.Pixel);
        }

        private void toolStripButton2_Click_2(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(DecHelper.ConnectionString);
            con.Open();
            //StudentB s = new StudentB();
            //MemoryStream ms = new MemoryStream();
            //i.Save(ms, ImageFormat.Jpeg);
            //byte[] arrrrr = ms.ToArray();

            string str = @" UPDATE [ShopManage].[dbo].[tblproducts]
SET  [Price] = '" + priceltextBox.Text + "', [Quantity] = '" + quantitytextBox.Text + "',  [Catagary] ='" + catagorytextBox.Text + "' ,  [Buy Price] ='" + buytextBox1.Text + "',[Barcode]='" + barcodetextBox2.Text + "'  WHERE ([Products] = '" + producthnametextBox.Text + "')";

            SqlCommand cmd = new SqlCommand(str, con);
            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Product Record Update SuccessFully...!!!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Stop);

        
    }
    }
}
