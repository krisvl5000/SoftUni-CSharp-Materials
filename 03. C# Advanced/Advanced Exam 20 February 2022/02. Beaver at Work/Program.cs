using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = GetMatrix(n);

            (int row, int col) = GetBeaverLocation(matrix);

            matrix[row, col] = '-';

            int totalbranches = GetBranchesNumber(matrix);

            Stack<char> branchesCollected = new Stack<char>();

            bool noBranchesLeft = false;

            while (true)
            {
                int oldRow = row;
                int oldCol = col;

                string input = Console.ReadLine();

                string direction = input;

                if (input == "end")
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

                    if (branchesCollected.Any())
                    {
                        branchesCollected.Pop();
                    }

                    continue;
                }

                if (IsBranch(row, col, matrix))
                {
                    branchesCollected.Push(matrix[row, col]);
                    matrix[row, col] = '-';
                    totalbranches--;
                }
                else if (matrix[row, col] == 'F')
                {
                    matrix[row, col] = '-';

                    if (row != 0 && col != 0 && row != n - 1 && col != n - 1)
                    {

                    }
                    else
                    {
                        switch (direction)
                        {
                            case "up":
                                direction = "down";
                                break;
                            case "down":
                                direction = "up";
                                break;
                            case "left":
                                direction = "right"; 
                                break;
                            case "right":
                                direction = "left";
                                break;
                        }
                    }

                    switch (direction)
                    {
                        case "up":
                            row = 0;
                            break;
                        case "down":
                            row = n - 1;
                            break;
                        case "left":
                            col = 0;
                            break;
                        case "right":
                            col = n - 1;
                            break;
                    }

                    if (IsBranch(row, col, matrix))
                    {
                        branchesCollected.Push(matrix[row, col]);
                        matrix[row, col] = '-';
                        totalbranches--;
                    }
                }

                if (totalbranches == 0)
                {
                    noBranchesLeft = true;
                    break;
                }
            }

            if (noBranchesLeft)
            {
                Console.WriteLine($"The Beaver successfully collect " +
                    $"{branchesCollected.Count} wood branches: " +
                    $"{String.Join(", ", branchesCollected.Reverse())}.");
            }
            else
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. " +
                    $"There are {totalbranches} branches left.");
            }

            matrix[row, col] = 'B';

            PrintMatrix(matrix);

        }

        static bool IsBranch(int row, int col, char[,] matrix)
        {
            if (matrix[row, col] != 'F' &&
                       matrix[row, col] != 'B' &&
                       matrix[row, col] != '-')
            {
                return true;
            }

            return false;
        }

        static int GetBranchesNumber(char[,] matrix)
        {
            int counter = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] != 'F' &&
                        matrix[row, col] != 'B' &&
                        matrix[row, col] != '-')
                    {
                        counter++;
                    }
                }
            }

            return counter;
        }

        static (int row, int col) GetBeaverLocation(char[,] matrix)
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

            throw new ArgumentException();
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
                    Console.Write(matrix[row, col] + " ");
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