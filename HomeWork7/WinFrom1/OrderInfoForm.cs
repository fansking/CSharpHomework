using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using program2;

namespace WinFrom1
{
    public partial class OrderInfoForm : Form
    {
        public OrderInfoForm(Order order)
        {
            
            InitializeComponent();
            orderBindingSource.DataSource = order;
            orderDetailsBindingSource.DataSource = order.Getlist();
            label2.Text =order.Id.ToString();
            label4.Text = order.ClientName;
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
    }
}
