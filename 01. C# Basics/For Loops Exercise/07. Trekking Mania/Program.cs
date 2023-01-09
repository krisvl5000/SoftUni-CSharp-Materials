using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int groups = int.Parse(Console.ReadLine());
            int people = 0;

            double totalPeople = 0.0;
            int musala = 0;
            int monblanc = 0;
            int kili = 0;
            int k2 = 0;
            int everest = 0;

            for (int i = 1; i <= groups; i++)
            {
                people = int.Parse(Console.ReadLine());

                totalPeople += people;

                if (people <= 5)
                {
                    musala += people;
                }
                else if (people <= 12)
                {
                    monblanc += people;
                }
                else if (people <= 25)
                {
                    kili += people;
                }
                else if (people <= 40)
                {
                    k2 += people;
                }
                else
                {
                    everest += people;
                }

            }
            double musalaPercentage = musala / totalPeople * 100.0;
            Console.WriteLine($"{musalaPercentage:F2}%");

            double monblancPercentage = monblanc / totalPeople * 100.0;
            Console.WriteLine($"{monblancPercentage:F2}%");

            double kiliPercentage = kili / totalPeople * 100.0;
            Console.WriteLine($"{kiliPercentage:F2}%");

            double k2Percentage = k2 / totalPeople * 100.0;
            Console.WriteLine($"{k2Percentage:F2}%");

            double everestPercentage = everest / totalPeople * 100;
            Console.WriteLine($"{everestPercentage:F2}%");



        }
    }
}