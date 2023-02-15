using System;
using System.Linq;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[] input = Console.ReadLine().Split(",");

            char[,] matrix = GetMatrix(n);

            int playerOneShips = GetShipsCount('<', matrix);
            int playerTwoShips = GetShipsCount('>', matrix);

            int totalShipsSunk = 0;

            int row = 0;
            int col = 0;

            for (int i = 0; i < input.Length; i++)
            {
                string command = input[i];

                //int[] coordinates = command.Split(" ")
                //    .Select(int.Parse)
                //    .ToArray();

                row = command.Split(" ").Select(int.Parse).First();
                col = command.Split(" ").Select(int.Parse).Last();

                if (!IsIndexValid(row, col, matrix))
                {
                    continue;
                }

                char symbol = matrix[row, col];

                switch (symbol)
                {
                    case '<':
                        matrix[row, col] = 'X';
                        playerOneShips--;
                        totalShipsSunk++;
                        break;
                    case '>':
                        matrix[row, col] = 'X';
                        playerTwoShips--;
                        totalShipsSunk++;
                        break;
                    case '#':
                        if (IsIndexValid(row++, col, matrix))
                        {
                            if (matrix[row, col] == '<')
                            {
                                matrix[row, col] = 'X';
                                playerOneShips--;
                                totalShipsSunk++;
                            }
                            else if (matrix[row, col] == '>')
                            {
                                matrix[row, col] = 'X';
                                playerTwoShips--;
                                totalShipsSunk++;
                            }
                        }
                        if (IsIndexValid(row, col++, matrix))
                        {
                            if (matrix[row, col] == '<')
                            {
                                matrix[row, col] = 'X';
                                playerOneShips--;
                                totalShipsSunk++;
                            }
                            else if (matrix[row, col] == '>')
                            {
                                matrix[row, col] = 'X';
                                playerTwoShips--;
                                totalShipsSunk++;
                            }
                        }
                        if (IsIndexValid(row--, col, matrix))
                        {
                            if (matrix[row, col] == '<')
                            {
                                matrix[row, col] = 'X';
                                playerOneShips--;
                                totalShipsSunk++;
                            }
                            else if (matrix[row, col] == '>')
                            {
                                matrix[row, col] = 'X';
                                playerTwoShips--;
                                totalShipsSunk++;
                            }
                        }
                        if (IsIndexValid(row, col--, matrix))
                        {
                            if (matrix[row, col] == '<')
                            {
                                matrix[row, col] = 'X';
                                playerOneShips--;
                                totalShipsSunk++;
                            }
                            else if (matrix[row, col] == '>')
                            {
                                matrix[row, col] = 'X';
                                playerTwoShips--;
                                totalShipsSunk++;
                            }
                        }
                        break;
                }

                if (playerOneShips <= 0 || playerTwoShips <= 0)
                {
                    break;
                }
            }

            if (playerTwoShips <= 0)
            {
                Console.WriteLine($"Player One has won the game! " +
                    $"{totalShipsSunk} ships have been sunk in the battle.");
            }
            else if (playerOneShips <= 0)
            {
                Console.WriteLine($"Player Two has won the game! " +
                    $"{totalShipsSunk} ships have been sunk in the battle.");
            }
            else
            {
                Console.WriteLine($"It's a draw! Player one has {playerOneShips} " +
                    $"ships left. Player Two has {playerTwoShips} ships left.");
            }


        }

        static int GetShipsCount(char v, char[,] matrix)
        {
            int counter = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == v)
                    {
                        counter++;
                    }
                }
            }

            return counter;
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

        static bool IsIndexValid(int row, int col, char[,] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0)
                && col >= 0 && col < matrix.GetLength(1);
        }
    }
}