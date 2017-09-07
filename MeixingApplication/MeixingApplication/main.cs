using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThoughtWorks.QRCode.Codec;

namespace MeixingApplication
{
    public partial class main : Form
    {
        static protected double InchToMm= 0.0393701 * 100;
        protected int PRINT_WIDTH = Convert.ToInt32(75 * InchToMm);
        protected int PRINT_HEIGHT = Convert.ToInt32(50 * InchToMm);
        public main()
        {
            InitializeComponent();
            
            int width = PRINT_WIDTH;
            int height = PRINT_HEIGHT;
            //this.docToPrint.DefaultPageSettings.Margins = new Margins(margin, margin, margin, margin, margin);
            this.docToPrint.DefaultPageSettings.PaperSize = new PaperSize("Custum", width, height);
            
            this.txtName.Text = "电烤箱";
            this.txtModel.Text = "ST--120B";
            this.txtCode.Text = "K-045";
            this.txtAddress.Text = "上海一车间在用";
            this.txtPeriod.Text = "2015年12月31日到2016年12月31日";
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnPreview_Click(object sender, EventArgs e)
        {

            this.printPreviewControl.Document = this.docToPrint;
           
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

            PrintDocument pdoc = new PrintDocument();
            pdoc.PrintPage += new PrintPageEventHandler(docToPrint_PrintPage);
            pdoc.Print();

            //this.docToPrint += new PrintPageEventHandler(docToPrint_PrintPage);
        }

        private void docToPrint_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            Font fontLarge = new Font("仿宋", 18, FontStyle.Bold);
            Font fontMiddle = new Font("仿宋", 12, FontStyle.Bold);
            Font fontSmall = new Font("仿宋", 10, FontStyle.Regular);
            Brush bru = Brushes.Black;
            Graphics g = e.Graphics;   //先建立画布 
            String companyName = "上海美星电子有限公司";
            
            int x = 10;
            int y = 5;
           
            g.DrawString(companyName, fontLarge, bru, x, y);

            /*--------------------------------------------------------*/
            x = 150;
            y += 30;
            g.DrawString(this.lblName.Text,fontMiddle,bru, x, y);
         
            x += 40;
            g.DrawString(this.txtName.Text, fontMiddle, bru, x, y);

            /*--------------------------------------------------------*/
            x = 150;
            y += 30;
            g.DrawString(this.lblModel.Text, fontMiddle, bru, x, y);
            x += 40;
            g.DrawString(this.txtModel.Text, fontMiddle, bru, x, y);

            /*--------------------------------------------------------*/
            x = 150;
            y += 30;
            g.DrawString(this.lblCode.Text, fontMiddle, bru, x, y);
            x += 40;
            g.DrawString(this.txtCode.Text, fontMiddle, bru, x, y);

            /*--------------------------------------------------------*/
            x = 150;
            y += 30;
            g.DrawString(this.lblAddress.Text, fontMiddle, bru, x, y);
            //x += 60;
            y += 25;
            g.DrawString(this.txtAddress.Text, fontMiddle, bru, x, y);

            /*--------------------------------------------------------*/
            x = 10;
            y += 30;
            g.DrawString(this.lblPeriod.Text, fontSmall, bru, x, y);
            x += 55;
            g.DrawString(this.txtPeriod.Text, fontSmall, bru, x, y);

            Bitmap bt;

            string enCodeString = this.txtPeriod.Text;

            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();

            bt = qrCodeEncoder.Encode(enCodeString, Encoding.UTF8);

          
            Pen pen = new Pen(bru,1);
            Rectangle test = new Rectangle(0, 0, PRINT_WIDTH, PRINT_HEIGHT);
            g.DrawRectangle(pen, test);
            g.DrawImage(bt,15,35,135,135);
          
        }

     

       
    }
}
