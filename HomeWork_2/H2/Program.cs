using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2
{
    class Program
    {
        static int num;
        static string str;
        static int count = 0;
        static void Main(string[] args)
        {
            while (true) {
                try { 
                    string str = Console.ReadLine();
                    num = int.Parse(str);
                    break;
                }
                catch { Console.WriteLine("输入不合法，请重新输入："); }
            }

             str = num + "=";
            FindPrimeFactor();
            if (count == 0) { Console.WriteLine(num); }
            else { Console.WriteLine(str); }
            
        }

        static void FindPrimeFactor()
        {
            int max = num;
            for (int i = 2; i < Math.Sqrt(max); i++)
            {
                while (true) {
                    if (num % i == 0)
                    {
                        count++;//标记输入的数据不是素数
                        str += i;
                        num /= i;
                        if (num != 1)
                        {
                            str += "*";
                        }
                    }
                    else { break; }
                    
                }  
            }
            if (num != 1)
            {
                str +=num;
            }
        }


    }
    
}
