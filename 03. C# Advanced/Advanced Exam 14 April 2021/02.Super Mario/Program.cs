using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lives = int.Parse(Console.ReadLine());

            int n = int.Parse(Console.ReadLine());

            char[][] matrix = GetMatrix(n);

            (int row, int col) = GetInitialPosition(matrix);

            bool marioDied = false;

            matrix[row][col] = '-';

            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string direction = input[0];
                int spawnRow = int.Parse(input[1]);
                int spawnCol = int.Parse(input[2]);

                matrix[spawnRow][spawnCol] = 'B';

                int oldRow = row;
                int oldCol = col;

                lives--;

                switch (direction)
                {
                    case "W":
                        row--;
                        break;
                    case "A":
                        col--;
                        break;
                    case "S":
                        row++;
                        break;
                    case "D":
                        col++;
                        break;
                }

                if (IsIndexValid(row, col, matrix))
                {
                    if (matrix[row][col] == 'B')
                    {
                        lives -= 2;

                        if (lives <= 0)
                        {
                            matrix[row][col] = 'X';
                            marioDied = true;
                            break;
                        }

                        matrix[row][col] = '-';
                    }
                    else if (matrix[row][col] == 'P')
                    {
                        matrix[row][col] = '-';
                        break;
                    }
                }
                else
                {
                    row = oldRow;
                    col = oldCol;
                }
            }

            if (marioDied)
            {
                Console.WriteLine($"Mario died at {row};{col}.");
            }
            else
            {
                Console.WriteLine($"Mario has successfully saved the princess! " +
                    $"Lives left: {lives}");
            }

            PrintMatrix(matrix);
        }

        static (int row, int col) GetInitialPosition(char[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'M')
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
                matrix[row] = Console.ReadLine().ToCharArray();
            }

            return matrix;
        }

        static bool IsIndexValid(int row, int col, char[][] matrix)
        {
            return row >= 0 && row < matrix.Length
                && col >= 0 && col < matrix[row].Length;
        }

        static void PrintMatrix(char[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col]);
                }

                Console.WriteLine();
            }
        }
    }
}