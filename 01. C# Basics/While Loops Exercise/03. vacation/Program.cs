using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double moneyNeeded = double.Parse(Console.ReadLine());
            double currentMoney = double.Parse(Console.ReadLine());

            string input;
            int days = 0;
            int daysSpend = 0;

            while (true)
            {
                input = Console.ReadLine();
                if (input == "spend")
                {
                    double savedOrSpent = double.Parse(Console.ReadLine());

                    currentMoney -= savedOrSpent;
                    if (currentMoney < 0)
                    {
                        currentMoney = 0;
                    }

                    daysSpend++;
                    days++;

                    if (daysSpend >= 5)
                    {
                        Console.WriteLine("You can't save the money.");
                        Console.WriteLine($"{days}");
                        break;
                    }
                }
                else if (input == "save")
                {
                    double savedOrSpent = double.Parse(Console.ReadLine());
                    currentMoney += savedOrSpent;
                    days++;
                    daysSpend = 0;
                }
                if (currentMoney >= moneyNeeded)
                {
                    Console.WriteLine($"You saved the money for {days} days.");
                    break;
                }
            }


        }
    }
}