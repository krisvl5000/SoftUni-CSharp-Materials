using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(" ");

            int totalSum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                try
                {
                    int num = int.Parse(input[i]);
                    totalSum += num;
                }
                catch (FormatException fe)
                {
                    Console.WriteLine($"The element '{input[i]}' is in wrong format!");
                }
                catch (OverflowException ofe)
                {
                    Console.WriteLine($"The element '{input[i]}' is out of range!");
                }

                Console.WriteLine($"Element '{input[i]}' processed - " +
                        $"current sum: {totalSum}");
            }

            Console.WriteLine($"The total sum of all integers is: {totalSum}");

        }
    }
}