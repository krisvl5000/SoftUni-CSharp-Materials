using System;
using System.Linq;
using System.Collections.Generic;

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

            char[,] matrix = new char[rows, cols];

            char[] snakeChars = Console.ReadLine().ToCharArray();

            Queue<char> snake = new Queue<char>(snakeChars);

            for (int row = 0; row < rows; row++)
            {
                FillInCurrentRow(matrix, snake, row);
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }

        }

        static void FillInCurrentRow(char[,] matrix, Queue<char> snake, int row)
        {
            for (int ch = 0; ch < matrix.GetLength(1); ch++)
            {
                char currentSymbol = snake.Dequeue();

                if (row % 2 == 0)
                {
                    matrix[row, ch] = currentSymbol;
                }
                else
                {
                    matrix[row, matrix.GetLength(1) - ch - 1] = currentSymbol;
                }

                snake.Enqueue(currentSymbol);
            }
        }
    }
}