using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int armor = int.Parse(Console.ReadLine());

            int n = int.Parse(Console.ReadLine());

            char[][] matrix = CreateField(n);
            (int row, int col) = GetInitialPosition(matrix);
            matrix[row][col] = '-';

            bool battleIsWon = false;

            while (true)
            {
                int currentRow = row;
                int currentCol = col;

                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string direction = input[0];

                int spawnRow = int.Parse(input[1]);
                int spawnCol = int.Parse(input[2]);

                matrix[spawnRow][spawnCol] = 'O';

                switch (direction)
                {
                    case "up":
                        row--;
                        break;
                    case "down":
                        row++;
                        break;
                    case "left":
                        col--;
                        break;
                    case "right":
                        col++;
                        break;
                }

                armor--;

                if (IsPositionValid(row, col, n))
                {
                    if (matrix[row][col] == 'O')
                    {
                        armor -= 2;

                        if (armor <= 0)
                        {
                            matrix[row][col] = 'X';
                            break;
                        }
                        else
                        {
                            matrix[row][col] = '-';
                        }
                    }
                    else if (matrix[row][col] == 'M')
                    {
                        matrix[row][col] = '-';
                        battleIsWon = true;
                        break;
                    }
                }
                else
                {
                    row = currentRow;
                    col = currentCol;
                }
            }

            if (battleIsWon)
            {
                Console.WriteLine($"The army managed to free the Middle World! " +
                    $"Armor left: {armor}");
            }
            else
            {
                Console.WriteLine($"The army was defeated at {row};{col}.");
            }

            PrintMatrix(matrix);

        }

        static char[][] CreateField(int n)
        {
            char[][] matrix = new char[n][];

            for (int row = 0; row < n; row++)
            {
                char[] line = Console.ReadLine().ToCharArray();

                for (int col = 0; col < line.Length; col++)
                {
                    matrix[row][col] = line[col];
                }
            }

            return matrix;
        }

        static (int, int) GetInitialPosition(char[][] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row][col] == 'A')
                    {
                        return (row, col);
                    }
                }
            }

            throw new ArgumentException();
        }

        static bool IsPositionValid(int row, int col, int size)
        {
            return row >= 0 && row < size && col >= 0 && col < size;
        }

        static void PrintMatrix(char[][] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row][col]);
                }

                Console.WriteLine();
            }
        }
    }
}