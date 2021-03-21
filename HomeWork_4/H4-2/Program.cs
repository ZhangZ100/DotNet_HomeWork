using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace H4_2
{
    class Program
    {
        static void Main(string[] args)
        {
            ClockExt clx = new ClockExt();
            clx.myclock.SetRingTime(3);//模拟设置5秒后响铃
            clx.myclock.StartClock();//模拟开启闹钟
        }
   
    }

    public delegate void ClockHandler(object sender, AlarmEventArgs args);
   
    public class AlarmEventArgs{}

  
    
    //闹钟类
    public class Clock {
        public event ClockHandler tick;
        public event ClockHandler ring;//定义两个事件

        int ringtime=0;


        //开启闹钟
        public void StartClock() {
            Console.WriteLine("闹钟打开了：");
            AlarmEventArgs args = new AlarmEventArgs(); 
            while (ringtime > 0)
            {
                tick(this, args);//触发滴答事件
                System.Threading.Thread.Sleep(1000);//当前主线程sleep
                ringtime--;
            }
            Ring();
            while (true)
            {
                tick(this, args);//触发滴答事件    
                System.Threading.Thread.Sleep(1000);//当前主线程sleep
            }
        }

        public void SetRingTime(int num)
        {
            if (num <= 0) { throw new ArgumentOutOfRangeException("不合理的时间"); }
            else { Console.WriteLine("已经设置闹钟的值..."); }
            ringtime = num;            
        }

        public void Ring() {
            AlarmEventArgs args = new AlarmEventArgs();
            ring(this, args);//触发响铃事件
        }






    }


    //闹钟扩展类，类比按钮对应的Form类
    public class ClockExt {
        public Clock myclock = new Clock();

        public ClockExt() {
            //把一个委托赋值给另一个 new ClockHandler(
            myclock.tick += ClockTick;
            myclock.ring += ClockRing;
        }

        void ClockTick(object sender, AlarmEventArgs args) {
                Console.WriteLine("tick......当前系统时间是：{0}", DateTime.Now);//当前系统时间        
        }

        void ClockRing(object sender, AlarmEventArgs args)
        {
            Console.WriteLine();
            Console.WriteLine("ddddd.......闹钟响了");
            Console.WriteLine();
        }
    }

}
