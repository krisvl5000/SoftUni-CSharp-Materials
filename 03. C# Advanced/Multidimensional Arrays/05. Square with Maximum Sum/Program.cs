using System;
using System.Linq;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int biggestSquareRows = 2;
            int biggestSquareCols = 2;

            int[] size = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] arr = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = arr[col];
                }
            }

            int maxSum = int.MinValue;
            int maxRowIndex = 0;
            int maxColIndex = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (row + biggestSquareRows - 1 < rows &&
                        col + biggestSquareCols - 1 < cols)
                    {
                        int sum = 
                            matrix[row, col] +
                            matrix[row + 1, col] +
                            matrix[row, col + 1] +
                            matrix[row + 1, col + 1];

                        if (sum > maxSum)
                        {
                            maxSum = sum;
                            maxColIndex = col;
                            maxRowIndex = row;
                        }
                    }
                }
            }

            for (int row = maxRowIndex; row < maxRowIndex + biggestSquareRows; row++)
            {
                for (int col = maxColIndex; col < maxColIndex + biggestSquareCols; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }

                Console.WriteLine();
            }

            Console.WriteLine(maxSum);
        }
    }
}