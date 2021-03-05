using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] ints = new int[101][];
            Init(ints);
            FindPrimeFactors(ints);
            Print(ints);
        }

        //初始化
        static void Init(int[][] ints)
        {
            for (int i = 2; i < ints.Length; i++)
            {
                ints[i]= new int[]{ i, 0 };
            }
        }
        static void FindPrimeFactors(int[][] ints)
        {
            //用于筛的2,3,4的倍数
            for (int i = 2; i <= Math.Sqrt(ints[ints.Length-1][0]); i++)
            {
                //b遍历一遍
                for (int j = 2; j < ints.Length; j++)
                {
                    if (j % i== 0&&j>i)//为了去除的时候把2,3,5,7,11等1倍的数留下来
                    {
                        ints[j][1] = 1;//修改标志位 }
                    }

                }
            }
        }


        static void Print(int[][] ints)
        {
            for (int i = 2; i < ints.Length; i++)
            {
                if (ints[i][1] == 0) { Console.WriteLine(ints[i][0]); }   
            }
        }

    }
}

