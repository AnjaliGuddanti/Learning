using System;
namespace PriorityQueue
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MyPriorityQueue queue = new MyPriorityQueue();
            queue.CreatePriorityQueue();
            Console.WriteLine("Priority queue elements :");
            queue.PrintQueue();
            queue.Center();
            queue.Dequeue();
            Console.WriteLine("Priority queue elements after Dequeue :");
            queue.PrintQueue();
            Console.WriteLine("Priority queue elements with iterator : ");
            queue.Iterator();
            queue.Peek();
            queue.Contains(20);
            queue.Size();
            Console.ReadLine();
        }
    }
}