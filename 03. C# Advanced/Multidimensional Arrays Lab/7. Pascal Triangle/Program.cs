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
                matrix[row][0] = 1;

                for (int col = 1; col < row; col++)
                {
                    matrix[row][col] = matrix[row - 1][col - 1] + matrix[row - 1][col];
                }

                matrix[row][row] = 1;
            }

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}