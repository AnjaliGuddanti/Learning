using System;
using HashTable;

namespace HashTableExercise
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string key;
            int value, choice = -1; ;
            var h = new Hashtable<int>(1000);
            try
            {
                while (choice!=8)
                {
                    Console.WriteLine("1.Insert");
                    Console.WriteLine("2.Delete");
                    Console.WriteLine("3.Contains");
                    Console.WriteLine("4.Get Value by key");
                    Console.WriteLine("5.Size");
                    Console.WriteLine("6.Iterator");
                    Console.WriteLine("7.Traverse/Print");
                    Console.WriteLine("8.Exit");
                    Console.WriteLine("Enter your required  functionality : ");
                    choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Enter key value (string) :");
                            key = Console.ReadLine();
                            Console.WriteLine("Enter value (int) :");
                            value = int.Parse(Console.ReadLine());
                            h.Insert(key, value);
                            break;
                        case 2:
                            Console.WriteLine("Enter key to delete :");
                            key = Console.ReadLine();
                            h.Delete(key);
                            break;
                        case 3:
                            Console.WriteLine("Enter key :");
                            key = Console.ReadLine();
                            Console.WriteLine("HashTable Contains key : {0}", h.Contains(key));
                            break;
                        case 4:
                            Console.WriteLine("Enter key to get value :");
                            key = Console.ReadLine();
                            Console.WriteLine("key :{0} value is ",key + h.Get(key));
                            break;
                        case 5:
                            Console.WriteLine("Count : {0}", h.Size());
                            break;
                        case 6:
                            h.Iterator();
                            break;
                        case 7:
                            h.Traverse();
                            break;
                        case 8:
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
