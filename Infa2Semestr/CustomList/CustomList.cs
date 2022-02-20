using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infa2Semestr
{
    /// <summary>
    /// Кастомный лист
    /// </summary>
    public class CustomList
    {
        /// <summary>
        /// Ссылка на 1 элемент связанного списка
        /// </summary>
        private Node head;

        public CustomList() { }

        public CustomList(int a)
        {
            head = new Node(a);
        }
        /// <summary>
        /// Добавление по умолчанию в конец
        /// </summary>
        public void Add(int a)
        {
            var newNode = new Node(a);

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

        public void AddToHead(int a)
        {
            var newNode = new Node(a);
            newNode.NextNode = head;
            head = newNode;
        }
        /// <summary>
        /// Добавление элемента на какую-то позицию (позиции от 1)
        /// </summary>
        public void Add(int a, int position)
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

            var newNode = new Node(a);
            //если добавляем не в конец, то новому элементу записываем хвост
            if (headCopy.NextNode != null)
                newNode.NextNode = headCopy.NextNode;
            headCopy.NextNode = newNode;
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
                result.Append(headCopy.InfField.ToString() + " ");
                headCopy = headCopy.NextNode;
            }
            return result.ToString();
        }

        public void WriteToConsole()
        {
            Console.WriteLine(ToString());
        }

        /// <summary>
        /// удаление головы
        /// </summary>
        public void DeleteHead()
        {
            if (head.NextNode != null)
                head = head.NextNode;
            else
            {
                Console.WriteLine("Лист состоит всего из одного элемента,удалить его? введите Y если да, N если нет");
                var answer = Console.ReadLine();
                if (answer == "Y")
                {
                    head = null;
                }
                else
                    throw new Exception("-1");
            }
        }
        /// <summary>
        /// удаление хвоста
        /// </summary>
        public void DeleteTail()
        {
            var headCopy = head;
            while (headCopy.NextNode.NextNode != null)
            {
                headCopy = headCopy.NextNode;
            }
            headCopy.NextNode = null;
        }
        /// <summary>
        /// удаление элемента на определенной позиции
        /// </summary>
        /// <param name="position"></param>
        public void Delete(int position)
        {
            if (position == 1)
            {
                DeleteHead();
                return;
            }
            var headCopy = head;
            for (int i = 1; i <= position - 2; i++)
            {
                headCopy = headCopy.NextNode;
            }
            headCopy.NextNode = headCopy.NextNode.NextNode;
        }
    }
}