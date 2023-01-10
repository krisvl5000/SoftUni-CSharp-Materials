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
            string pattern = @"@#+(?<word>[A-Z][a-zA-Z0-9]{4,}[A-Z])@#+";
            Regex regex = new Regex(pattern);

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string productGroup = string.Empty;

                string input = Console.ReadLine();

                Match match = regex.Match(input);

                if (!match.Success)
                {
                    Console.WriteLine("Invalid barcode");
                    continue;
                }

                string productName = match.Groups["word"].Value;

                foreach (var ch in productName)
                {
                    if (char.IsDigit(ch))
                    {
                        productGroup += ch;
                    }
                }

                if (productGroup.Length > 0)
                {
                    Console.WriteLine($"Product group: {productGroup}");
                }
                else
                {
                    Console.WriteLine("Product group: 00");
                }
            }

        }
    }
}