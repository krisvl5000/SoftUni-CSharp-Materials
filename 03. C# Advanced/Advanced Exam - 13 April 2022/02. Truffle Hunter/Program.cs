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

            int row = 0;
            int col = 0;

            int whiteCounter = 0;
            int blackCounter = 0;
            int summerCounter = 0;

            int trufflesEatenByTheBoar = 0;

            HashSet<char> truffleTypes = new HashSet<char>()
            {
                'S', 'W', 'B'
            };

            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = input[0];

                if (command == "Collect")
                {
                    row = int.Parse(input[1]);
                    col = int.Parse(input[2]);

                    char type = matrix[row, col];

                    switch (type)
                    {
                        case 'S':
                            summerCounter++;
                            break;
                        case 'W':
                            whiteCounter++;
                            break;
                        case 'B':
                            blackCounter++;
                            break;
                    }

                    matrix[row, col] = '-';
                }
                else if (command == "Wild_Boar")
                {
                    row = int.Parse(input[1]);
                    col = int.Parse(input[2]);
                    string direction = input[3];

                    switch (direction)
                    {
                        case "up":
                            for (int row1 = n - 1; row1 >= 0; row1-=2)
                            {
                                if (IsInIndex(row1, col, n))
                                {
                                    if (truffleTypes.Contains(matrix[row1, col]))
                                    {
                                        trufflesEatenByTheBoar++;
                                        matrix[row1, col] = '-';
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            }
                            break;
                        case "down":
                            for (int row1 = n - 1; row1 >= 0; row1 += 2)
                            {
                                if (IsInIndex(row1, col, n))
                                {
                                    if (truffleTypes.Contains(matrix[row1, col]))
                                    {
                                        trufflesEatenByTheBoar++;
                                        matrix[row1, col] = '-';
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            }
                            break;
                        case "left":
                            for (int col1 = n - 1; col1 >= 0; col1 -= 2)
                            {
                                if (IsInIndex(row, col1, n))
                                {
                                    if (truffleTypes.Contains(matrix[row, col1]))
                                    {
                                        trufflesEatenByTheBoar++;
                                        matrix[row, col1] = '-';
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            }
                            break;
                        case "right":
                            for (int col1 = n - 1; col1 >= 0; col1 += 2)
                            {
                                if (IsInIndex(row, col1, n))
                                {
                                    if (truffleTypes.Contains(matrix[row, col1]))
                                    {
                                        trufflesEatenByTheBoar++;
                                        matrix[row, col1] = '-';
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            }
                            break;
                    }
                }
                else if (command == "Stop")
                {
                    break;
                }
            }

            Console.WriteLine($"Peter manages to harvest {blackCounter} black, " +
                $"{summerCounter} summer, and {whiteCounter} white truffles.");

            Console.WriteLine($"The wild boar has eaten {trufflesEatenByTheBoar} " +
                $"truffles.");

            PrintMatrix(matrix);

        }

        static bool IsInIndex(int row, int col, int n)
        {
            return row >= 0 && row < n && col >= 0 && col < n;
        }

        private static void PrintMatrix(char[,] matrix)
        {
            List<char> list = new List<char>();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                list = new List<char>();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    list.Add(matrix[row, col]);
                }

                Console.WriteLine(String.Join(" ", list));
            }
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
    }
}