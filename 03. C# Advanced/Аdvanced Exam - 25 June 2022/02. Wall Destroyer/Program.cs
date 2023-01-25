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

            int holesCreated = 0;
            int rodsHit = 0;

            string input = Console.ReadLine();

            int[] startingLocation = FindV(matrix);

            int row = startingLocation[0];
            int col = startingLocation[1];

            int position = matrix[row, col];

            bool isElectrocuted = false;

            while (input != "End" && !isElectrocuted)
            {
                string command = input;

                switch (command)
                {
                    case "up":
                        if (IsIndexValid(matrix, row - 1, col))
                        {
                            if (matrix[row - 1, col] == 'R')
                            {
                                Console.WriteLine("Vanko hit a rod!");
                                rodsHit++;
                                continue;
                            }
                            else if (matrix[row - 1, col] == 'C')
                            {
                                holesCreated++;
                                matrix[row - 1, col] = 'E';
                                isElectrocuted = true;
                                break;
                            }
                            else if (matrix[row - 1, col] == '*')
                            {
                                Console.WriteLine($"The wall is already destroyed" +
                                    $"at position [{row - 1}, {col}]!");
                                row = row - 1;
                                continue;
                            }
                            else
                            {
                                holesCreated++;
                                matrix[row - 1, col] = '*';
                                row = row - 1;
                                continue;
                            }
                        }
                        break;
                    case "down":
                        if (IsIndexValid(matrix, row + 1, col))
                        {
                            if (matrix[row + 1, col] == 'R')
                            {
                                Console.WriteLine("Vanko hit a rod!");
                                rodsHit++;
                                continue;
                            }
                            else if (matrix[row + 1, col] == 'C')
                            {
                                holesCreated++;
                                matrix[row + 1, col] = 'E';
                                isElectrocuted = true;
                                break;
                            }
                            else if (matrix[row + 1, col] == '*')
                            {
                                Console.WriteLine($"The wall is already destroyed" +
                                    $"at position [{row - 1}, {col}]!");
                                row = row + 1;
                                continue;
                            }
                            else
                            {
                                holesCreated++;
                                matrix[row + 1, col] = '*';
                                row = row + 1;
                                continue;
                            }
                        }
                        break;
                    case "left":
                        if (IsIndexValid(matrix, row, col - 1))
                        {
                            if (matrix[row, col - 1] == 'R')
                            {
                                Console.WriteLine("Vanko hit a rod!");
                                rodsHit++;
                                continue;
                            }
                            else if (matrix[row, col - 1] == 'C')
                            {
                                holesCreated++;
                                matrix[row, col - 1] = 'E';
                                isElectrocuted = true;
                                break;
                            }
                            else if (matrix[row, col - 1] == '*')
                            {
                                Console.WriteLine($"The wall is already destroyed" +
                                    $"at position [{row}, {col - 1}]!");
                                col = col - 1;
                                continue;
                            }
                            else
                            {
                                holesCreated++;
                                matrix[row, col - 1] = '*';
                                col = col - 1;
                                continue;
                            }
                        }
                        break;
                    case "right":
                        if (IsIndexValid(matrix, row, col + 1))
                        {
                            if (matrix[row, col + 1] == 'R')
                            {
                                Console.WriteLine("Vanko hit a rod!");
                                rodsHit++;
                                continue;
                            }
                            else if (matrix[row, col + 1] == 'C')
                            {
                                holesCreated++;
                                matrix[row, col + 1] = 'E';
                                isElectrocuted = true;
                                break;
                            }
                            else if (matrix[row, col + 1] == '*')
                            {
                                Console.WriteLine($"The wall is already destroyed" +
                                    $"at position [{row}, {col + 1}]!");
                                col = col + 1;
                                continue;
                            }
                            else
                            {
                                holesCreated++;
                                matrix[row, col + 1] = '*';
                                col = col + 1;
                                continue;
                            }
                        }
                        break;
                }
            }

            if (!isElectrocuted)
            {
                Console.WriteLine($"Vanko managed to make {holesCreated} hole(s) " +
                    $"and he hit only {rodsHit} rod(s).");
            }
            else
            {
                Console.WriteLine($"Vanko got electrocuted, but he managed to make " +
                    $"{holesCreated} hole(s).");
            }

            //if (!isElectrocuted)
            {
                for (int r = 0; r < n; r++)
                {
                    for (int c = 0; c < n; c++)
                    {
                        if (r == row && c == col && !isElectrocuted)
                        {
                            Console.Write('V');
                        }
                        else
                        {
                            Console.Write(matrix[r, c]);
                        }

                        Console.WriteLine();
                    }
                }
            }

        }

        private static int[] FindV(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'V')
                    {
                        return new int[]{row, col};
                    }
                }
            }

            return new int[] { 0, 0 };
        }

        static char[,] GetMatrix(int n)
        {
            char[,] matrix = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                char[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            return matrix;
        }

        static bool IsIndexValid(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0)
                && col >= 0 && col < matrix.GetLength(1); 
        }
    }
}