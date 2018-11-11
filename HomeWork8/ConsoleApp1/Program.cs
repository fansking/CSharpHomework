using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime time = new DateTime();
            time = DateTime.Now;
            string id = (time.Year).ToString() + time.Month + time.Day;
            Regex regex = new Regex("^[0-9]{11}$");

            Console.WriteLine(Regex.IsMatch("^[0-9]{11}$", "20181111902")) ;
            Console.WriteLine(regex.IsMatch("20181111902"));
        }
    }
}
