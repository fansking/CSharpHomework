using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace program2
{
    public class OrderService
    {

        public List<Order> orders=new List<Order>();
        public List<Order>  GetOrders() {
            return orders;
        }
        public void AddOrder(Order order) {
            using (var db = new OrderDB())
            {
                db.Order.Add(order);
                db.Order.Attach(order);
                db.Entry(order).State = EntityState.Added;
                db.SaveChanges();
            }
            Console.WriteLine("添加成功");
        }
        public void DeleteOrderById(string id)
        {
            using (var db = new OrderDB())
            {
                var order = db.Order.Include("Items").SingleOrDefault(o => o.ID == id);
                db.OrderItem.RemoveRange(order.items);
                db.Order.Remove(order);
                db.SaveChanges();
            }
    
        }
        public void updateOrder(Order order)
        {
            DeleteOrderById(order.ID);
            AddOrder(order);
            //using (var db = new OrderDB())
            //{
            //    Order OldOrder = FindOrderById(order.ID);
            //    foreach (OrderDetails item in order.items) {
            //        int count = 0;
            //        foreach (OrderDetails i in OldOrder.items) {
            //            if (item.ID == i.ID)
            //            {
            //                break;
            //            }
            //            else {
            //                count++;
            //            }
            //        }
            //        if (count == OldOrder.items.Count) {
            //            db.OrderItem.Add(item);
            //            db.OrderItem.Attach(item);
            //            db.Entry(item).State = EntityState.Added;
            //            db.SaveChanges();
            //        }
            //    }
            //    foreach (OrderDetails i in OldOrder.items)
            //    {
            //        int count = 0;
            //        foreach (OrderDetails item in order.items)
            //        {
            //            if (item.ID == i.ID)
            //            {
            //                break;
            //            }
            //            else
            //            {
            //                count++;
            //            }
            //        }
            //        if (count == order.items.Count)
            //        {
            //            db.OrderItem.Remove(i);
            //            db.Entry(i).State = EntityState.Deleted;
            //            db.SaveChanges();
            //        }
            //    }
            //    db.Order.Attach(order);
            //    order.items.ForEach(
            //        item => db.Entry(item).State = EntityState.Modified);
            //    db.SaveChanges();
            //}
         
        }
        public Order FindOrderById(string id)
        {
            using (var db = new OrderDB())
            {
                return db.Order.Include("Items").
                  SingleOrDefault(o => o.ID == id);
            }
            //var result = from item in orders
            //             where item.Myid == id
            //             select item;
            //if (result.ToList().Count == 0)
            //{
            //    Console.WriteLine("查无此单");
            //    return;
            //}
            //foreach (Order order in result.ToList())
            //{
            //    Console.WriteLine(order);
            //}

        }
        public List<Order> GetAllOrders()
        {
            using (var db = new OrderDB())
            {
                orders= db.Order.Include("items").ToList();
                return db.Order.Include("items").ToList();
            }
        }
        public List<Order> QueryByGoods(string stuff)
        {
            using (var db = new OrderDB())
            {
                var query = db.Order.Include("items")
                  .Where(o => o.items.Where(
                    item => item.stuff.Equals(stuff)).Count() > 0);
                return query.ToList();
            }
        }
        //public void FindOrderByStuff(string stuff)
        //{
        //    var result = from item in orders
        //                 where (item.Getlist().Where(a => a.stuff == stuff)).ToList().Count!=0
        //                 select item;
        //    if (result.ToList().Count == 0)
        //    {
        //        Console.WriteLine("查无此单");
        //        return ;
        //    }
        //    foreach (Order order in result.ToList())
        //    {
        //        Console.WriteLine(order);
        //    }
        //}
        public List<Order> FindByClientName(string name)
        {
            using (var db = new OrderDB())
            {
                return db.Order.Include("items")
                  .Where(o => o.ClientName.Equals(name)).ToList();
            }
            //var result = from item in orders
            //             where item.ClientName == name
            //             select item;
            //if (result.ToList().Count == 0)
            //{
            //    Console.WriteLine("查无此单");
            //    return;
            //}
            //foreach (Order order in result.ToList())
            //{
            //    Console.WriteLine(order);
            //}
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
