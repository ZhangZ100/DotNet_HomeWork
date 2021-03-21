using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H4
{
    //主类
    class Program
    {
        static void Main(string[] args)
        {
            int[] ints={2,3,5,6,6,6,9,6,3,1,2,8,7};
            GenericList<int> list= new GenericList<int>();
            foreach (int var in ints) {
                list.Add(var);
            }
            Node<int> head=list.Head;
            
            list.ForEach(head ,temp=>Console.Write(temp + " "));         
            Console.WriteLine();

            int max = int.MinValue;
            list.ForEach(head, temp => max = Math.Max(temp, max));
            Console.WriteLine("max= " + max);

            int min = int.MaxValue;
            list.ForEach(head, temp => min = Math.Min(temp, min));
            Console.WriteLine("min= " + min);

            int sum = -1;
            list.ForEach(head, temp => sum += temp);
            Console.WriteLine("sum= " + sum);
        }
    }


    //结点类
    public class Node<T> { 
    public Node<T> Next { get; set; }
    public T Data { get; set; }

        public Node(T t)
        {
            Next = null;
            Data = t;
        }   
    }


    //泛型链表类
    public class GenericList<T> {
        private Node<T> head;
        private Node<T> tail;

        public GenericList() {
            head = tail = null;
        }


        public Node<T> Head{
        get=>head;
        }

        public void Add(T t){
        Node<T> n=new Node<T>(t);
            if(tail==null){
            head=tail=n;
            }else{
            tail.Next=n;
            tail=n;
            }
        }

        public void ForEach(Node<T> n,Action<T> action)
        {
            Node<T> node=n;
            while(node!=null){
                action(node.Data);//调用函数操作结点数据
                node=node.Next;
            }
        }
   
    }



}
