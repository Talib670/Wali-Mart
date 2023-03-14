using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace ShopMnagementSystem.Screens
{
    public partial class barcodegenratorForm : Form
    {
        public barcodegenratorForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string barcode = textBox1.Text;
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
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Image newimage = bmp;
            e.Graphics.DrawImage(newimage, 25, 25, newimage.Width, newimage.Height);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //printDialog1.Document = printDocument1;
            //printDialog1.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
           printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("custom", 280, 200);
           printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage_1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

           Bitmap bmp = new Bitmap(pictureBox1.Image);
            Image newimage = bmp;
            e.Graphics.DrawImage(newimage, 25, 25, newimage.Width, newimage.Height);

        }
    }
}
