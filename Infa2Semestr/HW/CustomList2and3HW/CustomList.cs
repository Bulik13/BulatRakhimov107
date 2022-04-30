using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infa2Semestr.HW.CustomList2and3HW
{
    public class CustomList : IEnumerable
    {
        public Node head;


        public CustomList()
        {
        }

        public CustomList(int a)
        {
            head = new Node(a);
        }

        /// <summary>
        /// добавление по умолчанию в конец
        /// </summary>
        /// <param name="a"></param>
        public void Add(int a)
        {
            var newNode = new Node(a);
            //отдельно отрабатываем пустой список
            if (head == null)
            {
                head = newNode;
                return;
            }

            //идем до конца пустого списка
            var headCopy = head;
            while (headCopy.NextNode != null)
                headCopy = headCopy.NextNode;
            headCopy.NextNode = newNode;
        }

        /// <summary>
        /// удаление последнего элемента
        /// </summary>
        public void DeleteTail(CustomList list)
        {
            var headCopy = head;
            var previous = head;
            if (headCopy == null)
                throw new ArgumentOutOfRangeException("Список пустой");

            while (headCopy.NextNode != null)
            {
                headCopy = headCopy.NextNode;
            }

            while (previous.NextNode != headCopy)
                previous = previous.NextNode;
            previous.NextNode = null;
        }

        public void DeleteHead(CustomList list)
        {
            var headCopy = head.NextNode;
            head = null;
            head = headCopy;
        }

        public void AddToHead(int a)
        {
            var newNode = new Node(a);
            newNode.NextNode = head;
            head = newNode;
        }


        /// <summary>
        /// добавление элемента на какую-то позицию
        /// </summary>
        /// <param name="a"></param>
        /// <param name="position"></param>
        public void Add(int a, int position)
        {
            if (position == 0)
            {
                AddToHead(a);
                return;
            }

            if (position < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            var headCopy = head;
            for (int i = 0; i <= position - 2; i++)
            {
                if (headCopy == null)
                    throw new ArgumentOutOfRangeException("Список недостаточно длинный");
                headCopy = headCopy.NextNode;
            }

            var newNode = new Node(a);
            //если добавляем не в конец, то к новому элементу записываем хвост
            if (headCopy.NextNode != null)
                newNode.NextNode = headCopy.NextNode;
            headCopy.NextNode = newNode;

        }

        /// <summary>
        /// удаление любого элемента
        /// </summary>
        /// <param name="list"></param>
        /// <param name="position"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void Delete(CustomList list, int position)
        {
            if (position == 0)
            {
                DeleteHead(list);
                return;
            }

            if (position < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            var headCopy = head;
            for (int i = 0; i <= position - 2; i++)
            {
                headCopy = headCopy.NextNode;
            }

            headCopy.NextNode = headCopy.NextNode.NextNode;
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
                result.Append(headCopy.InfField.ToString() + " ");
                headCopy = headCopy.NextNode;
            }

            return result.ToString();
        }

        public int Sum()
        {

            int sum = 0;
            var headCopy = head;

            if (headCopy == null)
            {
                throw new Exception("List is empty");
            }

            while (headCopy.NextNode != null)
            {
                sum += headCopy.InfField;
                headCopy = headCopy.NextNode;
            }

            sum += headCopy.InfField;
            return sum;
        }

        public void AddNumb(int k, int m)
        {
            var newNode = new Node(m);
            var newNodenew = new Node(m);

            var headCopy = head;

            if (headCopy.NextNode == null) throw new Exception("List is empty");

            while (headCopy.NextNode != null)
            {
                if (headCopy.NextNode.InfField == k)
                {
                    newNode.NextNode = headCopy.NextNode;
                    headCopy.NextNode = newNode;

                    headCopy = newNode.NextNode;
                    newNodenew.NextNode = headCopy.NextNode;
                    headCopy.NextNode = newNodenew;
                    break;
                }
            }

        }
        public void WriteOnConsole()
        {
            Console.WriteLine(ToString());
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

    }
}
