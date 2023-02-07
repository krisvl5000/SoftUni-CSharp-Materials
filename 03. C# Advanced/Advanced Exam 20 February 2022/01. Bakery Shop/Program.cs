using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Hello_Softuni
{
    class Beaver
    {
        public Beaver(int rowIndex, int colIndex, int branchesLeft)
        {
            RowIndex = rowIndex;
            ColIndex = colIndex;
            BranchesCollected = new Stack<char>();
            BranchesLeft = branchesLeft;
        }

        public int RowIndex { get; set; }

        public int ColIndex { get; set; }

        public Stack<char> BranchesCollected { get; set; }

        public int BranchesLeft { get; set; }

        public void Move(string command, char[,] pond)
        {
            int size = pond.GetLength(0);
            pond[RowIndex, ColIndex] = '-';

            int newRowIndex = RowIndex;
            int newColIndex = ColIndex;

            switch (command)
            {
                case "up":
                    newRowIndex--;
                    break;
                case "down":
                    newRowIndex++;
                    break;
                case "left":
                    newColIndex--;
                    break;
                case "right":
                    newColIndex++;
                    break;
            }

            if (newRowIndex < 0 || newRowIndex >= size ||
                newColIndex < 0 || newColIndex >= size)
            {
                if (BranchesCollected.Any())
                {
                    BranchesCollected.Pop();
                }

                return;
            }

            RowIndex = newRowIndex;
            ColIndex = newColIndex;

            char symbol = pond[RowIndex, ColIndex];

            pond[RowIndex, ColIndex] = '-';

            if (char.IsLower(symbol))
            {
                BranchesCollected.Push(symbol);
                BranchesLeft--;
            }
            else if (symbol == 'F')
            {
                Swim(pond, command);
            }
        }

        public void Swim(char[,] pond, string command)
        {
            int maxIndex = pond.GetLength(0) - 1;

            if (command == "up" && RowIndex == 0) command = "down";
            else if (command == "down" && RowIndex == maxIndex) command = "up";
            else if (command == "left" && ColIndex == 0) command = "right";
            else if (command == "right" && ColIndex == maxIndex) command = "left";

            switch (command)
            {
                case "up": RowIndex = 0; break;
                case "down": RowIndex = maxIndex; break;
                case "left": ColIndex = 0; break;
                case "right": ColIndex = maxIndex; break;
            }

            pond[RowIndex, ColIndex] = '-';

            char symbol = pond[RowIndex, ColIndex];

            if (char.IsLower(symbol))
            {
                BranchesCollected.Push(symbol);
                BranchesLeft--;
            }
            else if (symbol == 'F')
            {
                Swim(pond, command);
            }
        }
    }

    internal class Program
    {

        static void Main(string[] args)
        {
            char[,] pond = ReadPondData(int.Parse(Console.ReadLine()));
            int totalBranches = GetBranchesCount(pond);
            (int beaverRow, int beaverCol) = GetBeaverLocation(pond);

            Beaver beaver = new Beaver(beaverRow, beaverCol, totalBranches);

            string command;
            while ((command = Console.ReadLine()) != "end" && beaver.BranchesLeft > 0)
            {
                beaver.Move(command, pond);
            }

            PrintResult(pond, beaver);
        }

        private static void PrintResult(char[,] pond, Beaver beaver)
        {
            pond[beaver.RowIndex, beaver.ColIndex] = 'B';

            if (beaver.BranchesLeft == 0)
            {
                Console.WriteLine($"The beaver successfully collect " +
                    $"{beaver.BranchesCollected.Count} wood branches: "
                    + String.Join(", ", beaver.BranchesCollected
                    .ToArray().Reverse()) + ".");
            }
            else
            {
                Console.WriteLine($"The beaver failed to collect every wood branch. " +
                    $"There are {beaver.BranchesLeft} branches left.");
            }

            for (int row = 0; row < pond.GetLength(0); row++)
            {
                for (int col = 0; col < pond.GetLength(1); col++)
                {
                    Console.Write(pond[row, col] + " ");
                }

                Console.WriteLine();
            }
        }

        static char[,] ReadPondData(int size)
        {
            char[,] pond = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                char[] line = Console.ReadLine().ToCharArray()
                    .Where(x => x != ' ').ToArray();
                for (int col = 0; col < size; col++)
                {
                    pond[row, col] = line[col];
                }
            }

            return pond;
        }

        static int GetBranchesCount(char[,] pond)
        {
            int count = 0;

            foreach (var item in pond)
            {
                if (char.IsLower(item))
                {
                    count++;
                }
            }

            return count;
        }

        static (int row, int col) GetBeaverLocation(char[,] pond)
        {
            for (int row = 0; row < pond.GetLength(0); row++)
            {
                for (int col = 0; col < pond.GetLength(1); col++)
                {
                    if (pond[row, col] == 'B')
                    {
                        return (row, col);
                    }
                }
            }

            throw new ArgumentException();
        }
    }
}