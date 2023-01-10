using System;
using System.Text.RegularExpressions;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern =
            @"\b(?<day>[0-9]{2})(.|/|-)(?<month>[A-Z][a-z]{2})(\1)(?<year>[0-9]{4}\b)";

            string input = Console.ReadLine();

            MatchCollection matches = Regex.Matches(input, pattern);

            foreach (Match match in matches)
            {
                Console.WriteLine($"Day: {match.Groups["day"].Value}," +
                                  $" Month: {match.Groups["month"].Value}, " +
                                  $"Year: {match.Groups["year"].Value}");
            }

        }
    }
}