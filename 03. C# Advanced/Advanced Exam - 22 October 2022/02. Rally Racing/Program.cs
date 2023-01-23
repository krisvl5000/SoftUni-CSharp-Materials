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

            int firstLocationRow;
            int firstLocationCol;

            int secondLocationRow;
            int secondLocationCol;

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

            int kilometersPassed = 0;

            while (input[0] != "End")
            {
                string direction = input[0];

                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {

                    }
                }
            }

        }
    }
}