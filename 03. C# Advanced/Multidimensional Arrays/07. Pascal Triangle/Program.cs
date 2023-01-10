using System;
using System.Linq;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            long[][] matrix = new long[size][];
            matrix[0] = new long[1] { 1 };

            for (int row = 1; row < size; row++)
            {
                matrix[row] = new long[row + 1];
                matrix[row][0] = 1; // first el in the arr

                for (int col = 1; col < row; col++)
                {
                    matrix[row][col] = matrix[row - 1][col - 1] + matrix[row - 1][col];
                }

                matrix[row][row] = 1; // last el in the arr
            }

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col] + " ");
                }

                Console.WriteLine();
            }

            //int rows = int.Parse(Console.ReadLine()), val = 1, i, j;

            //for (i = 0; i < rows; i++)
            //{
            //    for (j = 0; j <= i; j++)
            //    {
            //        if (j == 0 || i == 0)
            //            val = 1;
            //        else
            //            val = val * (i - j + 1) / j;
            //        Console.Write(val + " ");
            //    }
            //    Console.WriteLine();
            //}

        }
    }
}