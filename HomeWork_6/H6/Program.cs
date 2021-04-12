using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H6
{
    class Program
    {
         static void Main(string[] args)
        {
            OrderService os = new OrderService();
            List<Order> list = new List<Order>();

            //模拟添加5个订单
            for (int i = 1; i <= 5; i++) {
                Order order = new Order(""+DateTime.Now+i,new Client("张" + i, i + "", i + ""),
                                        new OrderDetails(
                                            new Goods("货物" + i, 5), 10-i));

                list.Add(order); //添加订单   
            }
            os.OrderList = list;
            foreach (Order o in os.OrderList) {
                Console.WriteLine(o);
            }
            Console.WriteLine();


            //模拟查询
            Console.WriteLine("货物1——————————模拟按货物名称查询货物1：");
            string name1 = "货物1";
            List<Order> list1 =os.SelectOrderByGoods(name1);
            foreach (Order o in list1)
            {
                Console.WriteLine(o);
            }
            Console.WriteLine();

            Console.WriteLine("张2——————————模拟按客户名称查询订单：");
            string name2 = "张2";
            List<Order> list2 = os.SelectOrderByClientName(name2);
            foreach (Order o in list2)
            {
                Console.WriteLine(o);
            }
            Console.WriteLine();

            Console.WriteLine("3——————————模拟按客户地址查询订单：");
            string name3 = "3";
            List<Order> list3 = os.SelectOrderByClientAddr(name3);
            foreach (Order o in list3)
            {
                Console.WriteLine(o);
            }
            Console.WriteLine();



            Console.WriteLine("4——————————模拟按客户电话查询订单：");
            string name4 = "4";
            List<Order> list4 = os.SelectOrderByClientAddr(name4);
            foreach (Order o in list4)
            {
                Console.WriteLine(o);
            }
            Console.WriteLine();

            Console.WriteLine("——————————模拟按金额查询订单："); 
            List<Order> list5 = os.SelectOrderByPrice();
            foreach (Order o in list5)
            {
                Console.WriteLine(o);
            }
            Console.WriteLine();


            //模拟修改
            Console.WriteLine("——————————模拟按id修改订单：输入id即可");
            string idd = Console.ReadLine();
            Client cli = new Client("模拟修改", "666", "888");
            OrderDetails d = new OrderDetails(new Goods("好吃的", 2), 100);
            os.UpdateOrderByID(idd,cli,d);
            foreach (Order o in list)
            {
                Console.WriteLine(o);
            }
            Console.WriteLine();

            //模拟删除
            Console.WriteLine("——————————模拟按id删除订单：输入id即可");
            string id = Console.ReadLine();
            
            os.DeleteByID(id);
            foreach (Order o in list)
            {
                Console.WriteLine(o);
            }
            Console.WriteLine();



            Console.ReadLine();
            
        }
    }
}
