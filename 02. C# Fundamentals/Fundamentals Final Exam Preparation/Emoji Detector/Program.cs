using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Match> list = new List<Match>();
            string emojiPattern = @"(::|\*\*)(?<word>[A-Z][a-z]{2,})(\1)";
            string digitsPattern = @"[0-9]";

            string input = Console.ReadLine();

            Regex wordRegex = new Regex(emojiPattern);
            Regex digitsRegex = new Regex(digitsPattern);

            MatchCollection wordMatches = wordRegex.Matches(input);
            MatchCollection digitsMatches = digitsRegex.Matches(input);

            long threshold = 1;
            foreach (Match match in digitsMatches)
            {
                threshold *= long.Parse(match.Value);
            }

            foreach (Match word in wordMatches)
            {
                int sum = 0;
                string emoji = word.Groups["word"].Value;

                foreach (var ch in emoji)
                {
                    sum += (int)ch;
                }

                if (sum > threshold)
                {
                    list.Add(word);
                }
            }
            Console.WriteLine($"Cool threshold: {threshold}");

            Console.WriteLine($"{wordMatches.Count} emojis found in the text. The " +
                $"cool ones are:");

            foreach (Match item in list)
            {
                Console.WriteLine(item);
            }

        }
    }
}