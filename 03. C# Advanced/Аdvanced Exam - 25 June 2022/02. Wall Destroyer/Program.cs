using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = GetMatrix(n);

            (int row, int col) = GetPosition(matrix);

            matrix[row, col] = '*';

            int holesmade = 1;
            int rodsHit = 0;
            bool isElectrocuted = false;

            while (true)
            {
                int oldRow = row;
                int oldCol = col;

                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                switch (input)
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

                if (!IsIndexValid(row, col, matrix))
                {
                    row = oldRow;
                    col = oldCol;
                    continue;
                }

                if (matrix[row, col] == '*')
                {
                    Console.WriteLine($"The wall is already destroyed at position " +
                        $"[{row}, {col}]!");
                }
                else if (matrix[row, col] == 'R')
                {
                    Console.WriteLine("Vanko hit a rod!");
                    rodsHit++;

                    row = oldRow;
                    col = oldCol;
                    continue;
                }
                else if (matrix[row, col] == 'C')
                {
                    holesmade++;

                    matrix[row, col] = 'E';
                    isElectrocuted = true;
                    break;
                }
                else
                {
                    matrix[row, col] = '*';
                    holesmade++;
                }    
            }

            if (!isElectrocuted)
            {
                Console.WriteLine($"Vanko managed to make {holesmade} hole(s) " +
                    $"and he only hit {rodsHit} rod(s).");
                matrix[row, col] = 'V';
            }
            else
            {
                Console.WriteLine($"Vanko got electrocuted, but he managed to make " +
                    $"{holesmade} hole(s).");
            }

            PrintMatrix(matrix);

        }

        private static (int row, int col) GetPosition(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'V')
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
                string line = Console.ReadLine();
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
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        static bool IsIndexValid(int row, int col, char[,] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0)
                && col >= 0 && col < matrix.GetLength(1);
        }
    }
}