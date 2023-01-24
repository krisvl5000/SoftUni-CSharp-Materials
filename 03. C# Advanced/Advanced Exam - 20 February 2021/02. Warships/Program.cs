using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            string[] commandsInput = Console.ReadLine()
                .Split(",", StringSplitOptions.RemoveEmptyEntries);

            Queue<string> commands = new Queue<string>(commandsInput);

            char[,] field = GetField(size);

            int player1Ships = GetShips(field, '<');
            int player2Ships = GetShips(field, '>');

            while (commands.Count > 0 && player1Ships > 0 && player2Ships > 0)
            {
                string command = commands.Dequeue();

                int rowIndex = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .First();

                int colIndex = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .Last();

                if (!IsIndexValid(field, rowIndex, colIndex))
                {
                    continue;
                }

                char symbol = field[rowIndex, colIndex];

                switch (symbol)
                {
                    case '<':
                        player1Ships--;
                        field[rowIndex, colIndex] = 'X';
                        break;
                    case '>':
                        player2Ships--;
                        field[rowIndex, colIndex] = 'X';
                        break;
                    case '#':
                        for (int row = rowIndex - 1; row <= rowIndex + 1; row++)
                        {
                            for (int col = colIndex - 1; col <= colIndex + 1; col++)
                            {
                                if (!IsIndexValid(field, row, col))
                                {
                                    continue;
                                }

                                if (field[row, col] == '<')
                                {
                                    player1Ships--;
                                    field[row, col] = 'X';
                                }
                                else if (field[row, col] == '>')
                                {
                                    player2Ships--;
                                    field[row, col] = 'X';
                                }
                            }
                        }
                        break;
                }
            }

            PrintResult(player1Ships, player2Ships, GetShips(field, 'X'));

        }

        private static void PrintResult(int player1Ships, int player2Ships, int destroyedShips)
        {
            if (player1Ships > 0 && player2Ships == 0)
            {
                Console.WriteLine($"Player One has won the game! {destroyedShips} " +
                    $"ships have been sunk in the battle.");
            }
            else if (player2Ships > 0 && player1Ships == 0)
            {
                Console.WriteLine($"Player Two has won the game! {destroyedShips} " +
                    $"ships have been sunk in the battle.");
            }
            else
            {
                Console.WriteLine($"It's a draw! Player One has {player1Ships} ships left. " +
                    $"Player Two has {player2Ships} ships left.");
            }
        }

        private static bool IsIndexValid(char[,] field, int rowIndex, int colIndex)
        {
            return rowIndex >= 0 && rowIndex < field.GetLength(0)
                && colIndex >= 0 && colIndex < field.GetLength(1);
        }

        private static int GetShips(char[,] field, char ch)
        {
            int counter = 0;

            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    if (field[row, col] == ch)
                    {
                        counter++;
                    }
                }
            }

            return counter;
        }

        private static char[,] GetField(int size)
        {
            char[,] field = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                char[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < size; col++)
                {
                    field[row, col] = input[col];
                }
            }

            return field;
        }
    }
}