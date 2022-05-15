using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASD_Bulat
{
    public class FenwickTree
    {
        /// <summary>
        /// максимальный размер дерева
        /// </summary>
        readonly static int MAX = 1000;

        private static int[] BITree = new int[MAX];

        public int GetSum(int index)
        {
            int sum = 0;
            index = index + 1;
            while (index > 0)
            {
                sum += BITree[index];
                index -= index & (-index);
            }

            return sum;
        }

        public void Update(int n, int index, int value)
        {
            index = index + 1;
            while (index <= n)
            {
                BITree[index] += value;
                index += index & (-index);
            }
        }

        public void ConstructBITree(int[] arr, int n)
        {
            for (int i = 0; i <= n; i++)
            {
                BITree[i] = 0;
            }

            for (int i = 0; i < n; i++)
            {
                Update(n, i, arr[i]);
            }
        }
        public int[] Add(int[] arr, int index, int value)
        {
            int n = arr.Length;
            var newArr = new int[n + 1];

            for (int i = 0; i < n + 1; i++)
            {
                if (i < index - 1)
                    newArr[i] = arr[i];
                else if (i == index - 1)
                    newArr[i] = value;
                else
                    newArr[i] = arr[i - 1];
            }
            return newArr;
        }

        public int[] Delete(int[] arr, int index)
        {
            int n = arr.Length;
            var newArr = new int[n - 1];

            newArr = arr.Where((source, x) => x != index).ToArray();
            return newArr;
        }

        public int[] ReverseArray(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n / 2; i++)
                (arr[i], arr[n - (i + 1)]) = (arr[n - (i + 1)], arr[i]);
            return arr;
        }

        public void WriteOnConsole(int[] arr)
        {
            foreach (var x in arr)
            {
                Console.Write(x + " ");
            }
        }
    }
}
