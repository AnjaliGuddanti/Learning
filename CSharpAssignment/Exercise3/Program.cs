using System;

namespace EXERCISE3
{
    class Program
    {
        static void Main(string[] args)
        {
            int a, b;
            Console.WriteLine("Enter two positive non-equal integers between 2 and 1000");
            a = int.Parse(Console.ReadLine());
            b = int.Parse(Console.ReadLine());
            Program.Check(a, b);

        }
        public static void Check(int a, int b)
        {
            if (a >= 2 && a <= 1000 && b >= 2 && b <= 1000 && a < b)
            {
                Console.WriteLine("prime numbers between two given numbers {0} and {1} are:", a, b);
                int i, j, flag;
                for (i = a; i <= b; i++)
                {
                    flag = 1;
                    for (j = 2; j <= i / 2; j++)
                    {
                        if (i % j == 0)
                        {
                            flag = 0;
                            break;
                        }
                    }
                    if (flag == 1)
                    {
                        Console.WriteLine(i);
                    }
                    
                }
                Console.ReadLine();
            }
            else
            {
                Program.ReEnter();
            }
        }
        public static void ReEnter()
        {
            int a, b;
            Console.WriteLine("re-enter two positive non-equal integers between 2 and 1000");
            a = int.Parse(Console.ReadLine());
            b = int.Parse(Console.ReadLine());
            Program.Check(a, b);
            
        }
    }

}

