using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exersise_10
{
    class Program
    {
        static void Main(string[] args)
        {
            PriorityQueue3<int> pq = new PriorityQueue3<int>();

            //Enque Operation
            pq.Enqueue(10, 6);
            pq.Enqueue(30, 1);
            pq.Enqueue(90, 8);

            pq.Enqueue(60, 4);
            pq.Enqueue(88, 1);
            pq.Enqueue(72, 5);


            //peek()

            Console.WriteLine("Peek element : {0}",pq.Peek());

            //contain

            Console.WriteLine("10 contained in queue is : {0}", pq.Contains(10));

            //Deque
            Console.WriteLine("Dequeue element :{0}", pq.Dequeue());

            //count

            Console.WriteLine("Total number of element in queue :",pq.Count);

            //Get Highest Priority

            Console.WriteLine("HighestPriority : {0}", pq.GetHighestPriority());
            Console.ReadLine();
        }
    

        
        public class PriorityQueue3<T> where T : IEquatable<T>
        {
            private class PriorityNode
            {
                public int Priority { get; set; }
                public T Data { get; set; }
                public PriorityNode(int Priority, T Data)
                {
                    this.Priority = Priority;
                    this.Data = Data;
                }
            }

            private IList<PriorityNode> elements;

            public PriorityQueue3()
            {
                elements = new List<PriorityNode>();
            }
            public PriorityQueue3(IDictionary<int, IList<T>> elements) : this()
            {
                foreach (var ele in elements)
                {
                    foreach (var items in ele.Value)
                    {
                        this.elements.Add(new PriorityNode(ele.Key, items));
                    }
                }


            }
            public int Count
            {
                get
                {
                    return elements.Count;
                }
            }
            public bool Contains(T items)
            {
                foreach (var ele in elements)
                {
                    if (ele.Data.Equals(items))
                    {
                        return true;
                    }
                }
                return false;
            }
            public T Dequeue()
            {
                if (elements.Count == 0)
                {
                    throw new Exception("Empty List");
                }

                int highestPriority = GetHighestPriority();
                var list = elements.Where(ele => ele.Priority == highestPriority).ToList();
                elements.Remove(list[0]);
                return list[0].Data;

            }
            public void Enqueue(T item, int Priority)
            {

                foreach (var ele in elements)
                {
                    if (ele.Data.Equals(item))
                    {
                        Console.WriteLine("Element Already Present");
                        return;
                    }

                }
                elements.Add(new PriorityNode(Priority, item));



            }
            public T Peek()
            {
                if (elements.Count > 0)
                {
                    int highestPriority = GetHighestPriority();
                    var list = elements.Where(ele => ele.Priority == highestPriority).ToList();
                    return list[0].Data;
                }
                else
                    throw new Exception("No element found");

            }
            public int GetHighestPriority()
            {

                elements = elements.OrderByDescending(ele => ele.Priority).ToList();
                return elements[0].Priority;

            }

        }
    }
}
