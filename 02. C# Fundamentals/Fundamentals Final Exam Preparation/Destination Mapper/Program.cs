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
            List<string> list = new List<string>();

            string pattern = @"(=|\/)(?<name>[A-Z][A-Za-z]{2,})(\1)";

            string input = Console.ReadLine();

            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(input);

            int score = 0;

            foreach (Match match in matches)
            {
                string name = match.Groups["name"].Value;
                score += name.Length;
                list.Add(name);
            }

            Console.WriteLine($"Destinations: {string.Join(", ", list)}");
            Console.WriteLine($"Travel Points: {score}");

        }
    }
}