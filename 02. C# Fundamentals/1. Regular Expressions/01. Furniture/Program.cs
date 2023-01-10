using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();

            string pattern = 
            @">>(?<name>[A-Za-z]+)<<(?<price>[0-9]+\.?[0-9]*)!(?<quantity>[0-9]+)";

            double totalPrice = 0;

            string input;
            while ((input = Console.ReadLine()) != "Purchase")
            {
                Match match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    string itemName = match.Groups["name"].Value;
                    double itemPrice = double.Parse(match.Groups["price"].Value);
                    int itemQuantity = int.Parse(match.Groups["quantity"].Value);

                    list.Add(itemName);

                    totalPrice += itemPrice * itemQuantity;
                }
            }

            Console.WriteLine("Bought furniture:");

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"Total money spend: {totalPrice:F2}");

        }
    }
}