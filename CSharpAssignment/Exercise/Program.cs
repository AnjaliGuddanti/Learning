using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Reflection;
namespace Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating priority queue of students");
            var pqr = new PriorityQueue<Student>();
            var s1 = new Student("A", 1);
            var s2 = new Student("B", 2);
            var s3 = new Student("C", 3);
            var s4 = new Student("D", 4);
            var s5 = new Student("E", 5);
            var s6 = new Student("F", 6);
            Console.WriteLine($"Adding {s5} to priority queue");
            pqr.Enqueue(s5);
            Console.WriteLine($"Adding {s3} to priority queue");
            pqr.Enqueue(s3);
            Console.WriteLine($"Adding {s6} to priority queue");
            pqr.Enqueue(s6);
            Console.WriteLine($"Adding {s4} to priority queue");
            pqr.Enqueue(s4);
            Console.WriteLine($"Adding {s1} to priority queue");
            pqr.Enqueue(s1);
            Console.WriteLine($"Adding {s2} to priority queue");
            pqr.Enqueue(s2);
            Console.WriteLine("\nPriority queue elements are:");
            Console.WriteLine(pqr.ToString());
            Console.WriteLine($"Priority queue size is: {pqr.Count()}");
            Console.WriteLine();
            Console.WriteLine($"Peeking a student from queue: {pqr.Peek()}");
            Console.WriteLine("Removing a student from priority queue");
            var s = pqr.Dequeue();
            Console.WriteLine($"Removed student is {s}");
            Console.WriteLine("\nPriority queue is now:");
            Console.WriteLine(pqr.ToString()); Console.WriteLine();
            Console.WriteLine("Removing a second student from queue");
            s = pqr.Dequeue();
            Console.WriteLine($"Removed student is {s}");
            Console.WriteLine("\nPriority queue is now:");
            Console.WriteLine(pqr.ToString());
            Console.WriteLine();
            Console.ReadLine();
        }
    }

    public class Student : IComparable<Student>
    {
        public string LastName { get; }
        public double Priority { get; set; } 

        public Student(string lastName, double priority)
        {
            LastName = lastName;
            Priority = priority;
        }


        public override string ToString() => "(" + LastName + ", " + Priority.ToString("F1") + ")";


        public int CompareTo(Student other)
        {
            if (Priority < other.Priority)
                return -1;
            if (Priority > other.Priority)
                return 1;
            return 0;
        }
    }
    class PriorityQueue<T> where T : IEnumerable<T>
    {
        private readonly IDictionary<int, IList<T>> element;

        public PriorityQueue()
        {
            List<int> element = new List<int>();
        }
        public PriorityQueue(IDictionary<int, IList<T>> elements) : this()
        {
            List<int> _elements = new List<int>();
            foreach (T item in ICollection)
            {
                Enqueue(item.Priority, item);
            }
        }
        public int Count { get; private set; }
        public bool Contains(T item)
        {
            bool isContains = false;

            foreach (var otherItem in element.Values.ToArray().SelectMany(elem => elem))
            {
                foreach (PropertyInfo prop in item.GetType().GetProperties())
                {
                    isContains = prop.GetValue(item, null).Equals(prop.GetValue(otherItem, null));
                    if (!isContains)
                        break;
                }

                if (isContains == true)
                {
                    break;
                }
            }

            return isContains;
        }
        public T Peek() => element[0];
        /* public T Dequeue()
         {
             var first = element.First();
             var item = first.Value.Dequeue();
             if (!first.Value.Any())
             {
                 element.Remove(first.Key);
             }

             Count--;
             return item;
         }*/
        public T Dequeue()
        {
            var li = element.Count - 1;
            var FItem = element[0];
            element[0] = element[li];
            element.Remove(li);
            var pi = 0;
            while (true)
            {
                var ci = pi * 2 + 1;
                if (ci > li)
                    break;
                var rc = ci + 1;
                if (rc <= li && element[rc].CompateTo(element[ci]) < 0)
                    ci = rc;


                if (element[pi].CompareTo(element[ci]) <= 0)
                    break;
                Swap(pi, ci);
                pi = ci;
            }
            return FItem;
        }


        public void Enqueue(T priority, T item)
        {
            element.priority = priority;
            Queue<T> list;
            if (!element.TryGetValues(priority, out list))
            {
                list = new Queue<T>();
                element.Add(priority, list);
            }
            list.Enqueue(item);
            Count++;
        }
       
        public override string ToString()
        {
            var s = default(string);
            foreach (var elem in element)
                s += elem + " ";
            return s;
        }
        private void Swap(int firstIndex, int secondIndex)
        {
            var tmp = element[firstIndex];
            element[firstIndex] = element[secondIndex];
            element[secondIndex] = tmp;
        }
        public bool TryGetValue(T key, out T Value )
        {
            if (key == null) throw new ArgumentNullException();

            values = default(T element);
            bool found = false;
            List<T values> values;
            if (_SortedDictionary.TryGetValue(key, out values))
            {
                value = values[0];
                found = true;
            }
            return found;
        }

       
    }
}

    

