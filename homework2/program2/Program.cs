using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program2
{
    class Program
    {
        static void insertSort(int[] a,int n) {
            for (int i = 1; i < n; i++) {
                int temp = a[i];
                int j = i;
                while (j > 0 && temp < a[j - 1]) {
                    a[j] = a[j - 1];
                    j--;
                }
                a[j] = temp;
            }
        }
        static void Main(string[] args)
        {
            int[] myList = { 3, 456, 68, 231, 678, 0, 1, 6, 8, 44 };
            insertSort(myList, 10);
            double sum = 0;
            foreach (int num in myList) {
                sum += num;
            }
            Console.WriteLine("该整数数组最小值为："+myList[0]);
            Console.WriteLine("该整数数组最大值为："+myList[9]);
            Console.WriteLine("整数数组所有数之和为："+sum);
            Console.WriteLine("该整数数组平均数为"+(sum/10));
        }
    }
}
