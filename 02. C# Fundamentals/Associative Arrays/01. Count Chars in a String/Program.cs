using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<char, int>();
            
            string input = Console.ReadLine();

            foreach (var ch in input)
            {
                if (ch != ' ')
                {
                    if (!dict.ContainsKey(ch))
                    {
                        dict[ch] = 0;
                    }

                    dict[ch]++;

                }
            }

            foreach (var ch in dict)
            {
                Console.WriteLine($"{ch.Key} -> {ch.Value}");
            }

        }
    }
}