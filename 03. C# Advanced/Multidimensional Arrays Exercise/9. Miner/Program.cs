using System;
using System.Linq;

class Miner
{
    static void Main()
    {
        // Get the field size and the commands
        int size = int.Parse(Console.ReadLine());
        string[] commands = Console.ReadLine().Split();

        // Create the field
        char[,] field = new char[size, size];
        for (int row = 0; row < size; row++)
        {
            char[] elements = Console.ReadLine().Replace(" ", "").ToCharArray();
            for (int col = 0; col < size; col++)
            {
                field[row, col] = elements[col];
            }
        }

        // Initialize the miner's position
        int minerRow = 0;
        int minerCol = 0;
        for (int row = 0; row < size; row++)
        {
            for (int col = 0; col < size; col++)
            {
                if (field[row, col] == 's')
                {
                    minerRow = row;
                    minerCol = col;
                }
            }
        }

        // Initialize the count of collected coals
        int coals = 0;

        // Loop through the commands
        for (int i = 0; i < commands.Length; i++)
        {
            // Move the miner
            switch (commands[i])
            {
                case "up":
                    if (minerRow > 0)
                    {
                        minerRow--;
                    }
                    break;
                case "down":
                    if (minerRow < size - 1)
                    {
                        minerRow++;
                    }
                    break;
                case "left":
                    if (minerCol > 0)
                    {
                        minerCol--;
                    }
                    break;
                case "right":
                    if (minerCol < size - 1)
                    {
                        minerCol++;
                    }
                    break;
            }

            // Check if the miner is on a coal
            if (field[minerRow, minerCol] == 'c')
            {
                coals++;
                field[minerRow, minerCol] = '*';
            }

            // Check if the miner is on the end
            if (field[minerRow, minerCol] == 'e')
            {
                Console.WriteLine("Game over! ({0}, {1})", minerRow, minerCol);
                return;
            }
        }

        // Count remaining coals
        int remainingCoals = 0;
        for (int row = 0; row < size; row++)
        {
            for (int col = 0; col < size; col++)
            {
                if (field[row, col] == 'c')
                {
                    remainingCoals++;
                }
            }
        }

        if (remainingCoals == 0)
        {
            Console.WriteLine("You collected all coals! ({0}, {1})", minerRow, minerCol);
        }
        else
        {
            Console.WriteLine("{0} coals left. ({1}, {2})", remainingCoals, minerRow, minerCol);
        }
    }
}
