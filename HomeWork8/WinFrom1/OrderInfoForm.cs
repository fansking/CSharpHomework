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
        public Order nowOrder;
        public OrderInfoForm(Order order)
        {
            
            InitializeComponent();
            nowOrder = order;
            orderBindingSource.DataSource = nowOrder;

            orderDetailsBindingSource.DataSource = nowOrder.Getlist();
            label2.Text =nowOrder.Myid.ToString();
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
            }
            if (PhoneInput.Text != "" && regex_phone.IsMatch( PhoneInput.Text))
            {
                nowOrder.ClientName = PhoneInput.Text;
            }
            else if (PhoneInput.Text != "" && !regex_phone.IsMatch(PhoneInput.Text)) {
                message.Text += "ClientNum输入不合乎规范\n";
            }
            orderBindingSource.ResetBindings(true);
        }
    }
}
