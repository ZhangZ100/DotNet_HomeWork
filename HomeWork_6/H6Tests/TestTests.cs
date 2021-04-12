using Microsoft.VisualStudio.TestTools.UnitTesting;
using H6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H6.Tests
{
    [TestClass()]
    public class TestTests
    {
        [TestMethod()]
        public void testTest()
        {
            OrderService os = new OrderService();
            List<Order> list = new List<Order>();

            //模拟添加5个订单
            for (int i = 1; i <= 5; i++)
            {
                Order order = new Order("" + DateTime.Now + i, new Client("张" + i, i + "", i + ""),
                                        new OrderDetails(
                                            new Goods("货物" + i, 5), 10 - i));

                list.Add(order); //添加订单   
            }
            os.OrderList = list;
            os.Export("e:/test.xml");
            Console.WriteLine();
            Console.WriteLine("反序列化：\n\t");
            OrderService oss = os.Import("e:/test.xml");
            oss.OrderList.ForEach(s => Console.WriteLine(s));

            oss.Export("e:/test2.xml");
        }
    }
}