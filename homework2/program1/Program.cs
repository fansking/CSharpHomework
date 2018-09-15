using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("请输入一个整数：");
            string str = Console.ReadLine();
            int myNum;

            if (Int32.TryParse(str, out myNum))
            {
                int nCount=0;
                int now = myNum;
                int[] divisor=new int[20];
                for (int i = 2; ; ++i)
                {
                    if (now == 1) { break; }
                    if (now % i == 0)
                    {
                        now = now / i;
                        if (nCount == 0) {
                           
                            divisor[nCount] = i;
                           ++nCount;
                            i = 1;
                            continue;
                        }
                        if (divisor[nCount-1] != i) {
                            divisor[nCount] = i;
                            ++nCount;
                            i = i - 1;
                            continue;
                        }
                                                
                    }
                }
                Console.Write(myNum+"的素数因子为：");
                for (int i = 0; i < nCount; i++) {
                    Console.Write(divisor[i]+" ");
                }
            }
            else {
                Console.WriteLine("输入的格式错误，请输入一个整数");
            }   
        }
    }
}
