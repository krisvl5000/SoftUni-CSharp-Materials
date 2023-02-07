using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            int branchesCounter = 0;

            for (int row1 = 0; row1 < n; row1++)
            {
                string line = Console.ReadLine();
                for (int col1 = 0; col1 < n; col1++)
                {
                    matrix[row1, col1] = line[col1];

                    if (matrix[row1, col1] != '-' && 
                        matrix[row1, col1] != 'B' &&
                        matrix[row1, col1] != 'F')
                    {
                        branchesCounter++;
                    }
                }
            }

            (int row, int col) = FindBeaverLocation(matrix);

            string command = Console.ReadLine();
            while (command != "end")
            {
                if (command == "up")
                {
                    Move(matrix, row, col, row - 1, col);
                }
                else if (command == "down")
                {
                    Move(matrix, row, col, row + 1, col);
                }
                else if (command == "left")
                {
                    Move(matrix, row, col, row, col - 1);
                }
                else if (command == "right")
                {
                    Move(matrix, row, col, row, col + 1);
                }

                command = Console.ReadLine();
            }

            //for (int row = 0; row < n; row++)
            //{
            //    for (int col = 0; col < n; col++)
            //    {
            //        Console.Write(matrix[row, col]);
            //    }

            //    Console.WriteLine();
            //}

        }

        static void Move(char[,] matrix, int row, int col, int newRow, int newCol)
        {
            matrix[row, col] = '-';
            matrix[newRow, newCol] = 'B';
        }

        static (int row, int col) FindBeaverLocation(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        return (row, col);
                    }
                }
            }

            throw new Exception();
        }
    }
}