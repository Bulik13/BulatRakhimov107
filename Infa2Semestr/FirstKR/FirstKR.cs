using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infa2Semestr.FirstKR
{
    public class LinkedListQueue<T> : IQueue<T>,IEnumerable<T>
    {
        public Node<T> head;
        public Node<T> tail;
        public int count;
        public void Enqueue(T item)
        {
            Node<T> newnode = new Node<T>(item);
            Node<T> temp = tail;
            tail = newnode;
            if (count == 0)
            {
                head = tail;
            }
            else
            {
                temp.NextNode = tail;
            }

            count++;
        }

        public T Dequeue()
        {
            if (count == 0)
            {
                throw new Exception("queue is empty");
            }
            else
            {
                var output = head.Value;
                head = head.NextNode;
                count--;
                return output;
            }
        }

        public bool Contains(T item)
        {
            Node<T> tempNode = head;
            for (int i = 0; i < count; i++)
            {
                if (tempNode.Value.Equals(item))
                {
                    return true;
                }
                tempNode = tempNode.NextNode;
            }
            return false;
        }

        public T Peek()
        {
            return head.Value;
        }

        public void Clear()
        {
            head = null;
        }

        public int Size()
        {
            return count;
        }
        public bool isEmpty()
        {
            return head == null;
        }
        
        //удаление 3 элемента с конца списка
        public void DeleteFromTail()
        {
            var size = Size();
            if (size < 3)
                throw new Exception("очередь имеет размер меньше 3");
            else if (size == 3)
                Dequeue();
            else
            {
                var countOfSteps = size - 3;
                var headCopy = head;
                var i = 1;
                while (i < countOfSteps)
                {
                    headCopy = headCopy.NextNode;
                    i++;
                }
                headCopy.NextNode = null;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new LinkedListQueueEnumerator<T>(head,tail,count);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class LinkedListQueueEnumerator<T> : IEnumerator<T>
    {
        private readonly Node<T> headX;
        private readonly Node<T> tailX;
        private Node<T> currentNode;
        private int countX;
        private int iterator = -1;
        public LinkedListQueueEnumerator(Node<T> head,Node<T> tail, int count)
        {
            headX = head;
            tailX = tail;
            countX = count;
            currentNode = new Node<T>(default(T));
        }
        public T Current => currentNode.Value;

        object IEnumerator.Current => Current;


        public bool MoveNext()
        {
            iterator++;
            if (currentNode.NextNode != null)
            {
                currentNode = currentNode.NextNode;
                return true;
            }
            else
                return false;
        }

        ////public IEnumerator GetEnumerator()
        ////{
        ////    for (int i = 0; i < countX; i += 2)
        ////        yield return _people[i];
        ////    for (int i = 1; i <= countX; i += 2)
        ////        yield return _people[i];
        ////}   

        public void Reset()
        {
            iterator = -1;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
