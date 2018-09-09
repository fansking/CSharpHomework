using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        string str;
        double a, b, c;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            str = textBox1.Text;
            a = Double.Parse(str);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            str = textBox2.Text;
           b = Double.Parse(str);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            c = a * b;
            label3.Text = "两数之积为：" + c;
           
        }
    }
}
