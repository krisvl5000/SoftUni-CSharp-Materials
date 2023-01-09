using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double @base = int.Parse(Console.ReadLine());
            double power = int.Parse(Console.ReadLine());
            double powerResult = MathPower(@base, power);
            Console.WriteLine(powerResult);

        }

        static double MathPower(double @base, double power)
        {
            double result = 1;

            for (int i = 0; i < power; i++)
            {
                result = result * @base;
            }

            return result;
        }
    }
}