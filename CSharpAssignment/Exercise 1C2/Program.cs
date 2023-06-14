using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_1C2
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter input : ");
            String a = Console.ReadLine();
            Boolean b;
            if(Boolean.TryParse(a, out b))
            {
                Console.WriteLine("Boolean value for given input {0} is {1}", a, b);
                Console.ReadLine();
            }
        }
    }
}
