using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program2
{
    class OrderService
    {
        private List<Order> orders=new List<Order>();
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
            int nCount = 0;
            foreach (Order order in orders)
            {
                if (order.Id == id)
                {
                    nCount++;
                    Console.WriteLine(order);
                }
            }
            if (nCount == 0)
            {
                Console.WriteLine("此订单不存在");
            }
            
        }
    }
}
