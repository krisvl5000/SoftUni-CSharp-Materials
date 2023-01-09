using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int tournaments = int.Parse(Console.ReadLine());
            int startingPoints = int.Parse(Console.ReadLine());

            int totalPoints = 0;
            double totalWins = 0; 

            for (int i = 1; i <= tournaments; i++)
            {
                string stage = Console.ReadLine();
                

                if (stage == "W")
                {
                    totalPoints += 2000;
                    totalWins++;
                }
                else if (stage == "F")
                {
                    totalPoints += 1200;
                }
                else if (stage == "SF")
                {
                    totalPoints += 720;
                }

            }
            //Средните точки да бъдат закръглени към най - близкото цяло число надолу, а процентът 
            //    да се форматира до втората цифра след десетичния знак.

            double averagePoints = totalPoints / tournaments;
            double wins = (totalWins / tournaments) * 100.0;

            Console.WriteLine($"Final points: {totalPoints + startingPoints}");
            Console.WriteLine($"Average points: {Math.Floor(averagePoints)}");
            Console.WriteLine($"{wins:F2}%");
        }
        
    }
}
      