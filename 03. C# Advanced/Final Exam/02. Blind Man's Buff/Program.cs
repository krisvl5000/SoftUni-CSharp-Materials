using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensionArgs = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int n = dimensionArgs[0];
            int m = dimensionArgs[1];

            char[][] matrix = GetMatrix(n);

            (int row, int col) = GetPosition(matrix);

            int peopleTouched = 0;
            int movesMade = 0;

            matrix[row][col] = '-';

            while (true)
            {
                int oldRow = row;
                int oldCol = col;

                string command = Console.ReadLine();

                if (command == "Finish")
                {
                    break;
                }

                switch (command)
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

                if (!IsIndexValid(row, col, n, m))
                {
                    row = oldRow;
                    col = oldCol;
                    continue;
                }

                char symbol = matrix[row][col];

                if (matrix[row][col] == 'P')
                {
                    peopleTouched++;
                    matrix[row][col] = '-';
                    movesMade++;

                    if (peopleTouched == 3)
                    {
                        break;
                    }
                }
                else if (matrix[row][col] == 'O')
                {
                    row = oldRow;
                    col = oldCol;
                }
                else if (matrix[row][col] == '-')
                {
                    movesMade++;
                }
            }

            Console.WriteLine("Game over!");
            Console.WriteLine($"Touched opponents: {peopleTouched} " +
                $"Moves made: {movesMade}");

        }

        static (int row, int col) GetPosition(char[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'B')
                    {
                        return (row, col);
                    }
                }
            }

            throw new ArgumentException();
        }

        static char[][] GetMatrix(int n)
        {
            char[][] matrix = new char[n][];

            for (int row = 0; row < n; row++)
            {
                char[] line = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                matrix[row] = line;
            }

            return matrix;
        }

        static bool IsIndexValid(int row, int col, int n, int m)
        {
            return row >= 0 && row < n && col >= 0 && col < m;
        }
    }
}