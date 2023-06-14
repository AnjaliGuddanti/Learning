using System;
namespace QueueExercise
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int choice = -1,x;
                Queue<int> myQueue = new Queue<int>();

                while (choice != 11)
                {
                    Console.WriteLine("Enter your required opetation: ");
                    Console.WriteLine("1.Enqueue");
                    Console.WriteLine("2.Dequeue");
                    Console.WriteLine("3.Peek");
                    Console.WriteLine("4.Contains");
                    Console.WriteLine("5.Size");
                    Console.WriteLine("6.Center");
                    Console.WriteLine("7.Sort");
                    Console.WriteLine("8.Reverse");
                    Console.WriteLine("9.Iterator");
                    Console.WriteLine("10.Traverse/Print");
                    choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Enter the element to Enqueue :");
                            x = int.Parse(Console.ReadLine());
                            myQueue.Enqueue(x);
                            break;
                        case 2:
                           Console.WriteLine("Delete the top item: {0}", myQueue.Dequeue());
                            break;
                        case 3:
                             Console.WriteLine("Peek item :{0}",myQueue.Peek());
                            break;
                        case 4:
                            if (myQueue.Contains(10))
                            {
                                Console.WriteLine("Queue contains item 10");
                            }
                            else
                            {
                                Console.WriteLine("Queue does not contain item 10");
                            }
                            break;
                        case 5:
                            Console.WriteLine("Queue size is: {0}", myQueue.Size());
                            break;
                        case 6:
                           myQueue.Center();
                            break;
                        case 7:
                            myQueue.Sort(ref myQueue);
                            myQueue.Reverse();
                            Console.WriteLine("sorted Queue :");
                            myQueue.Print();
                            break;
                        case 8:
                            myQueue.Reverse();
                            Console.WriteLine("Reverse");
                            myQueue.Print();
                            break;
                        case 9:
                           QueueIterator<int> QueueIterator = new QueueIterator<int>(myQueue);
                            if (QueueIterator.IsEmpty())
                            {
                                Console.WriteLine("Queue is empty");
                            }
                            else
                            {
                                Console.WriteLine("Display items using QueueIterator");
                                while (!QueueIterator.IsEmpty())
                                {
                                    Console.WriteLine(QueueIterator.Dequeue());
                                }
                            }
                            break;
                        case 10:
                            Console.WriteLine("Items in the Queue are:");
                            myQueue.Print();
                            break;
                        case 11:
                            break;
                        default:
                            Console.WriteLine("Enter valid input");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
