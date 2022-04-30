using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infa2Semestr.HW.CustomList2and3HW
{
    public class LinkedList<T> : IEnumerable<T>
    {
        public _Node<T> head;
        public _Node<T> tail;

        public void AddRange(T infield)
        {
            _Node<T> newNode = new _Node<T>(infield);

            if (head == null)
                head = newNode;
            else
                tail.Next = newNode;
            tail = newNode;
        }

        public void Reverse()
        {
            _Node<T> headCopy = head;
            _Node<T> previous = null;
            _Node<T> next = null;

            while (headCopy != null)
            {
                next = headCopy.Next;
                headCopy.Next = previous;
                previous = headCopy;
                headCopy = next;
            }

            head = previous;
        }
        public override string ToString()
        {
            if (head == null)
            {
                return "Список пустой";
            }

            var headCopy = head;
            StringBuilder result = new StringBuilder();
            while (headCopy != null)
            {
                result.Append(headCopy.Infield.ToString() + " ");
                headCopy = headCopy.Next;
            }

            return result.ToString();
        }
        public void WriteOnConsole()
        {
            Console.WriteLine(ToString());
        }


        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
