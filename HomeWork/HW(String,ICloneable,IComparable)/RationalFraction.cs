using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    public class RationalFraction : IComparable
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
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="x">Числитель</param>
        /// <param name="y">Знаменатель</param>
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
        /// <summary>
        /// Ниабольший общий делитель
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Наименьшее общее кратное
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private int NOK(int x, int y)
        {
            return x * y / NOD(x, y);
        }
        public double x;
        public double Calc()
        {
            x = a / b;
            return x;
        }
        public int CompareTo(object obj)
        {
            if (obj == null)
                return 1;
            RationalFraction compare = (RationalFraction)obj;
            if (obj != null && this != null)
            {
                if (this.Calc() > compare.Calc())
                    return 1;
                else if (this.Calc() < compare.Calc())
                    return -1;
                else
                {
                    return 0;
                }
            }
            else throw new Exception("Невозможно сравнить объекты");
        }
    }
}
