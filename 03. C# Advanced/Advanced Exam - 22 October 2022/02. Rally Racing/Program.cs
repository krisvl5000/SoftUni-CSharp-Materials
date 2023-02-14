using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string racingNumber = Console.ReadLine();

            char[,] matrix = GetMatrix(n);

            int row = 0;
            int col = 0;

            int kmPassed = 0;

            bool carFinished = false;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                kmPassed += 10;

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

                if (matrix[row, col] == 'T')
                {
                    matrix[row, col] = '.';
                    kmPassed += 20;

                    (row, col) = GetTLocation(matrix);
                    matrix[row, col] = '.';
                }
                else if (matrix[row, col] == 'F')
                {
                    carFinished = true;
                    break;
                }
            }

            if (carFinished)
            {
                Console.WriteLine($"Racing car {racingNumber} finished the stage!");
            }
            else
            {
                Console.WriteLine($"Racing car {racingNumber} DNF.");
            }

            Console.WriteLine($"Distance covered {kmPassed} km.");
            matrix[row, col] = 'C';
            PrintMatrix(matrix);
        }

        static char[,] GetMatrix(int n)
        {
            char[,] matrix = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                char[] line = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

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

        static (int row, int col) GetTLocation(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'T')
                    {
                        return (row, col);
                    }
                }
            }

            throw new ArgumentException();
        }
    }
}