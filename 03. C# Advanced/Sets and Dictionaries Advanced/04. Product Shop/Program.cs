using System;
using System.Linq;
using System.Collections.Generic;

namespace _04._Product_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var productShops = new Dictionary<string, Dictionary<string, double>>();

            string input = Console.ReadLine();

            while (input != "Revision")
            {
                var splitted = input.Split(", ");

                string shop = splitted[0];
                string product = splitted[1];
                double price = double.Parse(splitted[2]);

                if (!productShops.ContainsKey(shop))
                {
                    productShops.Add(shop, new Dictionary<string, double>());
                }

                productShops[shop].Add(product, price);

                input = Console.ReadLine();
            }

            productShops = productShops.OrderBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var shop in productShops)
            {
                Console.WriteLine($"{shop.Key}->");
                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
