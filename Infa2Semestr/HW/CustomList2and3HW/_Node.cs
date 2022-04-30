using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infa2Semestr.HW.CustomList2and3HW
{
    public class _Node<T>
    {
        public T Infield { get; set; }
        public _Node<T> Next { get; set; }

        public _Node(T infield)
        {
            Infield = infield;
        }
    }
}
