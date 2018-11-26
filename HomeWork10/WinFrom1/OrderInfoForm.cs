using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using program2;

namespace WinFrom1
{
    public partial class OrderInfoForm : Form
    {
        OrderService orderService = new OrderService();
        bool addMode = false;
        public Order nowOrder { get; set; }
        public OrderInfoForm(Order order)
        {
            
            InitializeComponent();
            if (order == null)
            {
                addMode = true;
                nowOrder = new Order();
            }
            else
            {
                nowOrder = order;
            }
            //nowOrder = order;
            orderBindingSource.DataSource = nowOrder;

            orderDetailsBindingSource.DataSource = nowOrder.items;
            label2.Text =nowOrder.ID;
            label4.Text = nowOrder.ClientName;
            bindingNavigator1.BindingSource = orderDetailsBindingSource;
        }

        private void OrderInfoForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void OrderData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool flag = true;
            Regex regex = new Regex("^[0-9]{11}$");
            Regex regex_phone = new Regex("^//+86//s[0-9]{11}$");
            message.Text = "";
            if (Nameinput.Text != "") {
                nowOrder.ClientName = Nameinput.Text;
            }
            if (IDinput.Text != "" && regex.IsMatch(IDinput.Text))
            {
                nowOrder.ID = IDinput.Text;
            }
            else if(IDinput.Text != "" && !regex.IsMatch(IDinput.Text))
            {
                message.Text = "ID输入不合乎规范\n";
                flag = false;
            }
            if (PhoneInput.Text != "") {
                nowOrder.ClientNumber = PhoneInput.Text;
            }
            if (addMode&&flag)
            {
                orderService.AddOrder(nowOrder);
                Close();
            }
            else if(!addMode && flag)
            {
                orderService.updateOrder(nowOrder);
                Close();
            }
            //Form1.Service.updateOrder(nowOrder);
            orderBindingSource.ResetBindings(true);
            
        }
    }
}
