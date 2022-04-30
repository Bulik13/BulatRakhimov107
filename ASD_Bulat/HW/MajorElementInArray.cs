using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASD_Bulat
{
    public class MajorElementInArray
    {
        public int MajorElement(int[] array, int N)
        {
            if (array.Length == 1)
                return array[0];
            var count = 0;
            var index = -1;
            for (var i = 0; i < array.Length; ++i)
            {
                var k = 1;
                for (var j = i + 1; j < array.Length; ++j)
                    if (array[i] == array[j]) k++;
                if (k <= count) continue;
                count = k;
                index = i;
            }
            return index;
        }
        public void WriteToConsole(int index)
        {
            Console.WriteLine(index);
        }
    }
}
