using Microsoft.VisualStudio.TestTools.UnitTesting;
using program2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program2.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        OrderService orderService = new OrderService();
        OrderDetails Orderdetail = new OrderDetails("gun",1,1);
        Order order = new Order(1,"lv");
        Order order2 = new Order(2, "yin");
        [TestMethod()]
        public void AddOrderTest()
        {
            orderService.AddOrder(order);
            Assert.IsNotNull(orderService.GetOrders());
        }

        [TestMethod()]
        public void DeleteOrderByIdTest()
        {
            orderService.AddOrder(order);
            orderService.DeleteOrderById(1);
            Assert.IsTrue((orderService.GetOrders()).Count==0);
        }

        [TestMethod()]
        public void updateOrderByIdTest()
        {
            orderService.AddOrder(order);
            orderService.updateOrderById(1, order2);
            Assert.IsTrue(
                (orderService.GetOrders())[0].Id == 2
                );
        }

        [TestMethod()]
        public void FindOrderByIdTest()
        {
            orderService.AddOrder(order);
            orderService.AddOrder(order2);
            orderService.FindOrderById(1);
        }

        [TestMethod()]
        public void FindOrderByStuffTest()
        {
            orderService.AddOrder(order);
            orderService.AddOrder(order2);
            orderService.FindOrderByStuff("gun");

        }

        [TestMethod()]
        public void FindByClientNameTest()
        {
            orderService.AddOrder(order);
            orderService.AddOrder(order2);
            orderService.FindByClientName("lv");
        }

        [TestMethod()]
        public void FindBigTradeTest()
        {
            orderService.AddOrder(order);
            orderService.AddOrder(order2);
            orderService.FindBigTrade();           
        }



        [TestMethod()]
        public void ExportTest()
        {
            orderService.AddOrder(order);
            orderService.AddOrder(order2);
            orderService.Export();
        }

        [TestMethod()]
        public void ImportTest()
        {
            orderService.AddOrder(order);
            orderService.AddOrder(order2);
            orderService.Import();
        }
    }
}