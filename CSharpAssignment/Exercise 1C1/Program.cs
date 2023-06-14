using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_1C1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter input : ");
            String a = Console.ReadLine();
            bool b = Convert.ToBoolean(a);
            Console.WriteLine("Boolean value for given input {0} is {1}", a, b);
            Console.ReadLine();
        }
    }
}
