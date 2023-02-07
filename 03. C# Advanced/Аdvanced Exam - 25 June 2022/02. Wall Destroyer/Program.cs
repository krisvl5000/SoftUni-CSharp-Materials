using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            int currentRow = 0;
            int currentCol = 0;

            for (int row = 0; row < n; row++)
            {
                string line = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = line[col];

                    if (line[col] == 'V')
                    {
                        currentRow = row;
                        currentCol = col;
                    }
                }
            }

            string input = Console.ReadLine().ToLower();

            matrix[currentRow, currentCol] = '*';

            int holes = 1;
            int rods = 0;
            bool isElectrocuted = false;

            while (input != "end")
            {
                int oldRow = currentRow;
                int oldCol = currentCol;

                switch (input)
                {
                    case "up":
                        currentRow--;
                        break;
                    case "down":
                        currentRow++;
                        break;
                    case "left":
                        currentCol--;
                        break;
                    case "right":
                        currentCol++;
                        break;
                }

                if (currentRow >= 0 && currentRow < n &&
                    currentCol >= 0 && currentCol < n)
                {
                    if (matrix[currentRow, currentCol] == '-')
                    {
                        matrix[currentRow, currentCol] = '*';
                        holes++;
                    }
                    else if (matrix[currentRow, currentCol] == '*')
                    {
                        Console.WriteLine($"The wall is already destroyed at position " +
                            $"[{currentRow}, {currentCol}]!");
                    }
                    else if (matrix[currentRow, currentCol] == 'R')
                    {
                        Console.WriteLine("Vanko hit a rod!");
                        rods++;

                        currentRow = oldRow;
                        currentCol = oldCol;
                    }
                    else if (matrix[currentRow, currentCol] == 'C')
                    {
                        matrix[currentRow, currentCol] = 'E';
                        holes++;
                        isElectrocuted = true;
                        break;
                    }
                }
                else
                {
                    currentRow = oldRow;
                    currentCol = oldCol;
                }

                input = Console.ReadLine().ToLower();
            }

            if (isElectrocuted)
            {
                Console.WriteLine($"Vanko got electrocuted, but he managed to make " +
                    $"{holes} hole(s).");
            }
            else
            {
                Console.WriteLine($"Vanko managed to make {holes} hole(s) " +
                    $"and he hit only {rods} rod(s).");
                matrix[currentRow, currentCol] = 'V';
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }

        }
    }
}