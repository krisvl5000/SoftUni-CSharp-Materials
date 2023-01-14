using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var dict = new SortedDictionary<char, int>();

            foreach (var ch in input)
            {
                if (!dict.ContainsKey(ch))
                {
                    dict.Add(ch, 0);
                }
                
                dict[ch]++;
            }

            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }

        }
    }
}