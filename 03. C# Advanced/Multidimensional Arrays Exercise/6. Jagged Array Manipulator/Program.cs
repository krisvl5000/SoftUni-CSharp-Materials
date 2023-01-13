using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int[][] matrix = new int[n][];
        for (int i = 0; i < n; i++)
        {
            matrix[i] = Console.ReadLine().Split().Select(int.Parse).ToArray();
        }

        for (int i = 0; i < matrix.Length - 1; i++)
        {
            if (matrix[i].Length == matrix[i + 1].Length)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    matrix[i][j] *= 2;
                    matrix[i + 1][j] *= 2;
                }
            }
            else
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    matrix[i][j] /= 2;
                }
                for (int j = 0; j < matrix[i + 1].Length; j++)
                {
                    matrix[i + 1][j] /= 2;
                }
            }
        }

        while (true)
        {
            string[] command = Console.ReadLine().Split();
            if (command[0] == "End")
            {
                break;
            }

            int row = int.Parse(command[1]);
            int col = int.Parse(command[2]);
            int value = int.Parse(command[3]);

            if (command[0] == "Add")
            {
                if (AreIndexesValid(row, col, matrix))
                {
                    matrix[row][col] += value;
                }
            }
            else if (command[0] == "Subtract")
            {
                if (AreIndexesValid(row, col, matrix))
                {
                    matrix[row][col] -= value;
                }
            }
        }

        foreach (int[] row in matrix)
        {
            Console.WriteLine(string.Join(" ", row));
        }
    }

    static bool AreIndexesValid(int row, int col, int[][] matrix)
    {
        if (row >= 0 && row < matrix.GetLength(0) &&
            col >= 0 && col < matrix[row].Length)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}