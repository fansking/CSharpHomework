using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program2
{
    class Order
    {
        private List<OrderDetails> list=new List<OrderDetails>();
        public int Id { get; set; }
        public string ClientName { get; set; }
        public Order(int id,string name)
        {
            this.Id = id;
            this.ClientName = name;
        }
        public void AddOrderDetails(OrderDetails orderDetails)
        {
            this.list.Add(orderDetails);
        }
        public override string ToString()
        {
            string str = "订单号：" + Id + "\n客户姓名：" + ClientName + "\n";
            StringBuilder sb = new StringBuilder(str);
            int nCount = 1;
            foreach (OrderDetails orderDetails in list)
            {
                sb = sb.Insert(sb.Length, "第" + nCount + "个条目为:\n");
                nCount++;
                sb = sb.Insert(sb.Length,orderDetails);
            }
            str = sb.ToString();
            return str;

        }


    }
}
