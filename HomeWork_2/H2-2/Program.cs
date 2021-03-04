using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2_2
{
    class Program
    {
        static int min=int.MaxValue;
        static int max=int.MinValue;
        static void Main(string[] args)
        {
            int[] ints = new int[] { 1, 16, 15, 3, 7, 8, 9, 5, 5, 6, 3, 2, 17 };
            FindMaxAndMin(ints, ref min,ref max);
            int sum = Sum(ints);
            Console.WriteLine("sum="+sum+" ,min="+min+" ,max="+max);

        }

        static void FindMaxAndMin(int[] ints, ref int min,ref int max) {
            for (int i = 0; i < ints.Length; i++) {
                if (ints[i] < min) { min = ints[i]; }
                if (ints[i] > max) { max = ints[i]; }
            }
        }

        static int Sum(int[] ints) {
            int sum = 0;
            for (int i = 0; i < ints.Length; i++)
            {
                sum += ints[i];           
            }
            return sum;
        }
    }
}
