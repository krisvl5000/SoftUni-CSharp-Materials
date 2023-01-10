using System;
using System.Linq;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] matrix = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                matrix[i] = Console.ReadLine().Split().Select(int.Parse).ToArray();
            }

            string[] input = Console.ReadLine().Split();

            while (input[0] != "END")
            {
                string command = input[0];

                int row = int.Parse(input[1]);
                int col = int.Parse(input[2]);
                int value = int.Parse(input[3]);

                if (row < 0
                        || col < 0
                        || row >= matrix.Length
                        || col >= matrix[row].Length)
                {
                    Console.WriteLine("Invalid coordinates");

                    input = Console.ReadLine().Split();
                    continue;
                }

                if (command == "Add")
                {                   
                    matrix[row][col] += value;
                }
                else if (command == "Subtract")
                {
                    matrix[row][col] -= value;
                }

                input = Console.ReadLine().Split();
            }

            for (int row = 0; row < matrix.Length; row++)
            {
                Console.WriteLine(String.Join(" ", matrix[row]));
            }

        }
    }
}