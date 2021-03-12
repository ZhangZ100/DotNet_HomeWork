
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using H3;

namespace H3_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            GraphFactory factory = new GraphFactory();
            Graph graph = null;
            double sum = 0;//总面积
            int count_0 = 0;
            int count_1 = 0;
            int count_2 = 0;//计数器
            int index = 0;//用于工厂创建图形的索引

            for (int i = 0; i < 10; i++) {
                index = r.Next(0, 3);
                if (index == 0)
                {
                    count_0++;
                    graph=factory.CreateGraph(index);
                    sum += graph.GetArea();
                }

                if (index == 1)
                {
                    count_1++;
                    graph = factory.CreateGraph(index);
                    sum += graph.GetArea();
                }

                if (index == 2)
                {
                    count_2++;
                    graph = factory.CreateGraph(index);
                    sum += graph.GetArea();
                }
            }

            Console.WriteLine("创建了  "+count_0+"个长方形， "
                + count_1 + "个正方形， "
                + count_2 + "个三角形， "
                + "总面积为："+sum);
           
        }
    }

    class GraphFactory
    {
        //用来创建图形的边长数据集
        int[,] rectangle = { { 4, 5 }, { 2, 6 }, { 7, 9 } };
        int[] square = { 7, 11, 15, 22, 3 };
        int[,] triangle = { { 4, 5, 6 }, { 2, 6, 6 }, { 7, 9, 9 } };
         Random r = new Random();

        private Rectangle CreateRectangle()
        {
            int num = r.Next(0, 3);
            //获取数据集中数据在第几行 
            return new Rectangle(rectangle[num, 0], triangle[num, 1]);
        }

        private Square CreateSquare()
        {
            int num = r.Next(0,5);
            //获取数据集中数据在第几行 
            return new Square(square[num]);
        }

        private Triangle CreateTriangle()
        {
            int num = r.Next(0, 3);
           //获取数据集中数据在第几行 
            return new Triangle(triangle[num,0], triangle[num, 1], triangle[num, 2]);
        }

        public Graph CreateGraph(int index) {
            //0 1 2分别对应三种图形
            if (index == 0) {
                return new GraphFactory().CreateRectangle();
            }
            if (index == 1)
            {
                return new GraphFactory().CreateSquare();
            }
            if (index == 2)
            {
                return new GraphFactory().CreateTriangle();
            }
            return null;
        }



    }
}
