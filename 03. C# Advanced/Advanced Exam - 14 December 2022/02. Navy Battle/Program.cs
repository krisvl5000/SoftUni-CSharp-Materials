using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] matrix = GetMatrixData();

            (int row, int col) = GetPosition(matrix);

            int mines = 0;
            int shipsDestroyed = 0;

            matrix[row, col] = '-'; // might need to change later

            while (true)
            {
                string command = Console.ReadLine();

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

                if (matrix[row, col] == '*')
                {
                    matrix[row, col] = '-';
                    mines++;

                    if (mines == 3)
                    {
                        Console.WriteLine($"Mission failed, U-9 disappeared! " +
                            $"Last known cordinates [{row}, {col}]!");
                        break;
                    }
                }
                else if (matrix[row, col] == 'C')
                {
                    matrix[row, col] = '-';
                    shipsDestroyed++;

                    if (shipsDestroyed == 3)
                    {
                        Console.WriteLine("Mission accomplished, U-9 has destroyed " +
                            $"all battle cruisers of the enemy!");
                        break;
                    }
                }
            }

            PrintLastPosition(matrix, row, col);

        }

        static void PrintLastPosition(char[,] matrix, int lastRow, int lastCol)
        {
            matrix[lastRow, lastCol] = 'S';

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        static char[,] GetMatrixData()
        {
            int n = int.Parse(Console.ReadLine());

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

        static (int, int) GetPosition(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'S')
                    {
                        return (row, col);
                    }
                }
            }

            throw new ArgumentException();
        }
    }
}