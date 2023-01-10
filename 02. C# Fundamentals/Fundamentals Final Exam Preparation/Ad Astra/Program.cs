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
            string pattern = 
            @"(\||#)(?<name>[A-Za-z ]+)(\1)(?<expDate>[0-9]{2}\/[0-9]{2}\/[0-9]{2})(\1)(?<calories>[0-9]+)(\1)";

            Regex regex = new Regex(pattern);

            string input = Console.ReadLine();

            MatchCollection matches = Regex.Matches(input, pattern);

            int totalCals = 0;

            foreach (Match item in matches)
            {
                int calories = int.Parse(item.Groups["calories"].Value);
                totalCals += calories;
            }

            int days = totalCals / 2000;

            Console.WriteLine($"You have food to last you for: {days} days!");

            foreach (Match item in matches)
            {
                Console.WriteLine($"Item: {item.Groups["name"].Value}, " +
                    $"Best before: {item.Groups["expDate"].Value}, " +
                    $"Nutrition: {item.Groups["calories"].Value}");
            }

        }
    }
}