using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Creating the matrix

            int n = int.Parse(Console.ReadLine());
            string racingNumber = Console.ReadLine();

            char[,] matrix = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                string[] raceRouteRaw = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string raceRoute = String.Join("", raceRouteRaw);

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
            bool disqualified = false;

            int fRow = 0;
            int fCol = 0;

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
                    else if (matrix[row, col] == 'F')
                    {
                        fRow = row;
                        fCol = col;
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

                for (int row = lastPositionRow; row < n; row++)
                {
                    for (int col = lastPositionCol; col < n; col++)
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

                        if (matrix[row, col] == 'T') // does not enter the tunnel
                        {
                            kilometersTravelled += 30;

                            if (row == firstLocationRow && col == firstLocationCol)
                            {
                                row = secondLocationRow;
                                col = secondLocationCol;

                                lastPositionRow = row;
                                lastPositionCol = col;
                                break;
                            }
                            else if (row == secondLocationRow && col == secondLocationCol)
                            {
                                row = firstLocationRow;
                                col = firstLocationCol;

                                lastPositionRow = row;
                                lastPositionCol = col;
                                break;
                            }

                        }
                        else if (matrix[row, col] == 'F')
                        {
                            kilometersTravelled += 10;

                            Console.WriteLine($"Racing car {racingNumber} finished " +
                                $"the stage!");

                            carFinished = true;
                        }
                        else
                        {
                            kilometersTravelled += 10;
                            lastPositionRow = row;
                            lastPositionCol = col;
                            break;
                        }
                    }
                    break;
                }

                input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            if (!carFinished)
            {
                disqualified = true;
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
                        if (disqualified && row == fRow && col == fCol)
                        {
                            Console.Write("F");
                        }
                        else
                        {
                            Console.Write(".");
                        }
                    }
                }

                Console.WriteLine();
            }
        }
    }
}