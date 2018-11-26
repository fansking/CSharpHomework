using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;
using program2;

namespace WinFrom1
{
    public partial class Form1 : Form
    {
        public static OrderService Service = new OrderService();
        public string KeyWord { get; set; }
        public Form1()
        {
            
            InitializeComponent();
            
            orderServiceBindingSource.DataSource = Service.GetAllOrders();
            OrderInput.DataBindings.Add("Text", this, "KeyWord");
            bindingNavigator1.BindingSource = orderServiceBindingSource;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                orderServiceBindingSource.DataSource = Service.FindOrderById(KeyWord);
            }
            catch (Exception)
            {
                orderServiceBindingSource.DataSource = new Order(0, "无此订单",null);
            }
            
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new OrderInfoForm(Service.orders.Where(s => s.Myid == int.Parse(bindingNavigator1.Text)).ToList()[0]).ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void bindingNavigator1_RefreshItems(object sender, EventArgs e)
        {

        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (orderServiceBindingSource.Current != null)
            {
                Order order = (Order)orderServiceBindingSource.Current;
                Service.DeleteOrderById(order.ID);
                orderServiceBindingSource.ResetBindings(true);
            }
            else
            {
                MessageBox.Show("No Order is selected!");
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
              
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            orderServiceBindingSource.DataSource = Service.GetAllOrders();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (orderServiceBindingSource.Current != null)
            {
                new OrderInfoForm((Order)orderServiceBindingSource.Current).Show();
            }
            else
            {
                MessageBox.Show("No Order is selected!");
            }
           
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //Order order3 = new Order(111, null);
            //try {
                //Service.AddOrder(null);
            new OrderInfoForm(null).ShowDialog();
            //}
            //catch { MessageBox.Show(" OrderID is used!"); }
           // Service.AddOrder(order3);
            orderServiceBindingSource.ResetBindings(true);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Service.Export();
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(@"order.xml");

                XPathNavigator nav = doc.CreateNavigator();
                nav.MoveToRoot();

                XslCompiledTransform xt = new XslCompiledTransform();
                xt.Load(@"../../order.xslt");

                FileStream outFileStream = File.OpenWrite(@"../../order.html");
                XmlTextWriter writer =
                    new XmlTextWriter(outFileStream, System.Text.Encoding.UTF8);
                xt.Transform(nav, null, writer);
                writer.Close();

            }
            catch (XmlException a)
            {
                Console.WriteLine("Xml Exception:" + a.ToString());
            }
            catch (XsltException a)
            {
                Console.WriteLine("XSLT Exception:" + a.ToString());
            }
            finally {
               
                System.Diagnostics.Process.Start("order.html");
            }
        }

        private void bindingNavigatorPositionItem_Click(object sender, EventArgs e)
        {

        }
    }
}
