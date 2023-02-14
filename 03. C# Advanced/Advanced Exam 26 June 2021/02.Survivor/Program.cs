using System;
using System.Linq;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[][] matrix = GetMatrix(n);

            int ourTokens = 0;
            int opponentsTokens = 0;

            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = input[0];

                if (command == "Find")
                {
                    int row = int.Parse(input[1]);
                    int col = int.Parse(input[2]);

                    if (IsIndexValid(row, col, matrix))
                    {
                        if (matrix[row][col] == 'T')
                        {
                            ourTokens++;
                            matrix[row][col] = '-';
                        }
                    }
                }
                else if (command == "Opponent")
                {
                    int row = int.Parse(input[1]);
                    int col = int.Parse(input[2]);
                    string direction = input[3];

                    int counter = 0;

                    if (IsIndexValid(row, col, matrix))
                    {
                        if (matrix[row][col] == 'T')
                        {
                            opponentsTokens++;
                            matrix[row][col] = '-';
                        }
                    }
                    else
                    {
                        continue; // not quite sure, will confirm later
                    }

                    switch (direction)
                    {
                        case "up":

                            while (counter != 3)
                            {
                                row--;
                                if (!IsIndexValid(row, col, matrix))
                                {
                                    break;
                                }

                                if (matrix[row][col] == 'T')
                                {
                                    opponentsTokens++;
                                    matrix[row][col] = '-';
                                }

                                counter++;
                            }

                            break;
                        case "down":

                            while (counter != 3)
                            {
                                row++;
                                if (!IsIndexValid(row, col, matrix))
                                {
                                    break;
                                }

                                if (matrix[row][col] == 'T')
                                {
                                    opponentsTokens++;
                                    matrix[row][col] = '-';
                                }

                                counter++;
                            }

                            break;
                        case "left":

                            while (counter != 3)
                            {
                                col--;
                                if (!IsIndexValid(row, col, matrix))
                                {
                                    break;
                                }

                                if (matrix[row][col] == 'T')
                                {
                                    opponentsTokens++;
                                    matrix[row][col] = '-';
                                }

                                counter++;
                            }

                            break;
                        case "right":

                            while (counter != 3)
                            {
                                col++;
                                if (!IsIndexValid(row, col, matrix))
                                {
                                    break;
                                }

                                if (matrix[row][col] == 'T')
                                {
                                    opponentsTokens++;
                                    matrix[row][col] = '-';
                                }

                                counter++;
                            }

                            break;
                    }
                }
                else if (command == "Gong")
                {
                    break;
                }
            }

            PrintMatrix(matrix);

            Console.WriteLine($"Collected tokens: {ourTokens}");
            Console.WriteLine($"Opponent's tokens: {opponentsTokens}");
        }

        static char[][] GetMatrix(int n)
        {
            char[][] matrix = new char[n][];

            for (int row = 0; row < n; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split()
                    .Select(char.Parse)
                    .ToArray();
            }

            return matrix;
        }

        static void PrintMatrix(char[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                Console.WriteLine(String.Join(" ", matrix[row]));
            }
        }

        static bool IsIndexValid(int row, int col, char[][] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0)
                && col >= 0 && col < matrix[row].Length;
        }

        static bool IndexIsAToken(int row, int col, char[][] matrix)
        {
            return matrix[row][col] == 'T';
        }
    }
}