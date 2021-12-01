using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.hw1
{
    public class RationalFraction
    {
        private int a;
        private int b;
        /// <summary>
        /// Числитель
        /// </summary>
        public int A { get { return a; } }
        /// <summary>
        /// Знаменатель
        /// </summary>
        public int B { get { return b; } }
        public RationalFraction()
        {
            a = 0;
            b = 1;
        }
        public RationalFraction(int x, int y)
        {
            a = x;
            b = y;

        }
        private void reduce_YourSelf()
        {
            int z = NOD(a, b);
            a = a / z;
            b = b / z;
        }
        private RationalFraction reduce(RationalFraction r)
        {
            int z = NOD(r.a, r.b);
            return new RationalFraction(r.a / z, r.b / z);
        }
        private int NOD(int x, int y)
        {
            x = Math.Abs(x);
            y = Math.Abs(y);
            while (x != 0 && y != 0)
            {
                if (x > y)
                    x = x % y;
                else
                    y = y % x;
            }
            return x + y;
        }
        private int NOK(int x, int y)
        {
            return x * y / NOD(x, y);
        }
        public RationalFraction Add(RationalFraction r)
        {
            int z = NOK(r.b, b);
            int z1 = z / b * a + z / r.b * r.a;
            RationalFraction newZ = new RationalFraction(z1, z);
            return reduce(newZ);
        }
        public void Add_ToYourself(RationalFraction r)
        {
            int z = NOK(r.b, b);
            a = z / b * a + z / r.b * r.a;
            b = z;
            reduce_YourSelf();
        }
        public RationalFraction Sub(RationalFraction r)
        {
            int z = NOK(r.b, b);
            int z1 = z / b * a - z / r.b * r.a;
            RationalFraction newZ = new RationalFraction(z1, z);
            return reduce(newZ);
        }
        public void Sub_ToYourself(RationalFraction r)
        {
            int z = NOK(r.b, b);
            a = z / b * a - z / r.b * r.a;
            b = z;
            reduce_YourSelf();
        }
        public RationalFraction Mult(RationalFraction r)
        {
            RationalFraction newZ = new RationalFraction(a * r.a, b * r.b);
            return reduce(newZ);
        }
        public void Mult_ToYourself(RationalFraction r)
        {
            a = a * r.a;
            b = b * r.b;
            reduce_YourSelf();
        }
        public RationalFraction Div(RationalFraction r)
        {
            RationalFraction newZ = new RationalFraction(a * r.b, b * r.a);
            return reduce(newZ);
        }
        public void Div_ToYourself(RationalFraction r)
        {
            a = a * r.b;
            b = b * r.a;
            reduce_YourSelf();
        }
        public int NumberPart()
        {
            return a / b;
        }
        public bool Equals(RationalFraction r)
        {
            r = reduce(r);
            var current = reduce(this);
            return r.A == current.A && r.B == current.B;
        }
        public string RFToString()
        {
            return $"{a}/{b}";
        }
    }
}
