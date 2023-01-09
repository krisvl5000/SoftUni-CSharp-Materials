using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            string city = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());

            if (product == "coffee")
            {
                switch (city)
                {
                    case "Sofia":
                        double price = 0.50;
                        break;
                    case "Plovdiv":
                        price = 0.80;
                        break;
                    case "beer":
                        price = 1.20;
                        break;
                    case "sweets":
                        price = 1.45;
                        break;
                    case "peanuts":
                        price = 1.60;
                        break;
                        Console.WriteLine(price * quantity);

                }

            }
            else if (city == "Plovdiv")
            {
                switch (product)
                {
                    case "coffee":
                        double price = 0.40;
                        break;
                    case "water":
                        price = 0.70;
                        break;
                    case "beer":
                        price = 1.15;
                        break;
                    case "sweets":
                        price = 1.30;
                        break;
                    case "peanuts":
                        price = 1.50;
                        break;
                        Console.WriteLine(price * quantity);
                }
            }
            else if (city == "Varna")
            {
                switch (product)
                {
                    case "coffee":
                        double price = 0.45;
                        break;
                    case "water":
                        price = 0.70;
                        break;
                    case "beer":
                        price = 1.10;
                        break;
                    case "sweets":
                        price = 1.35;
                        break;
                    case "peanuts":
                        price = 1.55;
                        break;
                        Console.WriteLine(price * quantity);
                }
            }
        }
    }
}




















