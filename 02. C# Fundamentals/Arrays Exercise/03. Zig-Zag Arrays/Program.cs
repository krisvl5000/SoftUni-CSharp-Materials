using System;
using System.Linq;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            // filled arrays
            int[] arr1 = new int[n];
            int[] arr2 = new int[n];

            for (int row = 1; row <= n; row++)
            {
                int[] currentrowData = Console.ReadLine().Split
                    (' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                int firstNumber = currentrowData[0];
                int secondNumber = currentrowData[1];

                if (row % 2 != 0)
                {
                    arr1[row - 1] = firstNumber;
                    arr2[row - 1] = secondNumber;
                }
                else
                {
                    arr1[row - 1] = secondNumber;
                    arr2[row - 1] = firstNumber;
                }
                
            }

            Console.WriteLine(string.Join(" ", arr1));
            Console.WriteLine(string.Join(" ", arr2));

        }
    }
}