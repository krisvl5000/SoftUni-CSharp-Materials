using System;
using System.Linq;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[][] matrix = new int[n][];

            for (int row = 0; row < n; row++)
            {
                int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < arr.Length; col++)
                {
                    matrix[row] = arr;
                }
            }

            string[] input = Console.ReadLine().Split();

            while (input[0] != "END")
            {
                string command = input[0];

                if (command == "Add")
                {
                    int row = int.Parse(input[1]);
                    int col = int.Parse(input[2]);
                    int valueToAdd = int.Parse(input[3]);

                    if (DoesTheMatrixContain(row, col, matrix))
                    {
                        matrix[row][col] += valueToAdd;
                    }
                    else
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                }
                else if (command == "Subtract")
                {
                    int row = int.Parse(input[1]);
                    int col = int.Parse(input[2]);
                    int valueToSubtract = int.Parse(input[3]);

                    if (DoesTheMatrixContain(row, col, matrix))
                    {
                        matrix[row][col] -= valueToSubtract;
                    }
                    else
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                }

                input = Console.ReadLine().Split();
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col] + " ");
                }

                Console.WriteLine();
            }

        }

        static bool DoesTheMatrixContain(int row, int col, int[][] matrix)
        {
            if (row < matrix.GetLength(0) && row >= 0 && 
                col < matrix[row].Length && col >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}