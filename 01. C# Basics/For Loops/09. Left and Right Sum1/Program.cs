using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numbersCount = int.Parse(Console.ReadLine());

            int leftSum = 0;
            int rightSum = 0;

            for (int i = 1; i <= numbersCount; i++)
            {
               int num1 = int.Parse(Console.ReadLine());
               leftSum += num1;                
            }

            for (int i = 1; i <= numbersCount; i++)
            {
                int num2 = int.Parse(Console.ReadLine());
                rightSum += num2;
            }

            int diff = Math.Abs(leftSum - rightSum);

            if (leftSum == rightSum)
            {
                Console.WriteLine($"Yes, sum = {leftSum}");
            }
            else
            {
                Console.WriteLine($"No, diff = {diff}");
            }

        }
    }
}