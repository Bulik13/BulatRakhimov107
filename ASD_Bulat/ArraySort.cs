using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ASD
{
    public class ArraySort
    {
        public int[] JoinArray(int[] a1, int[] a2)
        {
            if (a1?.Length == 0 && a2?.Length == 0)
            {
                Console.WriteLine(" Array is empty");
                return null;
            }
            if (a1?.Length == 0 && a2?.Length > 0)
                return a2;
            if (a2?.Length == 0 && a1?.Length > 0)
                return a1;
            //текущая позиция в массивах
            int i1 = 0;
            int i2 = 0;
            int[] result = new int[a1.Length + a2.Length];
            int iResult = 0;
            while (i1 < a1.Length && i2 < a2.Length)
            {
                if (a1[i1] < a2[i2])
                {
                    result[iResult] = a1[i1];
                    i1++;
                }
                else
                {
                    result[iResult] = a2[i2];
                    i2++;
                }
                iResult++;
            }
            if (i1 < a1.Length)
                for (int i = i1; i < a1.Length; i++)
                {
                    result[iResult] = a1[i];
                    iResult++;
                }
            if (i2 < a2.Length)
                for (int i = i2; i < a2.Length; i++)
                {
                    result[iResult] = a2[i];
                    iResult++;
                }
            return result;
        }
    }
}