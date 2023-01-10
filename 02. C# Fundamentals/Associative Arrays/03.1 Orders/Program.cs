using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var quantityMap = new Dictionary<string, double>();
            var priceMap = new Dictionary<string, double>();

            string[] input = Console.ReadLine().Split();

            while (input[0] != "buy")
            {
                string product = input[0];
                double price = double.Parse(input[1]);
                double quantity = double.Parse(input[2]);

                if (!quantityMap.ContainsKey(product))
                {
                    quantityMap.Add(product, 0.0);
                    priceMap.Add(product, 0.0);
                }

                priceMap[product] = price;
                quantityMap[product] += quantity;

                input = Console.ReadLine().Split();
            }

            foreach (var quant in quantityMap)
            {
                foreach (var price in priceMap)
                {
                    if (quant.Key == price.Key)
                    {
                        Console.WriteLine($"{quant.Key} -> {quant.Value * price.Value:F2}");
                    }
                }
            }

        }
    }
}