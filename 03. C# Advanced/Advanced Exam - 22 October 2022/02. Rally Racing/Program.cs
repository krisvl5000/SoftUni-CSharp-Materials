using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Creating the matrix

            int n = int.Parse(Console.ReadLine());
            int racingNumber = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                string raceRoute = Console.ReadLine();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = raceRoute[col];
                }
            }

            // Finding the tunnel locations

            int firstLocationRow = 0;
            int firstLocationCol = 0;

            int secondLocationRow = 0;
            int secondLocationCol = 0;

            bool firstLocationHasBeenFound = false;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] == 'T')
                    {
                        if (!firstLocationHasBeenFound)
                        {
                            firstLocationRow = row;
                            firstLocationCol = col;

                            firstLocationHasBeenFound = true;
                        }
                        else
                        {
                            secondLocationRow = row;
                            secondLocationCol = col;
                        }
                    }
                }
            }

            // Moving the car

            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int kilometersTravelled = 0;

            bool carFinished = false;

            int lastPositionRow = 0;
            int lastPositionCol = 0;

            while (input[0] != "End")
            {
                if (carFinished)
                {
                    break;
                }
                string direction = input[0];

                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        if (direction == "left")
                        {
                            col--;
                        }
                        else if (direction == "right")
                        {
                            col++;
                        }
                        else if (direction == "up")
                        {
                            row--;
                        }
                        else if (direction == "down")
                        {
                            row++;
                        }

                        if (matrix[row, col] == 'T')
                        {
                            kilometersTravelled += 30;

                            if (row == firstLocationRow || col == firstLocationCol)
                            {
                                row = secondLocationRow;
                                col = secondLocationCol;
                            }
                            else if (row == secondLocationRow || col == secondLocationCol)
                            {
                                row = firstLocationRow;
                                col = firstLocationCol;
                            }

                        }
                        else if (matrix[row, col] == 'F')
                        {
                            kilometersTravelled += 10;

                            Console.WriteLine($"Racing car {racingNumber} finished" +
                                $"the stage!");

                            carFinished = true;
                        }
                        else
                        {
                            kilometersTravelled += 10;
                            lastPositionRow = row;
                            lastPositionCol = col;
                        }
                    }
                }
            }

            if (!carFinished)
            {
                Console.WriteLine($"Racing car {racingNumber} DNF.");
            }

            Console.WriteLine($"Distance covered {kilometersTravelled} km.");

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (row == lastPositionRow && col == lastPositionCol)
                    {
                        Console.Write("C");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }

                Console.WriteLine();
            }
        }
    }
}