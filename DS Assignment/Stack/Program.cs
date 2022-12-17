using System;

namespace StackExersise
{
    class Program 
    {
        static void Main(string[] args)
        {
            int x;
            int choice = -1;
            try
            {
                Stack<int> stack1 = new Stack<int>();
                while (choice != 11)
                {
                    Console.WriteLine("Enter your required opetation: ");
                    Console.WriteLine("1.Push");
                    Console.WriteLine("2.Pop");
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
                            Console.WriteLine("Enter the element to push :");
                            x = int.Parse(Console.ReadLine());
                            stack1.Push(x);
                            break;
                        case 2:
                            Console.WriteLine("Delete the top item: {0}", stack1.Pop());
                            break;
                        case 3:
                            Console.WriteLine("The top item is {0}", stack1.Peek());
                            break;
                        case 4:
                            if (stack1.Contains(10))
                            {
                                Console.WriteLine("Stack contains item 10");
                            }
                            else
                            {
                                Console.WriteLine("Stack does not contain item 10");
                            }
                            break;
                        case 5:
                            Console.WriteLine("Stack size is: {0}", stack1.Size());
                            break;
                        case 6:
                            stack1.Center(stack1,stack1.Size());
                            break;
                        case 7:
                            stack1 = stack1.Sort(stack1);
                            stack1.Traverse();
                            break;
                        case 8:
                            stack1.Reverse();
                            Console.WriteLine("Reverse");
                            stack1.Traverse();
                            break;
                        case 9:
                            StackIterator<int> stackIterator = new StackIterator<int>(stack1);
                            Console.WriteLine("\nDisplay items using StackIterator");
                            while (!stackIterator.IsEmpty())
                            {
                                Console.WriteLine(stackIterator.Pop());
                            }
                            break;
                        case 10:
                            stack1.Traverse();
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

            Console.ReadLine();
        }
    }

}


        
        
        
       
        
        
       
        
        
            
    
   
   
   
        
       