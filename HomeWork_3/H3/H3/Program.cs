using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H3
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle re=new Rectangle(6, 5);
            Console.WriteLine("长方形面积："+re.GetArea());

            Square se = new Square(6);
            Console.WriteLine("正方形面积：" + se.GetArea());

            Triangle te = new Triangle(6, 5, 4);
            Console.WriteLine("三角形面积：" + te.GetArea());
        }
    }

    public interface Graph {
        //图形基类
         double GetArea();

         bool IsIegal();
    }

    //长方形类
    public class Rectangle : Graph {
        private double length;
        private double width;

        public Rectangle(double length, double width)
        {
            this.length = length;
            this.width = width;
        }

        public double GetArea()
        {
            if(this.IsIegal())
            return this.length*this.width;

            return -1;
        }

        public  bool IsIegal()
        {
            if(this.length>0 && this.width>0)
            return true;

            return false;
        }
    }

    //正方形类
    public class Square : Graph
    {
        private double sideLength;


        public Square(double sideLength)
        {
            this.sideLength = sideLength;
        }

        public double GetArea()
        {
            if (this.IsIegal())
                return this.sideLength* this.sideLength;

            return -1;
        }

        public bool IsIegal()
        {
            if (this.sideLength > 0)
                return true;

            return false;
        }
    }

    //正方形类
    public class Triangle : Graph
    {
        private double sideLength_1;
        private double sideLength_2;
        private double sideLength_3;

        public Triangle(double sideLength_1, double sideLength_2, double sideLength_3)
        {
            this.sideLength_1 = sideLength_1;
            this.sideLength_2 = sideLength_2;
            this.sideLength_3 = sideLength_3;
        }

        public double GetArea()
        {
            if (!this.IsIegal())
                return -1;

            //海伦公式
            double p = (this.sideLength_1+ this.sideLength_2+ this.sideLength_3) / 2;
            double area = Math.Sqrt(p*(p-sideLength_1) * (p - sideLength_2) * (p - sideLength_3));
            return area;
        }

        public bool IsIegal()
        {
            if ((this.sideLength_1 > 0 && this.sideLength_2 > 0 && this.sideLength_3 > 0)
                && this.sideLength_1+ this.sideLength_2> this.sideLength_3
                && this.sideLength_1+ this.sideLength_3> this.sideLength_2
                && this.sideLength_3+ this.sideLength_2> this.sideLength_1
                )
                return true;

            return false;
        }
    }
}
