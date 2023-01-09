using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> items = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                items.Add(input);
            }

            items.Sort();

            int count = 1;

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"{count}.{items[i]}");
                count++;
            }


        }
    }
}