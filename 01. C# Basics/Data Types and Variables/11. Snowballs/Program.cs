using System;
using System.Linq;
using System.Numerics;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            BigInteger highestValue = 0;


            int finalSnow = 0;
            int finalTime = 0;
            int finalQuality = 0;

            for (int i = 1; i <= n; i++)
            {
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());

                BigInteger snowballValue = BigInteger.Pow
                    (snowballSnow / snowballTime, snowballQuality);

                if (snowballValue > highestValue)
                {
                    highestValue = snowballValue;

                    finalQuality = snowballQuality;
                    finalTime = snowballTime;
                    finalSnow = snowballSnow;
                }

            }

            Console.WriteLine($"{finalSnow} : {finalTime}" +
                $" = {highestValue} ({finalQuality})");

            
        }
    }
}