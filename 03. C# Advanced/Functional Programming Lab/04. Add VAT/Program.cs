using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] prices = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            Func<double, double> vatAdder = price => price + price * 0.2;

            foreach (var item in prices)
            {
                double afterVat = 0;
                afterVat = vatAdder(item);

                Console.WriteLine($"{afterVat:F2}");
            }
        }
    }
}