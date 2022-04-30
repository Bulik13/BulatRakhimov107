using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infa2Semestr.HW.CustomList2and3HW
{
    public class Node
    {
        /// <summary>
        /// Информационное поле
        /// </summary>
        public int InfField;
        /// <summary>
        /// Ссылка на следующий элемент
        /// </summary>
        public Node NextNode;

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="a"></param>

        public Node(int a)
        {
            InfField = a;
        }

    }
}
