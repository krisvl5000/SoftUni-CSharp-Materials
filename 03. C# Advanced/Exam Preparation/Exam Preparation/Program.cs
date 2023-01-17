using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int maxCaffeine = 300;
        int currentCaffeine = 0;
        int caffeineReduction = 30;

        int[] caffeine = Console.ReadLine()
            .Split(", ")
            .Select(int.Parse)
            .ToArray();

        int[] drinks = Console.ReadLine()
            .Split(", ")
            .Select(int.Parse)
            .ToArray();

        while (caffeine.Length > 0 && drinks.Length > 0)
        {
            int caffeineInDrink = caffeine[caffeine.Length - 1] * drinks[0];
            if (currentCaffeine + caffeineInDrink <= maxCaffeine)
            {
                currentCaffeine += caffeineInDrink;
                caffeine = caffeine.Take(caffeine.Length - 1).ToArray();
                drinks = drinks.Skip(1).ToArray();
            }
            else 
            {
                currentCaffeine -= caffeineReduction;
                if (currentCaffeine < 0)
                {
                    currentCaffeine = 0;
                }
                drinks = drinks.Skip(1).Concat(drinks.Take(1)).ToArray();
            }

            drinks = Console.ReadLine()
            .Split(", ")
            .Select(int.Parse)
            .ToArray();
        }

        if (drinks.Length > 0)
        {
            Console.WriteLine("Drinks left: " + string.Join(", ", drinks));
        }
        else
        {
            Console.WriteLine("At least Stamat wasn't exceeding the maximum caffeine.");
        }
        Console.WriteLine("Stamat is going to sleep with " + currentCaffeine + " mg caffeine.");
    }
}
