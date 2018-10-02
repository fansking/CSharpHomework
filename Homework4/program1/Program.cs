using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1
{
    public class ClickEventArgs : EventArgs
    {
        public int Myhour { get; set; }
        public int MyMinute { get; set; }
        public string time
        {
            get {
                return Myhour + ":" + MyMinute;
            }
          
        }
      
    }
    public delegate void ClickHandler(object sender, ClickEventArgs args);
    public class MyClock
    {
        public event ClickHandler OnTime;
        public void Time(int Myhour, int MyMinute) {
            ClickEventArgs args = new ClickEventArgs();
            args.Myhour = Myhour;
            args.MyMinute = MyMinute;
            OnTime(this, args);
        }

    }
    
    class Program
    {
        static void Main(string[] args)
        {
            MyClock clock = new MyClock();
            clock.OnTime += new ClickHandler(clock_1);
            clock.OnTime += new ClickHandler(clock_2);
            clock.Time(9, 50);
        }
        static void clock_1(object sender, ClickEventArgs args)
        {
            Console.WriteLine("时间到了,现在的时间是"+args.time);
        }

        static void clock_2(object sender, ClickEventArgs args)
        {
            Console.WriteLine("叮叮叮");
        }
    }
}
