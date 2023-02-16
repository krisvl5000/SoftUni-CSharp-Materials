using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = GetMatrix(n);

            (int row, int col) = GetBeaverLocation(matrix);

            int totalbranches = GetBranchesNumber(matrix);

        }

        private static int GetBranchesNumber(char[,] matrix)
        {
            int counter = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] != 'F' &&
                        matrix[row, col] != 'B' &&
                        )
                }
            }
        }

        private static (int row, int col) GetBeaverLocation(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        return (row, col);
                    }
                }
            }

            throw new ArgumentException();
        }

        static char[,] GetMatrix(int n)
        {
            char[,] matrix = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                char[] line = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = line[col];
                }
            }

            return matrix;
        }

        static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}