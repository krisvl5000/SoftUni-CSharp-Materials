using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split().ToArray();

            Dictionary<string, int> occurences = new Dictionary<string, int>();

            foreach (var word in words)
            {
                string lowerCaseWord = word.ToLower();

                if (occurences.ContainsKey(lowerCaseWord))
                {
                    occurences[lowerCaseWord]++;
                }
                else
                {
                    occurences.Add(lowerCaseWord, 1);
                }
            }
            string[] result = occurences
                .Where(x => x.Value % 2 != 0)
                .Select(x => x.Key)
                .ToArray();

            Console.WriteLine(String.Join(" ", result));

            //                         Is the same as

            //foreach (var word in occurences)
            //{
            //    if (word.Value % 2 == 1)
            //    {
            //        Console.Write($"{word.Key} ");
            //    }
            //}

        }
    }
}