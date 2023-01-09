using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();

            int quantity = int.Parse(Console.ReadLine());            

            Math(type, quantity);
        }

        static void Math(string type, double quantity)
        {
            
            double price = 0;

            switch (type)
            {
                case "coffee":
                    price = 1.50;
                    break;
                case "water":
                    price = 1.00;
                    break;
                case "coke":
                    price = 1.40;
                    break;
                case "snacks":
                    price = 2.00;
                    break;
            }

            double result = price * quantity;

            Console.WriteLine($"{result:F2}");


        }
    }
}