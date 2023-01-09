using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            double totalMoney = 0;

            while (true)
            {
                input = Console.ReadLine();
                
                if (input != "NoMoreMoney")
                {
                    double money = double.Parse(input);                                     
                    
                    if (money < 0)
                    {
                        Console.WriteLine("Invalid operation!");
                        Console.WriteLine($"Total: {totalMoney:F2}");
                        break;
                    }

                    totalMoney += money;
                    Console.WriteLine($"Increase: {money:F2}");
                }
                else
                {
                    Console.WriteLine($"Total: {totalMoney:F2}");
                    break;
                }
            }

        }
    }
}