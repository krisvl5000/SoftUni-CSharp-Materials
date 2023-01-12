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

            for (int row = 0; row < n; row++)
            {
                int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = arr[col];
                }
            }

            int leftToRightSum = 0;
            int rightToLeftSum = 0;

            for (int i = 0; i < n; i++)
            {
                leftToRightSum += matrix[i, i];
                rightToLeftSum += matrix[i, n - i - 1];
            }

            int totalSum = Math.Abs(leftToRightSum - rightToLeftSum);
            Console.WriteLine(totalSum);

        }
    }
}