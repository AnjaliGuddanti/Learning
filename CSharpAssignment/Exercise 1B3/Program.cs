using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_1B3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter input : ");
            String a = Console.ReadLine();
            float b = Convert.ToSingle(a);
            Console.WriteLine("Float for given input {0} is {1}", a, b);
            Console.ReadLine();
        }
    }
}
