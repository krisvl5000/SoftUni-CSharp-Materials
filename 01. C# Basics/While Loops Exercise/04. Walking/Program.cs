using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int steps = 0;
            string input;

            while (steps < 10000)
            {
                input = (Console.ReadLine());

                if (input != "Going home")
                {
                    steps += int.Parse(input);
                }
                else
                {
                    steps += int.Parse(Console.ReadLine());
                    break;
                }
            }
            if (steps >= 10000)
            {
                Console.WriteLine("Goal reached! Good job!");
                Console.WriteLine($"{steps - 10000} steps over the goal!");
            }
            else
            {
                Console.WriteLine($"{10000 - steps} more steps to reach goal.");
            }

        }
    }
}