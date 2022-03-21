using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infa2Semestr.FirstKR
{
    public class CustomList<T> : ICustomCollection<T> where T : IComparable<T>
    {
        //public IEnumerator<T> GetEnumerator()
        //{
        //    return new CustomListEnumerator<T>(head);
        //}

        /// <summary>
        /// Ссылка на 1 элемент связанного списка
        /// </summary>
        private Node<T> head;

        public CustomList() { }

        public CustomList(T a)
        {
            head = new Node<T>(a);
        }

        public CustomList(T[] array)
        {
            foreach (var el in array)
            {
                Add(el);
            }
        }

        /// <summary>
        /// Добавление по умолчанию в конец
        /// </summary>
        public void Add(T a)
        {
            var newNode = new Node<T>(a);

            //отдельно отрабатываем случай пустого списка
            if (head == null)
            {
                head = newNode;
                return;
            }

            //идем до конца списка
            var headCopy = head;
            while (headCopy.NextNode != null)
                headCopy = headCopy.NextNode;

            headCopy.NextNode = newNode;
        }

        public void AddToHead(T a)
        {
            var newNode = new Node<T>(a);
            newNode.NextNode = head;
            head = newNode;
        }
        /// <summary>
        /// Добавление элемента на какую-то позицию (позиции от 1)
        /// </summary>
        public void Insert(int position, T a)
        {
            if (position == 1)
            {
                AddToHead(a);
                return;
            }

            var headCopy = head;
            for (int i = 1; i <= position - 2; i++)
            {
                if (headCopy == null)
                    throw new ArgumentOutOfRangeException("Список недостаточной длины");
                headCopy = headCopy.NextNode;
            }

            var newNode = new Node<T>(a);
            //если добавляем не в конец, то новому элементу записываем хвост
            if (headCopy.NextNode != null)
                newNode.NextNode = headCopy.NextNode;
            headCopy.NextNode = newNode;
        }
        public void AddRange(T[] elems)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            var headCopy = head;
            StringBuilder result = new StringBuilder();
            if (head == null)
            {
                return "Список пуст";
            }
            while (headCopy != null)
            {
                result.Append(headCopy.Value.ToString() + " ");
                headCopy = headCopy.NextNode;
            }
            return result.ToString();
        }

        public void WriteToConsole()
        {
            Console.WriteLine(ToString());
        }

        /// <summary>
        /// По умолчанию удаляет конец
        /// </summary>
        /// <param name="a"></param>
        public void Delete()
        {
            if (head == null)
            {
                Console.WriteLine("Список пуст");
                return;
            }
            var headCopy = head;
            if (headCopy.NextNode == null)
            {
                head = null;
                return;
            }
            while ((headCopy.NextNode).NextNode == null)
            {
                headCopy = headCopy.NextNode;
            }
            headCopy.NextNode = null;
        }

        /// <summary>
        /// Удаление первого элемента
        /// </summary>
        public void DeleteHead()
        {
            if (head == null)
            {
                Console.WriteLine("Список пуст, " +
                    "удаление первого элемента не осуществлено");
                return;
            }
            head = head.NextNode;
        }
        public void Remove(T el)
        {
            throw new NotImplementedException();
        }
        public void RemoveAt(int position)
        {
            throw new NotImplementedException();
        }
        public void Clear()
        {
            head = null;
        }
        public void Reverse()
        {
            if (head == null || head.NextNode == null)
            {
                return;
            }
            Node<T> headReverse = null;
            while (head != null)
            {
                //Создаем новый узел
                var newNode = new Node<T>(head.Value);
                //новый элемент ссылается на 1 элемент перевернутного списка
                newNode.NextNode = headReverse;
                headReverse = newNode;

                //Удаление элемента из изначального списка
                head = head.NextNode;
            }
            head = headReverse;

        }
        /// <summary>
        /// Удалить все вхождения какого-то значения
        /// </summary>
        /// <param name="value"></param>
        public void RemoveAll(T value)
        {
            if (head == null)
                return;
            while (head != null && head.Value.CompareTo(value) == 0)
                DeleteHead();

            if (head != null)
                DelAllValFromSecondElem(value, head);
        }
        private void DelAllValFromSecondElem
            (T value, Node<T> headCopy)
        {
            if (headCopy.NextNode == null)
                return;

            if (headCopy.NextNode.Value.CompareTo(value) == 0)
            {
                DeleteSecondElement(headCopy);
                DelAllValFromSecondElem(value, headCopy);
            }
            else
            {
                DelAllValFromSecondElem(value, headCopy.NextNode);
            }
        }

        /// <summary>
        /// Удаление второго элемента
        /// </summary>
        /// <param name="headCopy"></param>
        private void DeleteSecondElement(Node<T> headCopy)
        {
            if (headCopy == null || headCopy.NextNode == null)
                throw new Exception("В методе DeleteSecondElement неверные входные данные");

            headCopy.NextNode = headCopy.NextNode.NextNode;
        }


        /// <summary>
        /// Длина списка
        /// </summary>
        public int Size()
        {
            int length = 0;

            if (head != null)
            {
                var headCopy = head;
                while (headCopy != null)
                {
                    length++;
                    headCopy = headCopy.NextNode;
                }
            }

            return length;
        }
        public bool isEmpty()
        {
            return head == null;
        }
        public bool Contains(T el)
        {
            throw new NotImplementedException();
        }
        public int IndexOf(T el)
        {
            throw new NotImplementedException();
        }

        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
