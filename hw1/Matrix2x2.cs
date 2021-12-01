using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.hw1
{
    public class Matrix2x2
    {
        //комплексная матрица и матрица 2х2 по сути одно и тоже, я в одной сделал)) если поменять на int или double то получится обычная :)
        private ComplexNumber[,] arr = new ComplexNumber[2, 2];
        public Matrix2x2()
        {
            var b = new ComplexNumber();
            arr = new ComplexNumber[2, 2] { { b, b }, { b, b } };
        }
        public ComplexNumber this[int i, int j]
        {
            get
            {
                return arr[i, j];
            }
            set
            {
                arr[i, j] = value;
            }
        }
        public Matrix2x2(ComplexNumber a)
        {
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 2; j++)
                    arr[i, j] = a;
        }
        public Matrix2x2(ComplexNumber[][] a)
        {
            for (int i = 0; i < 2; i++)
                arr[0, i] = a[0][i];
            for (int i = 0; i < 2; i++)
                arr[1, i] = a[1][i];
        }
        public Matrix2x2(ComplexNumber a, ComplexNumber b, ComplexNumber c, ComplexNumber d)
        {
            arr[0, 0] = a;
            arr[0, 1] = b;
            arr[1, 0] = c;
            arr[1, 1] = d;
        }
        public Matrix2x2 Add(Matrix2x2 a)
        {
            Matrix2x2 z = new Matrix2x2();
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 2; j++)
                    z[i, j] = a.arr[i, j].Add(arr[i, j]);
            return z;
        }
        public Matrix2x2 Mult(Matrix2x2 a)
        {
            Matrix2x2 arr1 = new Matrix2x2();
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 2; j++)
                    for (int k = 0; k < 2; k++)
                        arr1[i, j] = arr1[i, j].Add(arr[i, k].Mult(a[k, j]));
            return arr1;
        }
        public ComplexNumber det()
        {
            return arr[0, 0].Mult(arr[1, 1]).Sub(arr[0, 1].Mult(arr[1, 0]));
        }
        public void transport()
        {
            ComplexNumber z;
            z = arr[0, 1];
            arr[0, 1] = arr[1, 0];
            arr[1, 0] = z;
        }
        public void Print()
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                    Console.Write(arr[i, j].TooString() + "\t");
                Console.WriteLine();
            }
        }
    }
}
