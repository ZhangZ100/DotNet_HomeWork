using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.IO;
using System.Collections.ObjectModel;

namespace H8
{
    class OrderAbout
    {
    }

    //客户类
    [Serializable]
    public class Client{
        public string Name{set;get;}
        public string PhoneNumber{set;get;}
        public string Address{set;get;}

        public Client()
        {
        }

        public Client(string name, string phoneNumber, string address)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            PhoneNumber = phoneNumber ?? throw new ArgumentNullException(nameof(phoneNumber));
            Address = address ?? throw new ArgumentNullException(nameof(address));
        }

        public override string ToString()
        {
            return "客户姓名："+Name+" 电话："+PhoneNumber+" 地址："+Address;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    //货物类
    [Serializable]
    public class Goods{
        public string Name { set; get; }
        public int Price { set; get; }//单价

        public Goods()
        {
        }

        public Goods(string name, int price)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Price = price;
        }

        public override string ToString()
        {
            return "    货物名："+Name+" 单价："+Price;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    //订单类
    [Serializable]
    public class Order {
        public string Id { set; get; }
        public Client Client { set; get; }
        public OrderDetails Detail { set; get; }

        public Order()
        {
        }

        public Order( string id,Client client, OrderDetails detail)
        {
            Id = id;
            Client = client ?? throw new ArgumentNullException(nameof(client));
            Detail = detail ?? throw new ArgumentNullException(nameof(detail));
        }

        public override bool Equals(object obj)
        {
            return obj is Order order &&
                   Id == order.Id &&
                   EqualityComparer<Client>.Default.Equals(Client, order.Client) &&
                   EqualityComparer<OrderDetails>.Default.Equals(Detail, order.Detail);
        }

        public override int GetHashCode()
        {
            int hashCode = -806919518;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Client>.Default.GetHashCode(Client);
            hashCode = hashCode * -1521134295 + EqualityComparer<OrderDetails>.Default.GetHashCode(Detail);
            return hashCode;
        }

        //包含了货物名，单价，数量的信息
        public int totalPrice() {
            return this.Detail.Goods.Price * this.Detail.Number;
        }

        public override string ToString()
        {
            string price = totalPrice() + "";
            return "订单号："+Id+"  "+this.Client+this.Detail+"   总Price："+price;
        }
    }

    //订单明细类
    [Serializable]
    public class OrderDetails
    {
        
        public Goods Goods { set; get; }
        public int Number{ set; get; }//数量

        public OrderDetails()
        {
        }

        public OrderDetails(Goods goods, int number)
        {
            Goods = goods ?? throw new ArgumentNullException(nameof(goods));
            Number = number;
        }

        public override bool Equals(object obj)
        {
            return obj is OrderDetails details &&
                   EqualityComparer<Goods>.Default.Equals(Goods, details.Goods) &&
                   Number == details.Number;
        }

        public override int GetHashCode()
        {
            int hashCode = -1867236807;
            hashCode = hashCode * -1521134295 + EqualityComparer<Goods>.Default.GetHashCode(Goods);
            hashCode = hashCode * -1521134295 + Number.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return Goods+" 数量:"+Number;
        }
    }

    [Serializable]
    public class OrderService
    {
        public  List<Order> OrderList { set; get; }//订单表

        public OrderService()
        {
        }

        public OrderService(List<Order> orderList)
        {
            OrderList = orderList ?? throw new ArgumentNullException(nameof(orderList));
        }



        //默认排序按订单号排序
        public void Sort()
        {
            OrderList.Sort();
        }

        //Lambda表达式进行自定义排序
        public void Sort(Comparison<Order> func)
        {
            OrderList.Sort(func);
        }

        //增加订单
        public void Add(string id,Client client, OrderDetails detail)
        {
            Order o = new Order( id,client, detail);
            var query = from or in OrderList
                        where or.Detail==detail&&or.Client==client
                        select or;
            if (query != null) {
                throw new Exception("订单已存在");
            }
            OrderList.Add(o);
        }

        //通过订单号删除订单
        public void DeleteByID(string id)
        {
            foreach (Order o in OrderList) { if (o.Id == id) { OrderList.Remove(o); return; } }
            try { throw new Exception("id不存在"); } catch {
                Console.WriteLine("id不存在");
            }
        }



        //修改订单
        public void UpdateOrderByID(string id, Client client,OrderDetails detail)
        {
           var query = from o in OrderList
                       where o.Id==id
                       select o;
            if (query == null) { throw new Exception("请输入有效id "); }
            foreach (Order ord in query)
            {
                //只会查出至多一个Order
                ord.Detail = detail;
                ord.Client = client;
            }

        }

        //通过id查询订单
        public List<Order> SelectOrderByID(int id)
        {
            List<Order> olist = new List<Order>();
            var query = from o in OrderList
                        where o.Id == "" + id
                        orderby o.totalPrice()
                        select o;
            if (query == null) { throw new Exception("请输入有效id "); }
            foreach (Order ord in query)
            {
                olist.Add(ord); 
            }
            return olist;
        }


        //通过客户名查询订单
        public List<Order> SelectOrderByClientName(string c)
        {
            List<Order> olist = new List<Order>();
            var query = from o in OrderList
                        where o.Client.Name==c
                        orderby o.totalPrice()
                        select o;
            if (query == null) { throw new Exception("请输入有效客户名 "); }
            foreach (Order ord in query)
            {
                olist.Add(ord);
            }
            return olist;
        }

        //通过客户住址查询订单
        public List<Order> SelectOrderByClientAddr(string addr)
        {
            List<Order> olist = new List<Order>();
            var query = from o in OrderList
                        where o.Client.Address == addr
                        orderby o.totalPrice()
                        select o;
            if (query == null) { throw new Exception("请输入有效地址 "); }
            foreach (Order ord in query)
            {
                olist.Add(ord);
            }
            return olist;
        }

        //通过客户名查询订单
        public List<Order> SelectOrderByClientPhone(string p)
        {
            List<Order> olist = new List<Order>();
            var query = from o in OrderList
                        where o.Client.PhoneNumber == p
                        orderby o.totalPrice()
                        select o;
            if (query == null) { throw new Exception("请输入有效电话 "); }
            foreach (Order ord in query)
            {
                olist.Add(ord);
            }
            return olist;
        }

        //通过货物名查询订单
        public List<Order> SelectOrderByGoods(string c)
        {
            List<Order> olist = new List<Order>();
            var query = from o in OrderList
                        where o.Detail.Goods.Name == c
                        orderby o.totalPrice()
                        select o;
            if (query == null) { throw new Exception("请输入有效货物名 "); }
            foreach (Order ord in query)
            {
                olist.Add(ord);
            }
            return olist;
        }

        //通过金额查询订单
        public List<Order> SelectOrderByPrice()
        {
            List<Order> olist = new List<Order>();
            var query = from o in OrderList
                        orderby o.totalPrice()
                        select o;
            foreach (Order ord in query)
            {
                olist.Add(ord);
            }
            return olist;
        }


        //Export方法序列化所有订单
        public void Export(string fileName)
        {
            XmlSerializer xs = new XmlSerializer(typeof(OrderService)); //把对象类型作为参数
            
            using (Stream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write))
            {
                xs.Serialize(fs,this);
            }
            Console.WriteLine("OrderList.xml:\n\t");
            Console.WriteLine(File.ReadAllText(fileName));
        }

        public OrderService  Import(string fileName)
        {
            XmlSerializer xs = new XmlSerializer(typeof(OrderService)); //把对象类型作为参数
            using (Stream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                OrderService os= (OrderService)xs.Deserialize(fs);
                return os;
            }
        }

    }
}

        


