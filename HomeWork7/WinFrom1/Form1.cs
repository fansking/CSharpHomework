using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using program2;

namespace WinFrom1
{
    public partial class Form1 : Form
    {
        public OrderService Service = new OrderService();
        public int KeyWord { get; set; }
        public Form1()
        {
            OrderDetails Orderdetail = new OrderDetails("下品灵石", 1, 1);
            OrderDetails Orderdetai2 = new OrderDetails("极品灵石", 10, 10000);
            Order order = new Order(1, "王林");
            order.AddOrderDetails(Orderdetail);
            Order order2 = new Order(2, "苏铭");
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
                orderServiceBindingSource.DataSource = Service.orders.Where(s => s.Id == KeyWord);
            }
            catch (Exception)
            {
                orderServiceBindingSource.DataSource = new Order(-1, "无此订单");
            }
            
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new OrderInfoForm(Service.orders.Where(s => s.Id == int.Parse(bindingNavigator1.Text)).ToList()[0]).ShowDialog();
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
            new OrderInfoForm(Service.orders.Where(s => s.Id == int.Parse(bindingNavigator1.Text)).ToList()[0]).Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Order order3 = new Order(0, null);
            Service.AddOrder(order3);
            new OrderInfoForm(Service.orders[Service.orders.Count-1]).ShowDialog();
            orderServiceBindingSource.ResetBindings(true);
        }
    }
}
