using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_11
{
    public static class Extension_11
    {
        public static bool IsEven(this int i)
        {
            return ((i % 2) == 0);
        }
        public static bool IsOdd(this int i)
        {
            return ((i % 2) != 0);
        }

        public static bool IsPrimeNumber(this int i)
        {
            if (i == 1) return false;
            if (i == 2) return true;

            double boundry = Math.Floor(Math.Sqrt(i));

            for (int j = 2; j <= boundry; ++j)
            {
                if ((i % j) == 0)
                    return false;
            }

            return true;
        }
        public static bool IsDivisible(this int i,int a)
        {
            if((i % a)== 0)
            {
                return true;
            }
            return false;
        }
    }
}
