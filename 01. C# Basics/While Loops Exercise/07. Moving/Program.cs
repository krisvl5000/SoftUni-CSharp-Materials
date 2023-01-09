using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());

            int totalSpace = width * height * length;

            while (totalSpace > 0)
            {
                string input = Console.ReadLine();

                if (input != "Done")
                {
                    totalSpace -= int.Parse(input);
                    
                    if (totalSpace < 0)
                    {
                        Console.WriteLine($"No more free space! You need {Math.Abs(totalSpace)} Cubic meters more.");
                    }
                    
                }
                else
                {
                    Console.WriteLine($"{totalSpace} Cubic meters left.");
                    break;
                }
            }

        }
    }
}