using System;

namespace LinkedList
{
    public class Program
    {
        static void Main(string[] args)
        {
            int choice, data, k, x;
            SingleLinkedList list = new SingleLinkedList();
            try
            {
                while (true)
                {

                    Console.WriteLine("1.Insert");
                    Console.WriteLine("2.Insert at position");
                    Console.WriteLine("3.Delete");
                    Console.WriteLine("4.Delete at position");
                    Console.WriteLine("5.Center");
                    Console.WriteLine("6.Sort");
                    Console.WriteLine("7.Reverse");
                    Console.WriteLine("8.Size");
                    Console.WriteLine("9.Iterator");
                    Console.WriteLine("10.Traverse/Print");
                    Console.WriteLine("Enter your required  functionality : ");
                    choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Enter value to insert :");
                            data = int.Parse(Console.ReadLine());
                            list.Insert(data);
                            break;
                        case 2:
                            Console.WriteLine("Enter the element to be inserted : ");
                            data = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter the position at which to insert :");
                            k = Convert.ToInt32(Console.ReadLine());
                            list.InsertAtPosition(data, k);
                            break;
                        case 3:
                            Console.WriteLine("Enter Element to delete : ");
                            data = int.Parse(Console.ReadLine());
                            list.Delete(data);
                            break;
                        case 4:
                            Console.WriteLine("Enter the position to delete : ");
                            x = int.Parse(Console.ReadLine());
                            list.DeleteAtPosition(x);
                            break;
                        case 5:
                            list.Center();
                            break;
                        case 6:
                            list.start = list.Sort(list.start);
                            list.Traverse();
                            break;
                        case 7:
                            list.Reverse();
                            break;
                        case 8:
                            list.Size();
                            break;
                        case 9:
                            list.Iterator();
                            break;
                        case 10:
                            list.Traverse();
                            break;
                        case 11:
                            break;
                        default:
                            Console.WriteLine("Enter valid input");
                            break;
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
        
    

