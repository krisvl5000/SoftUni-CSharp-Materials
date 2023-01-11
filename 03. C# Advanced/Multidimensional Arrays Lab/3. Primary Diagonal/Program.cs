using System;
using System.Linq;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n,n];

            for (int row = 0; row < n; row++)
            {
                int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = arr[col];
                }
            }

            int sum = 0;
            int colCounter = 0;

            for (int row = 0; row < n; row++)
            {
                for (int col = colCounter; col < n; col++)
                {
                    sum += matrix[row, col];
                    break;

                }
                colCounter++;
            }

            Console.WriteLine(sum);

        }
    }
}