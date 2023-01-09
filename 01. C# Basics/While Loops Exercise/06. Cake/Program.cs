using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());

            int totalPieces = width * length;

            string input;

            while (totalPieces > 0)
            {
                input = Console.ReadLine();

                if (input != "STOP")
                {
                    totalPieces -= int.Parse(input);

                    if (totalPieces < 0)
                    {
                        Console.WriteLine($"No more cake left! You need {Math.Abs(totalPieces)} pieces more.");                        
                    }
                }
                else
                {
                    Console.WriteLine($"{totalPieces} pieces are left.");
                    break;
                }
            }
        }
    }
}