using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_1A3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter input : ");
            String a = Console.ReadLine();
            int o;
            bool b = int.TryParse(a, out o);
            Console.WriteLine("Integer for given input {0} is {1}", a, o);
            Console.ReadLine();
        }
    }
}
