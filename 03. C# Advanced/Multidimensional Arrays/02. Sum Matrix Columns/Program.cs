using System;
using System.Linq;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] size = Console.ReadLine().Split(", ");
            int rows = int.Parse(size[0]);
            int cols = int.Parse(size[1]);

            int[,] matrix = new int[rows, cols];

            int sum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = arr[col];
                }
            }

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                sum = 0;
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    sum += matrix[row, col];
                }

                Console.WriteLine(sum);
            }

            

        }
    }
}