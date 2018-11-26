using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program2
{
    [Serializable]
    
    public class Order
    {
        public List<OrderDetails> items { get; set; }
        
        public int Myid { get; set; }
        [Key]
        public string ID { get; set; }
        public string ClientName { get; set; }
        public string ClientNumber { get; set; }
        public Order() { items = new List<OrderDetails>(); }
        public int TotalValue() {
            int sum = 0;
            foreach (OrderDetails details in items)
            {
                sum += details.num * details.price;
            }
            return sum;
        }
        public Order(int id_,string name)
        {
            this.Myid = id_;
            string str;
            if (Myid < 10)
            {
                str = "00" + Myid;
            }
            else if (Myid < 100)
            {
                str = "0" + Myid;
            }
            else {
                str = Myid.ToString();
            }
            this.ClientName = name;
            DateTime time = new DateTime();
            time = DateTime.Now;
            this.ID = (time.Year).ToString() + time.Month + time.Day + str;
            items = new List<OrderDetails>();
        }
        public Order(int id_, string name, string phone) {
            items = new List<OrderDetails>();
            ClientNumber = phone;
            this.Myid = id_;
            string str;
            if (Myid < 10)
            {
                str = "00" + Myid;
            }
            else if (Myid < 100)
            {
                str = "0" + Myid;
            }
            else
            {
                str = Myid.ToString();
            }
            this.ClientName = name;
            DateTime time = new DateTime();
            time = DateTime.Now;
            this.ID = (time.Year).ToString() + time.Month + time.Day + str;
        }
        public void AddOrderDetails(OrderDetails orderDetails)
        {
            this.items.Add(orderDetails);
        }
        public List<OrderDetails> Getlist()
        {
            return items;
        }
        public override string ToString()
        {
            string str = "订单号：" + Myid + "\n客户姓名：" + ClientName + "\n";
            StringBuilder sb = new StringBuilder(str);
            int nCount = 1;
            foreach (OrderDetails orderDetails in items)
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
