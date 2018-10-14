using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace program2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(graphics==null) graphics = this.CreateGraphics(); 
            drawCayleyTree(10, 200, 310, 100, -Math.PI / 2);
        }
        private Graphics graphics;
        double th1 = 30 * Math.PI / 180;
        double th2 = 20 * Math.PI / 180;
        double k = 1;
        double per1 = 0.6;
        double per2 = 0.7;
        Pen pen = new Pen(Color.FromArgb(0,0,0));
        void drawCayleyTree(int n, double x0, double y0, double length, double th) {
            if (n == 0) return;
            double x1 = x0 + length * Math.Cos(th);
            double y1 = y0 + length * Math.Sin(th);
            double x2 = x0 + length *k* Math.Cos(th);
            double y2 = y0 + length *k* Math.Sin(th);
            drawLine(x0, y0, x1, y1,pen);
            drawCayleyTree(n - 1, x1, y1, per1 * length, th + th1);
            drawCayleyTree(n - 1, x2, y2, per2 * length, th - th2);
        }
        void drawLine(double x0, double y0, double x1, double y1,Pen pen) {
            graphics.DrawLine(pen, (int)x0, (int)y0, (int)x1, (int)y1);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            double t1;
            double.TryParse(textBox1.Text, out t1);
            th1 = t1 * Math.PI / 180;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            double t2;
            double.TryParse(textBox2.Text, out t2);
            th2 = t2 * Math.PI / 180;
        }

        private void k_Scroll(object sender, ScrollEventArgs e)
        {
             k =((double)(Scoll.Maximum- Scoll.Value)/1000)+0.00001;
        }

        private void vScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            per1 =((double)(vScrollBar1.Maximum- vScrollBar1.Value)  / 1000 )+ 0.00001;
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            per2 = ((double)(vScrollBar2.Maximum - vScrollBar2.Value) / 1000 )+ 0.00001;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random rd = new Random();
            pen.Color = Color.FromArgb(rd.Next(0, 255), rd.Next(0, 255), rd.Next(0, 255));
        }
    }
}
