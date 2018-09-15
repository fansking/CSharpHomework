using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> myList = new List<int>();
            for (int i = 2; i <= 100; i++) {
                myList.Add(i);
            }
            for (int myNum=2;myNum<=100;myNum++) {
                for (int i = 2; i <= 100; i++) {
                    if (myNum > i && myNum % i == 0) {
                        myList.Remove(myNum);
                    }
                }
            }
            Console.Write("2到100以内的整数为：");
            foreach (int myNum in myList) {
                Console.Write(myNum+" ");
            }
        }
    }
}
