using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2_4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] ints = new int[,] { { 1,2,3,4 },{ 5,1,2,3},{ 9,5,2,2 } };
            int[,] ints2 = new int[,]{ { 1,2,3,4 },{ 5,1,2,3},{ 9,5,1,2 } };
            Console.WriteLine(IsTheMatrix(ints));
            Console.WriteLine(ints2);//是该矩阵
        }


        static bool IsTheMatrix(int[,] ints) {
            //右上角
            for (int i = 0; i < ints.GetLength(1) - 1; i++) {
                int j = 0;
                int temp = ints[j, i];//j是行号
                i++;
                j++;
                while (j < ints.GetLength(0) && i < ints.GetLength(1)) {
                    
                    if (!(temp == ints[j, i])) {
                        return false;
                    }
                    i++;
                    j++;
                }
            }
            //左下角
            for (int i = 0; i < ints.GetLength(0) - 1; i++)
            {
                int j = 0;//j是列号
                int temp = ints[i, j];
                i++;
                j++;
                while (i < ints.GetLength(0) && j < ints.GetLength(1))
                {  
                    if (!(temp == ints[i, j]))
                    {
                        return false;
                    }
                    i++;
                    j++;//数组下标移动
                }
            }
            return true;
        }
    }
}
