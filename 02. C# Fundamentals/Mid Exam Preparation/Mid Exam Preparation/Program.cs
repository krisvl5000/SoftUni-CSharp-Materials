using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            double sumPrice = 0;

            double afterTax = 0;

            double finalPrice = 0;

            double taxes = 0;

            while (true)
            {

                if (input == "special")
                {
                    // sumPrice + taxes - 10%
                    afterTax = sumPrice + (0.2 * sumPrice);
                    finalPrice = afterTax - (0.1 * afterTax);
                    taxes = 0.2 * sumPrice;
                    break;
                }
                else if (input == "regular")
                {
                    // sumPrice + taxes
                    finalPrice = sumPrice + (0.2 * sumPrice);
                    taxes = 0.2 * sumPrice;
                    break;
                }

                if (input != "special" || input != "regular")
                {
                    double newInput = double.Parse(input);

                    if (newInput < 0)
                    {
                        Console.WriteLine("Invalid price!");
                        input = Console.ReadLine();
                        continue;
                    }

                    sumPrice += newInput;

                }
                
                input = Console.ReadLine();                
                            
            }

            if (sumPrice == 0)
            {
                Console.WriteLine("Invalid order!");
                return;
            }

            Console.WriteLine("Congratulations you've just bought a new computer!");
            Console.WriteLine($"Price without taxes: {sumPrice:F2}$");
            Console.WriteLine($"Taxes: {taxes:F2}$");
            Console.WriteLine("-----------");
            Console.WriteLine($"Total price: {finalPrice:F2}$");

        }
    }
}