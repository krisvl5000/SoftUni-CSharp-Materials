using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            int counter = 0;

            while (true)
            {    
                if (input == "End of battle")
                {
                    Console.WriteLine($"Won battles: {counter}. Energy left: {energy}");
                    return; 
                }
                else
                {
                    int distance = int.Parse(input);

                    if (distance > energy)
                    {
                        Console.WriteLine($"Not enough energy! " +
                            $"Game ends with {counter} won battles and {energy} energy");
                        return;
                    }
                    
                    energy -= distance;

                    counter++;

                    if (counter % 3 == 0)
                    {
                        energy += counter;
                    }

                    input = Console.ReadLine();
                }
                
            }

        }
    }
}