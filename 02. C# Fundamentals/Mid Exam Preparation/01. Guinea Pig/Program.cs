using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double food = double.Parse(Console.ReadLine());
            double hay = double.Parse(Console.ReadLine());
            double cover = double.Parse(Console.ReadLine());
            double weigth = double.Parse(Console.ReadLine());

            double initialFood = food;

            int counter = 0;

            while (true)
            {
                food -= 0.3;

                if (food <= 0.0 || food > initialFood)
                {
                    Console.WriteLine("Merry must go to the pet store!");
                    return;
                }

                counter++;
                
                if (counter % 2 == 0)
                {
                    hay -= food * 0.05;

                    if (hay <= 0.0)
                    {
                        Console.WriteLine("Merry must go to the pet store!");
                        return;
                    }
                }
                
                if (counter % 3 == 0)
                {
                    cover -= weigth / 3.0; // if this doesn't work, try weight / 3

                    if (cover <= 0.0)
                    {
                        Console.WriteLine("Merry must go to the pet store!");
                        return;
                    }
                }

                
                if (counter == 30 && food > 0.0)
                {
                    Console.WriteLine($"Everything is fine! Puppy is happy!" +
                        $" Food: {food:F2}, Hay: {hay:F2}, Cover: {cover:F2}.");
                    return;
                }
                
            }

        }
    }
}