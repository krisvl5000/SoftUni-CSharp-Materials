using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> ingredientsQueue = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Stack<int> freshnessStack = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            var dict = new Dictionary<string, int>();
            dict.Add("Dipping sauce", 150);
            dict.Add("Green salad", 250);
            dict.Add("Chocolate cake", 300);
            dict.Add("Lobster", 400);

            var mealsMade = new Dictionary<string, int>();

            while (ingredientsQueue.Count > 0 && freshnessStack.Count > 0)
            {
                if (ingredientsQueue.Peek() == 0)
                {
                    ingredientsQueue.Dequeue();
                }

                if (ingredientsQueue.Count == 0)
                {
                    break;
                }

                if (freshnessStack.Count == 0)
                {
                    break;
                }

                int totalFreshness = ingredientsQueue.Peek() * freshnessStack.Peek();
                bool dishWasMade = false;

                foreach (var item in dict)
                {
                    if (totalFreshness == item.Value)
                    {
                        if (!mealsMade.ContainsKey(item.Key))
                        {
                            mealsMade.Add(item.Key, 0);
                        }

                        mealsMade[item.Key]++;
                        dishWasMade = true;

                        ingredientsQueue.Dequeue();
                        freshnessStack.Pop();
                        break;
                    }
                }

                if (!dishWasMade)
                {
                    freshnessStack.Pop();
                    int newIngredient = ingredientsQueue.Dequeue() + 5;
                    ingredientsQueue.Enqueue(newIngredient);
                }
            }

            int totalMealsMade = 0;

            foreach (var item in mealsMade)
            {
                totalMealsMade += item.Value;
            }

            if (totalMealsMade >= 4 && mealsMade.Count == 4)
            {
                Console.WriteLine($"Applause! The judges are fascinated by " +
                    $"your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }

            int ingredientsLeft = 0;

            if (ingredientsQueue.Count > 0)
            {
                while (ingredientsQueue.Count != 0)
                {
                    ingredientsLeft += ingredientsQueue.Dequeue();
                }

                Console.WriteLine($"Ingredients left: {ingredientsLeft}");
            }

            var orderedMealsMade = mealsMade
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key);

            foreach (var item in orderedMealsMade)
            {
                Console.WriteLine($" # {item.Key} --> {item.Value}");
            }
        }
    }
}