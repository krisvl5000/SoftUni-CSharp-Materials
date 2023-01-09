using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double washingMachine = double.Parse(Console.ReadLine());
            double toyPrice = double.Parse(Console.ReadLine());
            double money = 0;

            for (int i = 1; i <= age; i++)
            {
                if (i % 2 == 0)
                {
                    money += i * 5 - 1;
                }
                else
                {
                    money += toyPrice;
                }
            }
            if (money >= washingMachine)
            {
                Console.WriteLine($"Yes! {money - washingMachine:F2}");
            }
            else
            {
                Console.WriteLine($"No! {washingMachine - money:F2}");
            }

        }
    }
}