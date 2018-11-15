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
        public OrderService Service = new OrderService();
        public string KeyWord { get; set; }
        public Form1()
        {
            OrderDetails Orderdetail = new OrderDetails("下品灵石", 1, 1);
            OrderDetails Orderdetai2 = new OrderDetails("极品灵石", 10, 10000);
            Order order = new Order(3, "王林","+86 13333333333");
            order.AddOrderDetails(Orderdetail);
            Order order2 = new Order(2, "苏铭","+86 12345678901");
            order2.AddOrderDetails(Orderdetai2);
            InitializeComponent();
            Service.AddOrder(order);
            Service.AddOrder(order2);
            orderServiceBindingSource.DataSource = Service.orders;
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
                orderServiceBindingSource.DataSource = Service.orders.Where(s => s.ID == KeyWord);
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
           
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
              
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            orderServiceBindingSource.DataSource = Service.orders;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            new OrderInfoForm(Service.orders.Where(s => s.ID ==bindingNavigator1.Text).ToList()[0]).Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Order order3 = new Order(0, null);
            Service.AddOrder(order3);
            new OrderInfoForm(Service.orders[Service.orders.Count-1]).ShowDialog();
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
