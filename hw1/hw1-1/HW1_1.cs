using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1_1
{
    class HW1_1
    {
        static double n1;
        static double n2;
        static void Main(string[] args)
        {
            Console.WriteLine("输入第一个操作数：");
            n1 = InputNum();
            Console.WriteLine("输入第二个操作数：");
            n2 = InputNum();

            while (true)
            {
                Console.WriteLine("输入两个数的运算符");
                string symbol = Console.ReadLine();
                if (symbol == "+") { Console.WriteLine("结果为： " + (n1 + n2)); break; }
                if (symbol == "-") { Console.WriteLine("结果为： " + (n1 - n2)); break; }
                if (symbol == "*") { Console.WriteLine("结果为： " + (n1 * n2)); break; }
                if (symbol == "/" && n2 != 0) { Console.WriteLine("结果为： " + (n1 / n2)); break; }
                if (symbol == "%") { Console.WriteLine("结果为： " + (n1 % n2)); break; }
                else { Console.WriteLine("运算符输入不合法，请重新输入"); }
            }
            Console.Read();//控制台暂留
        }

        static double InputNum()
        {
            while (true)
            {
                string num = Console.ReadLine();
                if (IsNumber(num))
                {
                    double nu = double.Parse(num);
                    return nu;
                }
                else Console.WriteLine("输入不合法,请重新输入：");
            }
        }
        //判断该字符串是否是数字
        static bool IsNumber(string str)
        {
            try
            {
                double temp = double.Parse(str);
                return true;
            }
            catch { return false; }
        }
    }
}
