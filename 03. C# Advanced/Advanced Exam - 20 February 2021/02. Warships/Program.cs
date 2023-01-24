using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            string[] commandArgs = Console.ReadLine()
                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Queue<string> commands = new Queue<string>(commandArgs);

            char[,] field = GetField(size);

            int player1Ships = GetShipsCount(field, '<');
            int player2Ships = GetShipsCount(field, '>');

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

                if (!IsIndexValid(size, rowIndex, colIndex))
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
                                if (!IsIndexValid(size, row, col))
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

            PrintResult(player1Ships, player2Ships, GetShipsCount(field, 'X'));

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
                Console.WriteLine($"It's a draw! Player One has {player1Ships} " +
                    $"ships left. Player Two has {player2Ships} ships left.");
            }
        }

        private static bool IsIndexValid(int size, int row, int col)
        {
            return row >= 0 && row < size && col >= 0 && col < size;
        }

        private static int GetShipsCount(char[,] field, char ch)
        {
            int count = 0;

            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    if (field[row, col] == ch)
                    {
                        count++;
                    }
                }
            }

            return count;
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