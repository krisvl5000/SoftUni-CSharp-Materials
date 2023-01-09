using System;
using System.Linq;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] arr1 = Console.ReadLine().Split();
            string[] arr2 = Console.ReadLine().Split();

            string[] difference = new string[arr1.Length];

            for (int i = 0; i < arr1.Length; i++)
            {
                for (int j = 0; j < arr2.Length; j++)
                {
                    if (arr1[i] == arr2[j])
                    {
                        difference[i] = arr2[j];
                    }
                }
            }

            Array.Sort(difference);
            Console.WriteLine(string.Join(" ", difference));

        }
    }
}