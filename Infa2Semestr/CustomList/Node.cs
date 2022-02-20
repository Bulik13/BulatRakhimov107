using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infa2Semestr
{
    /// <summary>
    /// Элемент связанного списка
    /// </summary>
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
        /// Кoнстурктор
        /// </summary>
        public Node(int a)
        {
            InfField = a;
        }
    }
}
