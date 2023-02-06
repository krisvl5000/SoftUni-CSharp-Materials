//using System;

//namespace WallDestroyer
//{
//    public class WallDestroyer
//    {
//        private static int vankoRow;
//        private static int vankoCol;
//        private static char[,] wall;

//        private static int countOfHoles = 1;
//        private static int countOfRods;

//        private static bool isAlive = true;
//        static void Main()
//        {
//            //create the wall
//            int n = int.Parse(Console.ReadLine());
//            wall = new char[n, n];
//            for (int row = 0; row < n; row++)
//            {
//                string input = Console.ReadLine();
//                for (int col = 0; col < n; col++)
//                {
//                    wall[row, col] = input[col];
//                }
//            }

//            //find Vanko's position
//            for (int row = 0; row < n; row++)
//            {
//                for (int col = 0; col < n; col++)
//                {
//                    if (wall[row, col] == 'V')
//                    {
//                        vankoRow = row;
//                        vankoCol = col;
//                        break;
//                    }
//                }
//            }

//            //start receiving directions
//            string command = Console.ReadLine();
//            while (command != "End")
//            {
//                if (command == "up")
//                {
//                    Move(-1, 0);
//                }
//                else if (command == "down")
//                {
//                    Move(1, 0);
//                }
//                else if (command == "left")
//                {
//                    Move(0, -1);
//                }
//                else if (command == "right")
//                {
//                    Move(0, 1);
//                }

//                if (!isAlive)
//                {
//                    break;
//                }
//                command = Console.ReadLine();
//            }

//            //print the matrix
//            if (isAlive)
//            {
//                Console.WriteLine($"Vanko managed to make {countOfHoles} " +
//                    $"hole(s) and he hit only {countOfRods} rod(s).");
//            }
//            PrintMatrix(n);
//        }

//        private static void Move(int row, int col)
//        {
//            if (isInside(vankoRow + row, vankoCol + col))
//            {
//                if (wall[vankoRow + row, vankoCol + col] == 'C')
//                {
//                    wall[vankoRow, vankoCol] = '*';
//                    vankoRow += row;
//                    vankoCol += col;
//                    countOfHoles++;
//                    wall[vankoRow, vankoCol] = 'E';
//                    Console.WriteLine($"Vanko got electrocuted, but he managed " +
//                        $"to make {countOfHoles} hole(s).");
//                    isAlive = false;
//                }
//                else if (wall[vankoRow + row, vankoCol + col] == 'R')
//                {
//                    countOfRods++;
//                    Console.WriteLine($"Vanko hit a rod!");
//                }
//                else if (wall[vankoRow + row, vankoCol + col] == '-')
//                {
//                    wall[vankoRow, vankoCol] = '*';
//                    vankoRow += row;
//                    vankoCol += col;
//                    wall[vankoRow, vankoCol] = 'V';
//                    countOfHoles++;
//                }
//                else if (wall[vankoRow + row, vankoCol + col] == '*')
//                {
//                    wall[vankoRow, vankoCol] = '*';
//                    Console.WriteLine($"The wall is already destroyed at position " +
//                        $"[{vankoRow + row}, {vankoCol + col}]!");
//                    vankoRow += row;
//                    vankoCol += col;
//                    wall[vankoRow, vankoCol] = 'V';
//                }
//            }
//        }

//        private static bool isInside(int row, int col)
//        {
//            return row >= 0 && row < wall.GetLength(0)
//                && col >= 0 && col < wall.GetLength(1);
//        }

//        private static void PrintMatrix(int n)
//        {
//            for (int row = 0; row < n; row++)
//            {
//                for (int col = 0; col < n; col++)
//                {
//                    Console.Write(wall[row, col]);
//                }
//                Console.WriteLine();
//            }
//        }

//    }
//}

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
                string input = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col];

                    if (input[col] == 'V')
                    {
                        currentRow = row;
                        currentCol = col;
                    }
                }
            }

            string command = Console.ReadLine().ToLower();

            int holes = 1;
            int rods = 0;

            matrix[currentRow, currentCol] = '*';
            bool isElectrocuted = false;

            while (command != "end")
            {
                int oldRow = currentRow;
                int oldCol = currentCol;

                switch (command)
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
                    if (matrix[currentRow, currentCol] == 'R')
                    {
                        Console.WriteLine("Vanko hit a rod!");
                        rods++;

                        currentRow = oldRow;
                        currentCol = oldCol;
                    }
                    else if (matrix[currentRow, currentCol] == '-')
                    {
                        holes++;
                        matrix[currentRow, currentCol] = '*';
                    }
                    else if (matrix[currentRow, currentCol] == '*')
                    {
                        Console.WriteLine($"The wall is already destroyed at position " +
                            $" [{currentRow}, {currentCol}]!");
                    }
                    else if (matrix[currentRow, currentCol] == 'C')
                    {
                        matrix[currentRow, currentCol] = 'E';
                        isElectrocuted = true;
                        holes++;
                        break;
                    }
                }
                else
                {
                    currentRow = oldRow;
                    currentCol = oldCol;
                }

                command = Console.ReadLine().ToLower();
            }

            if (isElectrocuted)
            {
                Console.WriteLine($"Vanko got electrocuted but managed to " +
                    $"make {holes} hole(s).");
            }
            else
            {
                Console.WriteLine($"Vanko managed to make {holes} hole(s) " +
                    $"and he hit only {rods} rod(s).");
                matrix[currentCol, currentRow] = 'V';
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[col, col]);
                }

                Console.WriteLine();
            }

        }
    }
}