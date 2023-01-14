using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            arr = arr.OrderByDescending(x => x).ToArray();

            if (arr.Length > 3)
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.Write(arr[i] + " ");
                }
            }
            else
            {
                foreach (var item in arr)
                {
                    Console.Write(item + " ");
                }
            }

        }
    }
}