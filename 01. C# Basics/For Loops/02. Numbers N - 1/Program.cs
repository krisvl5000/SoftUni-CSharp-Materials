using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int number = n; number >= 1; number--)
            {
                Console.WriteLine(number);
            }

        }
    }
}