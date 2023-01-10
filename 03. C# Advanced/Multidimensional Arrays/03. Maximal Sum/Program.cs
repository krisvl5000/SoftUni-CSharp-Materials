using System;
using System.Linq;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().
                Split(" ", StringSplitOptions.RemoveEmptyEntries).
                Select(int.Parse)
                .ToArray();

            int rows = size[0];
            int cols = size[1];
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



        }
    }
}