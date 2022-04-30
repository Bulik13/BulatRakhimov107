using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infa2Semestr.HW.HW_Tree
{
    public class BinarySearchTree<T>
    {
        private BinaryTreeNode<T> root;
        public void Add(int key, T value)
        {
            if (root == null)
                root = new BinaryTreeNode<T>(value, key);
            else
            {
                var rootCopy = root;
                bool isFind = false;
                while (isFind == false)
                {
                    if (key == rootCopy.Key)
                    {
                        rootCopy.Value = value;
                        isFind = true;
                    }
                    else if (key < rootCopy.Key)
                    {
                        if (rootCopy.Left == null)
                        {
                            rootCopy.Left = new BinaryTreeNode<T>(value, key, rootCopy);
                            isFind = true;
                        }
                        else rootCopy = rootCopy.Left;
                    }
                    else
                    {
                        if (rootCopy.Right == null)
                        {
                            rootCopy.Right = new BinaryTreeNode<T>(value, key, rootCopy);
                            isFind = true;
                        }
                        else rootCopy = rootCopy.Right;
                    }

                }
            }
        }
        public void BreadthFirstSearch()
        {
            List<BinaryTreeNode<T>> toVisit = new List<BinaryTreeNode<T>>();
            toVisit.Add(root);
            while (toVisit.Any())
            {
                var current = toVisit[0];
                if (current.Right != null) toVisit.Add(current.Right);
                if (current.Left != null) toVisit.Add(current.Left);
                toVisit.RemoveAt(0);
                Console.WriteLine($"Ключ: {current.Key}");
            }
        }

        public void InfixTraverse()
        {
            InfixTraverse();
        }

        public void PrefixSum(BinaryTreeNode<int> tree, ref int sum)
        {
            if (tree == null)
                return;
            //sum += root.Value;
            else
            {
                if (tree.Left != null) PrefixSum(tree.Left, ref sum);
                if (tree.Right != null) PrefixSum(tree.Right, ref sum);
            }

        }
        /// <summary>
        /// Удаление элемента
        /// </summary>
        /// <param name="value">удаляемое значение</param>
        public void Remove(int key)
        {
            if (root == null)
            {
                Console.WriteLine("Дерево пусто");
                return;
            }
            Remove(key, root);
        }

        private void Remove(int key, BinaryTreeNode<T> root)
        {
            if (root == null)
            {
                Console.WriteLine($"Элемент {key} в дереве отсутствует");
                return;
            }
            //Проверяем, надо ли искать в левом поддереве
            if (root.Key > key)
            {
                if (root.Left == null)
                {
                    Console.WriteLine($"Элемент {key} в дереве отсутствует");
                    return;
                }
                else
                    Remove(key, root.Left);
            }
            else if (root.Key < key)
            {
                if (root.Right == null)
                {
                    Console.WriteLine($"Элемент {key} в дереве отсутствует");
                    return;
                }
                else
                    Remove(key, root.Right);
            }
            else //root.Key == key - нашли узел, которы надо удалить
            {
                bool? isLeft = root.Parent != null
                    ? root.Parent.Key > root.Key
                    : (bool?)null; //нет родительского элемента - не может быть левыйм или правым
                //Если обоих детей нет, то удаляем текущий узел и 
                //обнуляем ссылку на него у родительского узла
                if (root.Left == null && root.Right == null)
                {
                    if (root.Parent != null) //isLeft.HasValue
                    {
                        if (isLeft.Value)
                            root.Parent.Left = null;
                        else
                            root.Parent.Right = null;
                    }
                    else
                        this.root = null;
                }
                //Если одного из детей нет, то значения полей 
                //ребёнка m ставим вместо соответствующих значений 
                //корневого узла, затирая его старые значения, 
                //и освобождаем память, занимаемую узлом m;
                else if (root.Left != null && root.Right == null)
                {
                    //левый потомок есть, правого нет
                    if (isLeft.HasValue) //имеется родительский элемент
                    {
                        if (isLeft.Value)
                            root.Parent.Left = root.Left;
                        else
                            root.Parent.Right = root.Left;
                    }
                    else
                        this.root = root.Left;
                }
                else if (root.Left == null && root.Right != null)
                {
                    //правый потомок есть, левого нет
                    if (isLeft.HasValue)
                    {
                        if (isLeft.Value)
                            root.Parent.Left = root.Right;
                        else
                            root.Parent.Right = root.Right;
                    }
                    else
                        this.root = root.Right;
                }
                //оба потомка имеются
                else
                {
                    //Если левый узел m правого 
                    //поддерева отсутствует(n->right->left)
                    if (root.Right.Left == null)
                    {
                        //Копируем из правого узла в удаляемый поля K, V 
                        //и ссылку на правый узел правого потомка.
                        root.Key = root.Right.Key;
                        root.Value = root.Right.Value;
                        root.Right = root.Right.Right;
                        if (root.Right != null)
                            root.Right.Parent = root;
                    }
                    else
                    {
                        //Возьмём самый левый узел m, правого поддерева n->right;
                        var mostLeft = root.Right;
                        while (mostLeft.Left != null)
                            mostLeft = mostLeft.Left;
                        //Скопируем данные (кроме ссылок на дочерние элементы) из m в n
                        root.Key = mostLeft.Key;
                        root.Value = mostLeft.Value;
                        //удалим узел m.
                        mostLeft.Parent.Left = null;
                    }
                }
            }
        }
        public bool IsKeyExists(int key)
        {
            return IsKeyExists(key, root);
        }
        private bool IsKeyExists(int key, BinaryTreeNode<T> root)
        {
            if (root == null)
                return false;
            if (root.Key == key)
                return true;
            else if (root.Key > key && root.Left != null)
            {
                return IsKeyExists(key, root.Left);
            }
            else if (root.Key < key && root.Right != null)
            {
                return IsKeyExists(key, root.Right);
            }
            else
                return false;
        }
        /// <summary>
        /// проверяет, является ли p позицией листа дерева.
        /// </summary>
        public bool IsExternal(int p)
        {
            if (p < 1)
            {
                Console.WriteLine("Введите корректную позицию. Позиция начинается с 1.");
                return false;
            }
            if (root == null)
                return false;
            List<int> steps = new List<int>();
            while (p != 1)
            {
                steps.Add(p);
                p /= 2;
            }
            steps.Reverse();
            var node = root;
            foreach (int step in steps)
            {
                if (step % 2 == 0)
                    node = node.Left;
                else
                    node = node.Right;
                if (node == null)
                {
                    Console.WriteLine("В дереве не существует элемента на данной позиции");
                    return false;
                }
            }
            if (node.Left != null || node.Right != null)
            {
                Console.WriteLine($"Узел с ключом {node.Key} не является листом дерева");
                return false;
            }
            Console.WriteLine($"Узел с ключом {node.Key} является листом дерева");
            return true;
        }
    }
}
