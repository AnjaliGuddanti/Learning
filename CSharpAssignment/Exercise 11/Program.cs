using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_11
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] integers = new int[]
            {
                1,2,3,4,5,6,7,8,9  
            };
            foreach (int i in integers)
            {
                Console.Write("Checking : " + i.ToString() + ":\t");

                if (i.IsEven())
                {
                    Console.Write("Even");
                }
                if (i.IsOdd())
                {
                    Console.Write("Odd");
                }

                if (i.IsPrimeNumber())
                {
                    Console.Write(", Prime Number");
                }
                if (i.IsDivisible(2))
                {
                    Console.WriteLine(", IsDivisibleBy");
                }
                Console.Write("\n");
            }
            Console.ReadLine();
            



        }
    }
}
