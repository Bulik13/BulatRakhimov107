using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASD_Bulat.HW.Last_HW_Karatsuba
{
    internal class Karatsuba
    {
        public int Calc(int a, int b)
        {
            var result = calc(a, b);
            return result;
        }
        private int IntLength(int a)
        {
            if (a == 0)
                return 1;

            var num = Math.Abs(a);

            var result = Math.Log10(num) + 1;

            return (int)result;
        }
        private int calc(int a, int b)
        {
            if (b == 0 || a == 0) return 0;
            if (a == 1) return b;
            if (b == 1) return a;
            if (a < 10 || b < 10) return a * b;

            int aLength = IntLength(a);
            int bLength = IntLength(b);
            int halfLength = Math.Min(aLength, bLength) / 2;

            int a1 = a / (int)Math.Pow(10, halfLength);
            int a2 = a % (int)Math.Pow(10, aLength - halfLength);
            int b1 = b / (int)Math.Pow(10, halfLength);
            int b2 = b % (int)Math.Pow(10, bLength - halfLength);

            int ac = calc(a1, b1);
            int bd = calc(a2, b2);

            var sumFirst = a1 + a2;
            var sumSecond = b1 + b2;
            int bigsum = calc(sumFirst, sumSecond);

            var middle = bigsum - ac - bd;
            int numeralResult = ac * (int)Math.Pow(10, halfLength * 2) +
                middle * (int)Math.Pow(10, halfLength) + bd;

            return numeralResult;
        }
    }
}
