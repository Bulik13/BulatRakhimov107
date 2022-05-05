using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infa2Semestr.SecondKR.Tree
{
    public class BinarySearchTree<T>
    {
        private BinaryTreeNode<T> root;

        public void Add(T value, int key)
        {

            if (root == null)
                root = new BinaryTreeNode<T>(value, key);
            else
            {
                int level = 0;
                bool isFind = false;
                var rootCopy = root;
                while (isFind == false)
                {
                    if (key == rootCopy.Key)
                    {
                        rootCopy.Value = value;
                        rootCopy.Level = level;
                        isFind = true;
                    }
                    else if (key < rootCopy.Key)
                    {
                        if (rootCopy.LeftChild == null)
                        {
                            rootCopy.LeftChild = new BinaryTreeNode<T>(value, key, rootCopy);
                            rootCopy.LeftChild.Level = level + 1;
                            isFind = true;
                        }
                        else
                            rootCopy = rootCopy.LeftChild;
                    }
                    else
                    {
                        if (rootCopy.RightChild == null)
                        {
                            rootCopy.RightChild = new BinaryTreeNode<T>(value, key, rootCopy);
                            rootCopy.RightChild.Level = level + 1;
                            isFind = true;
                        }
                        else
                            rootCopy = rootCopy.RightChild;
                    }
                    level++;
                }
            }
        }

        public void PrintNodesWithLengthN(int n)
        {
            List<BinaryTreeNode<T>> toVist = new List<BinaryTreeNode<T>>();

            toVist.Add(root);
            while (toVist.Any())
            {
                var current = toVist[0];

                if (current.RightChild != null)
                    toVist.Add(current.RightChild);

                if (current.LeftChild != null)
                    toVist.Add(current.LeftChild);

                toVist.RemoveAt(0);

                if (current.Level == n)
                    Console.WriteLine($"Ключ: {current.Key}, Высота {current.Level} ");
            }
        }

        public int FindLeaves()
        {
            List<BinaryTreeNode<T>> toVist = new List<BinaryTreeNode<T>>();

            int count = 0;

            toVist.Add(root);
            while (toVist.Any())
            {
                var current = toVist[0];

                if (current.RightChild != null)
                    toVist.Add(current.RightChild);

                if (current.LeftChild != null)
                    toVist.Add(current.LeftChild);

                if (current.LeftChild == null && current.RightChild == null)
                {
                    count++;
                }
                toVist.RemoveAt(0);
            }
            return count;
        }

        public void BreadthFirstSearch()
        {
            List<BinaryTreeNode<T>> toVist = new List<BinaryTreeNode<T>>();

            toVist.Add(root);
            while (toVist.Any())
            {
                var current = toVist[0];

                if (current.RightChild != null)
                    toVist.Add(current.RightChild);

                if (current.LeftChild != null)
                    toVist.Add(current.LeftChild);

                toVist.RemoveAt(0);
                Console.WriteLine($"Ключ: {current.Key}, Высота {current.Level}, Цвет {(Color)current.Level} ");
            }
        }
        public enum Color
        {
            Red,
            Orange,
            Yellow,
            Green,
            Blue,
            DarkBlue,
            Purple
        }
    }
}
