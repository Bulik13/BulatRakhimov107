using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infa2Semestr.SecondKR.Tree
{
    public static class TreeRunner
    {
        public static void Run()
        {
            BinarySearchTree<string> binSTree = new BinarySearchTree<string>();
            binSTree.Add("A", 10);
            binSTree.Add("B", 9);
            binSTree.Add("C", 8);
            binSTree.Add("D", 3);
            binSTree.Add("E", 13);
            binSTree.Add("F", 11);
            binSTree.Add("G", 74);
            binSTree.Add("X", 69);
            binSTree.Add("Y", 70);
            binSTree.Add("Z", 68);
            binSTree.Add("N", 75);


            binSTree.BreadthFirstSearch();
            int leaves = binSTree.FindLeaves();
            Console.WriteLine("==========================");
            binSTree.PrintNodesWithLengthN(3);
            Console.WriteLine("==========================");

            BinarySearchTree<string> binSTree2 = new BinarySearchTree<string>();
            binSTree2.Add("A", 10);
            binSTree2.Add("B", 9);
            binSTree2.Add("C", 8);
            int leaves2 = binSTree2.FindLeaves();
            binSTree2.PrintNodesWithLengthN(1);

        }
    }
}
