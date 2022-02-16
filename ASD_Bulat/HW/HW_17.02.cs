using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ASD
{
    public class HW1_17
    {
        public int[,] Array()
        {
            string[] lines = File.ReadAllLines("C:\\Users\\Bulat\\Desktop\\школа\\sample.txt");
            int[,] num = new int[lines.Length, lines[0].Split(' ').Length];
            for (int i = 0; i < lines.Length; i++)
            {
                string[] temp = lines[i].Split(' ');
                for (int j = 0; j < temp.Length; j++)
                {
                    num[i, j] = Int32.Parse(temp[j]);
                }
            }
            return num;
        }

        public int[] Deletezero(int l,int[] result)
        {
            int[] finalarray = new int[result.Length - l];
            int i1 = 0;
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] != 0)
                {
                    finalarray[i1] = result[i];
                    i1++;
                }
            }
            result = finalarray;
            return result;
        }

        public int[] ArraySort()
        {
            int[,] array = Array();
            var ar = new ArraySort();
            int[] result = new int[] {};
            int x = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                int[] elemets = new int[array.GetLength(1)];
                for (int j = 0; j < array.GetLength(1);j++)
                {
                    elemets[j] = array[x,j];
                }
                result = ar.JoinArray(result, elemets);
                x++;
            }
            int l = 0;
            for(int i = 0; i < result.Length;i++)
            {
                if (result[i] == 0)
                    l++;
            };
            if (l > 0)
                result = Deletezero(l, result);
            return result;
        }

    }
}