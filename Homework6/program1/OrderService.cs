using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace program2
{
    public class OrderService
    {
        private List<Order> orders=new List<Order>();
        public List<Order>  GetOrders() {
            return orders;
        }
        public void AddOrder(Order order) {
            orders.Add(order);
            Console.WriteLine("添加成功");
        }
        public bool DeleteOrderById(int id)
        {
            int nCount = 0;
            foreach (Order order in orders)
            {
                if (order.Id == id)
                {
                    nCount++;
                    orders.Remove(order);
                    Console.WriteLine("删除成功");
                    return true;
                }
            }
            if (nCount == 0)
            {
                Console.WriteLine("此订单不存在");
            }
            return false;
          
        }
        public bool updateOrderById(int id,Order NewOrder)
        {
            int nCount = 0;
            foreach (Order order in orders)
            {
                if (order.Id == id)
                {
                    nCount++;
                    orders.Remove(order);
                    orders.Add(NewOrder);
                    return true;
                }
            }
            if (nCount == 0)
            {
                orders.Add(NewOrder);
            }
            return false;
        }
        public void FindOrderById(int id)
        {
            var result = from item in orders
                         where item.Id == id
                         select item;
            if (result.ToList().Count == 0)
            {
                Console.WriteLine("查无此单");
                return;
            }
            foreach (Order order in result.ToList())
            {
                Console.WriteLine(order);
            }

        }
        public void FindOrderByStuff(string stuff)
        {
            var result = from item in orders
                         where (item.Getlist().Where(a => a.stuff == stuff)).ToList().Count!=0
                         select item;
            if (result.ToList().Count == 0)
            {
                Console.WriteLine("查无此单");
                return ;
            }
            foreach (Order order in result.ToList())
            {
                Console.WriteLine(order);
            }
        }
        public void FindByClientName(string name)
        {
            var result = from item in orders
                         where item.ClientName == name
                         select item;
            if (result.ToList().Count == 0)
            {
                Console.WriteLine("查无此单");
                return;
            }
            foreach (Order order in result.ToList())
            {
                Console.WriteLine(order);
            }
        }
        public void FindBigTrade()
        {
            var result = from item in orders
                         where item.TotalValue() > 10000
                         select item;
            if (result.ToList().Count == 0)
            {
                Console.WriteLine("查无此单");
                return;
            }
            foreach (Order order in result.ToList())
            {
                Console.WriteLine(order);
            }


        }
        public static void XmlSerialize(XmlSerializer ser, string fileName, object obj) {
            FileStream fs = new FileStream(fileName, FileMode.Create);
            try { ser.Serialize(fs, obj);}
            finally {fs.Close(); }
            
            
        }
        public static object XmlDeserialize(XmlSerializer ser, Stream stream) {
            return ser.Deserialize(stream); 
        }
        public void Export()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
            string xmlFileName = "order.xml";
            XmlSerialize(xmlSerializer, xmlFileName, orders);
            Console.WriteLine("已保存所有数据");
        }
        public void Import()
        {
            if (!File.Exists("order.xml")) { Console.WriteLine("导入失败，本地无数据");return; }
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
            FileStream fs = new FileStream("order.xml", FileMode.Open, FileAccess.Read);
            List<Order> temp;
            try
            {
                temp = (List<Order>)xmlSerializer.Deserialize(fs);
            }
            finally
            {
                fs.Close();
            }
            foreach (Order order in temp)
            {
                AddOrder(order);
            }
            Console.WriteLine("导入成功！");
        }
    }

}
