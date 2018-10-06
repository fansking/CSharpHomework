using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace program1
{
    public class ClickEventArgs : EventArgs
    {
       public string mytime { get; set; }
       
      
    }
    public delegate void ClickHandler(object sender, ClickEventArgs args);
    public class MyClock
    {
        public event ClickHandler OnTime;
        public void Time(string NowTime) {
            ClickEventArgs args = new ClickEventArgs();
           args.mytime=NowTime;
            OnTime(this, args);
        }

    }
    
    class Program
    {
        static void Main(string[] args)
        {
            MyClock clock = new MyClock();
            clock.OnTime += new ClickHandler(clock_2);
            clock.OnTime += new ClickHandler(clock_1);
            while (true) {
                clock.Time(DateTime.Now.ToString("T"));
                Thread.Sleep(5000);
            }
            

            
        }
        static void clock_1(object sender, ClickEventArgs args)
        {
            Console.WriteLine("时间到了,现在的时间是"+args.mytime);
        }

        static void clock_2(object sender, ClickEventArgs args)
        {
            Console.WriteLine("叮叮叮");
            Console.Beep(1000,1000);
        }
    }
}
