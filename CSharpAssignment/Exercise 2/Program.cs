using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // == operator compares two specified objects return true if both objects are same otherwise return false
            Console.WriteLine("== operater output is : {0}", ("a" == 'a'.ToString()));
            //Object.Equals compares content of two objects 
            //They can be in seperate memory locations and be equal
            bool b = object.Equals("a", 'a'.ToString());
            Console.WriteLine("Object.Equals method output is :{0} ", b);
            //object.ReferenceEquals compares the reference of two objects
            //They can only be equal if they are in same memory location
            b = object.ReferenceEquals("a", 'a'.ToString());
            Console.WriteLine("Object.Reference method output is :{0} ", b);6
            Console.ReadLine();
        }
    }
}
