using System;
using System.Linq;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = arr[col];
                }
            }

            int primarySum = 0;
            int secondarySum = 0;

            for (int i = 0; i < n; i++)
            {
                primarySum += matrix[i, i];
                secondarySum += matrix[i, n - i - 1];
            }

            Console.WriteLine(Math.Abs(primarySum - secondarySum));


        }
    }
}