using System;
namespace PriorityQueue
{
    /// <summary>
    /// Node class
    /// </summary>
    public class Node
    {
        public int priority;
        public int data;
        public Node next;
        public Node(int priority, int data)
        {
            this.priority = priority;
            this.data = data;
            this.next = null;
        }
        /// <summary>
        /// printing elements of Priority Queue
        /// </summary>
        public void Print()
        {
            Console.Write($"[Data : {data} and Priority: {priority} ] ");
            if (next != null)
            {
                next.Print();
            }
            Console.WriteLine();
        }
        /// <summary>
        /// Iterator method
        /// </summary>
        public void Iterator()
        {
            Console.WriteLine("Data -> {0}", data);
            if (next != null)
            {
                next.Iterator();
            }
        }
    }
}