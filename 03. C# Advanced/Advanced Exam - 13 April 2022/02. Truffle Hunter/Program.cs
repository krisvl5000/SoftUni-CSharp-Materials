using System;

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

                            break;
                        case "down":

                            break;
                        case "left":

                            break;
                        case "right":

                            break;
                    }
                }
                else if (command == "Stop")
                {
                    break;
                }

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