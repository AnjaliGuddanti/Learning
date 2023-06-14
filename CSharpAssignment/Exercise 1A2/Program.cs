using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_1A2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter input : ");
            String a = Console.ReadLine();
            int b = Convert.ToInt32(a);
            Console.WriteLine("Integer for given input {0} is {1}", a, b);
            Console.ReadLine();

        }
    }
}
