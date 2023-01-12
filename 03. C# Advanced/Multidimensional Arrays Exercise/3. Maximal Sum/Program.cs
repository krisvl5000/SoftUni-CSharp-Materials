using System;
using System.Linq;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = input[0];
            int cols = input[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] arr = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = arr[col];
                }
            }

            int sum = int.MinValue;
            int startIndexRow = 0;
            int startIndexCol = 0;
            int endIndexRow = 0;
            int endIndexCol = 0;

            for (int row = 0; row < rows - 2; row++)
            {
                for (int col = 0; col < cols - 2; col++)
                {
                    if (matrix[row, col] +
                        matrix[row + 1, col] +
                        matrix[row + 2, col] +
                        matrix[row, col + 1] +
                        matrix[row, col + 2] +
                        matrix[row + 1, col + 1] +
                        matrix[row + 2, col + 1] +
                        matrix[row + 1, col + 2] +
                        matrix[row + 2, col + 2] > sum)
                    {
                        sum =
                        matrix[row, col] +
                        matrix[row + 1, col] +
                        matrix[row + 2, col] +
                        matrix[row, col + 1] +
                        matrix[row, col + 2] +
                        matrix[row + 1, col + 1] +
                        matrix[row + 2, col + 1] +
                        matrix[row + 1, col + 2] +
                        matrix[row + 2, col + 2];

                        startIndexRow = row;
                        startIndexCol = col;
                        endIndexRow = row + 2;
                        endIndexCol = col + 2;
                    }
                }
            }

            Console.WriteLine("Sum = " + sum);

            for (int row = startIndexRow; row <= endIndexRow; row++)
            {
                for (int col = startIndexCol; col <= endIndexCol; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}