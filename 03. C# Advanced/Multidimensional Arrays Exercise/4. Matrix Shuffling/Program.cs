using System;
using System.Linq;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = size[0];
            int cols = size[1];

            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] arr = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = arr[col];
                }
            }

            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (input[0] != "END")
            {
                string command = input[0];

                if (command != "swap" || input.Length != 5)
                {
                    Console.WriteLine("Invalid input!");

                    input = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    continue;
                }

                int row1 = int.Parse(input[1]);
                int col1 = int.Parse(input[2]);
                int row2 = int.Parse(input[3]);
                int col2 = int.Parse(input[4]);

                if (IsCommandValid(command, row1, col1, row2, col2, matrix))
                {
                    string temp = matrix[row1, col1];

                    matrix[row1, col1] = matrix[row2, col2];
                    matrix[row2, col2] = temp;

                    PrintMatrix(matrix);
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }

                input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

        }

        static bool IsCommandValid
            (string command, int row1, int col1, 
             int row2, int col2, string[,] matrix)
        {
            if (command == "swap" && row1 >= 0 && row1 < matrix.GetLength(0) &&
                col1 >= 0 && col1 < matrix.GetLength(1) &&
                row2 >= 0 && row2 < matrix.GetLength(0) &&
                col2 >= 0 && col2 < matrix.GetLength(1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void PrintMatrix(string[,] matrix)
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