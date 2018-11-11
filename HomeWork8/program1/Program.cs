using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program2
{
        class Program
        {
        public static int StringToIntId()
        {
            int id;
            string str;
            Console.WriteLine("请输入订单号:");
            str = Console.ReadLine();
            if (!Int32.TryParse(str, out id))
            {
                Console.WriteLine("输入格式有误！");
                for (; !Int32.TryParse(str, out id);)
                {
                    Console.WriteLine("请重新输入订单号:");
                    str = Console.ReadLine();

                }
            }
            return id;
        }
        public static Order CreateOrder()
        {
            int id, price, num;
            id = StringToIntId();
            string str;
            Console.WriteLine("请输入买家姓名:");
            string name = Console.ReadLine();
            Order order = new Order(id, name);

            while (true)
            {
                Console.WriteLine("请输入商品名称:");
                string stuff = Console.ReadLine();
                Console.WriteLine("请输入商品单价:");
                str = Console.ReadLine();
                if (!Int32.TryParse(str, out price))
                {
                    Console.WriteLine("输入格式有误！");
                    for (;! Int32.TryParse(str, out price);)
                    {
                        Console.WriteLine("请重新输入商品单价:");
                        str = Console.ReadLine();

                    }
                }
                Console.WriteLine("请输入商品数量:");
                str = Console.ReadLine();
                Int32.TryParse(str, out num);
                if (!Int32.TryParse(str, out num))
                {
                    Console.WriteLine("输入格式有误！");
                    for (; !Int32.TryParse(str, out num);)
                    {
                        Console.WriteLine("请重新输入商品数量:");
                        str = Console.ReadLine();

                    }
                }
                OrderDetails orderDetails = new OrderDetails(stuff, num, price);
                order.AddOrderDetails(orderDetails);
                Console.WriteLine("是否输入下一订单条目？yes/no");
                string input = Console.ReadLine();
                if (input.Equals("no"))
                {
                    break;
                }
                else if(! input.Equals("yes")) {
                    Console.WriteLine("输入格式错误，将继续输入下一条目");
                }
            }
            return order;
        }
        static void Main(string[] args)
            {
            OrderService orderService = new OrderService();
            Console.WriteLine("欢迎来到订单管理系统\n");
            while (true)
            {
                Console.WriteLine("您有五个选择：\n");
                Console.WriteLine("1、添加订单\n" +
                    "2、通过订单号删除订单\n" +
                    "3、通过订单号查询订单\n" +
                    "4、通过订单号更改订单\n" +
                    "5、通过商品名查询订单\n"+
                    "6、通过客户名查询订单\n"+
                    "7、查询总金额超过一万的订单\n"+
                    "8、保存所有数据到本地\n"+
                    "9、导入所有数据到系统\n"+
                    "10、退出系统\n" +
                    "请输入您的选择：");
                string str = Console.ReadLine();
                int choice;
                if (!Int32.TryParse(str, out choice)) {
                    Console.WriteLine("输入格式错误请重新输入");
                }
                if (choice == 1)
                {
                    Order order = CreateOrder();
                    orderService.AddOrder(order);

                }
                else if (choice == 2)
                {
                    int id = StringToIntId();
                    orderService.DeleteOrderById(id);
                }
                else if (choice == 4)
                {
                    int id = StringToIntId();
                    Order order = CreateOrder();
                    orderService.updateOrderById(id, order);
                }
                else if (choice == 3)
                {
                    int id = StringToIntId();
                    orderService.FindOrderById(id);
                }
                else if (choice == 5)
                {
                    Console.WriteLine("请输入商品名称：");
                    str = Console.ReadLine();
                    orderService.FindOrderByStuff(str);
                }
                else if (choice == 6)
                {
                    Console.WriteLine("请输入客户名：");
                    str = Console.ReadLine();
                    orderService.FindByClientName(str);

                }
                else if (choice == 7)
                {
                    orderService.FindBigTrade();
                }
                else if (choice == 8)
                {
                    orderService.Export();
                }
                else if (choice == 9) {
                    orderService.Import();
                }
                else
                {
                    break;
                }

            }
        
            }

           
        }
    
}
