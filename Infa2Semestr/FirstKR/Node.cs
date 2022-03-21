using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infa2Semestr.FirstKR
{
    public class Node<T>
    {
        /// <summary>
        /// Информационное поле
        /// </summary>
        public T Value;
        /// <summary>
        /// Ссылка на следующий элемент
        /// </summary>
        public Node<T> NextNode;
        /// <summary>
        /// Констурктор
        /// </summary>
        public Node(T elem)
        {
            Value = elem;
        }
    }
}
