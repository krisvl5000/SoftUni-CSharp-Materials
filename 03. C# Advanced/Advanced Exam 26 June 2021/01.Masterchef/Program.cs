using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> ingredients = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Stack<int> freshness = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            var dict = new Dictionary<string, int>();
            dict.Add("Dipping Sauce", 150);
            dict.Add("Green salad", 250);
            dict.Add("Chocolate cake", 300);
            dict.Add("Lobster", 400);

            var mealsMade = new Dictionary<string, int>();

            while (ingredients.Count > 0 && freshness.Count > 0)
            {
                int totalFreshness = ingredients.Peek() * freshness.Peek();
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

                        ingredients.Dequeue();
                        freshness.Pop();
                        break;
                    }
                }

                if (!dishWasMade)
                {
                    freshness.Pop();
                    int newIngredient = ingredients.Dequeue() + 5;
                    ingredients.Enqueue(newIngredient);
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

            if (ingredients.Count > 0)
            {
                while (ingredients.Count != 0)
                {
                    ingredientsLeft += ingredients.Dequeue();
                }

                Console.WriteLine($"Ingredients left: {ingredientsLeft}");
            }

            var orderedMealsMade = mealsMade
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key);

            foreach (var item in orderedMealsMade)
            {
                Console.WriteLine($"# {item.Key}--> {item.Value}");
            }
        }
    }
}