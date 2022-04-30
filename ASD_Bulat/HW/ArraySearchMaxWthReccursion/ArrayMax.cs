using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASD_Bulat.HW.ArraySearchMaxWthReccursion
{
    public class ArrayMax
    {
        public int MaxElem(int[] array)
        {
            int length = array.Length;
            if (length == 1)
                return array[0];
            if (length == 2)
                return (array[0] > array[1]) ? array[0] : array[1];
            int midle = length / 2;
            int[] m1 = new int[midle];
            for (int i = 0; i < midle; i++)
                m1[i] = array[i];
            int[] m2 = new int[length - midle];
            for (int i = midle; i < length; i++)
                m2[i - midle] = array[i];
            int res1 = MaxElem(m1);
            int res2 = MaxElem(m2);
            return res1 > res2 ? res1 : res2;
        }
        public void Run()
        {
            int[] array = new int[8] { 1, 5, 6, 24, 9, 13, 10, 2 };
            Console.WriteLine(MaxElem(array));

            int[] array2 = new int[7] { 0, 44, 12, 56, 9, 5, 10 };
            Console.WriteLine(MaxElem(array2));
        }
    }
}
