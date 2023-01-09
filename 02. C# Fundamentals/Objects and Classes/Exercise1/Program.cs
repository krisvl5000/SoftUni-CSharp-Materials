using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            double students = double.Parse(Console.ReadLine());
            double saberPrice = double.Parse(Console.ReadLine());
            double robePrice = double.Parse(Console.ReadLine());
            double beltPrice = double.Parse(Console.ReadLine());

            double totalBeltPrice = (saberPrice * students) - 
                (Math.Floor(students / 6) * saberPrice);

            double totalRobePrice = robePrice * students;

            double totalSaberPrice = (saberPrice * students) + 
                (Math.Ceiling(students / 10) * saberPrice);

            double finalPrice = totalBeltPrice + totalRobePrice + totalSaberPrice;

            if (finalPrice <= money)
            {
                Console.WriteLine($"The money is enough - it would cost {finalPrice:F2}lv.");
            }
            else
            {
                Console.WriteLine($"John will need {finalPrice - money:F2} more.");
            }


        }
    }
}