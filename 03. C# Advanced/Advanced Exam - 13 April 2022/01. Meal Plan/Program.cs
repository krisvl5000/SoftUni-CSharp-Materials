using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> mealQueue = new Queue<string>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries));

            Stack<int> calorieStack = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            var dict = new Dictionary<string, int>();

            dict.Add("salad", 350);
            dict.Add("soup", 490);
            dict.Add("pasta", 680);
            dict.Add("steak", 790);

            int mealsEaten = 0;

            while (mealQueue.Count > 0 && calorieStack.Count > 0 && calorieStack.Peek() > 0)
            {
                int dailyCalories = calorieStack.Pop();
                string meal = mealQueue.Dequeue();
                mealsEaten++;

                int currentMealCalories = dict[meal];
                dailyCalories -= currentMealCalories;

                while (dailyCalories <= 0)
                {
                    if (calorieStack.Count == 0)
                    {
                        break;
                    }

                    dailyCalories += calorieStack.Pop();
                }

                calorieStack.Push(dailyCalories);
            }

            if (mealQueue.Count == 0)
            {
                Console.WriteLine($"John had {mealsEaten} meals.");
                Console.WriteLine($"For the next few days, he can eat " +
                    $"{String.Join(", ", calorieStack)} calories.");
            }
            else
            {
                Console.WriteLine($"John ate enough, he had {mealsEaten} meals.");
                Console.WriteLine($"Meals left: {String.Join(", ", mealQueue)}.");
            }

        }
    }
}