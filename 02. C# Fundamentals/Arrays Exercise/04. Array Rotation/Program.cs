using System;
using System.Linq;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int rotations = int.Parse(Console.ReadLine());

            for (int j = 1; j <= rotations; j++)
            {
                int firstEl = arr[0];

                for (int i = 0; i <= arr.Length - 2; i++)
                {
                    arr[i] = arr[i + 1];
                }

                arr[arr.Length - 1] = firstEl;
            }
            Console.WriteLine(String.Join(" ", arr));

        }
    }
}