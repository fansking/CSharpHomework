using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hello
{
    class Program
    {
        static void Main(string[] args)
        {
            string str;
            double a, b;
            Console.WriteLine("请输入第一个数字：");
            str = Console.ReadLine();
            a = Double.Parse(str);
            Console.WriteLine("请输入第二个数字：");
            str = Console.ReadLine();
            b = Double.Parse(str);
            Console.WriteLine("这两个数字之积为：" + a * b);
        }
    }
}
