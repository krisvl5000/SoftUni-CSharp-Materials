using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> caffeineStack = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Queue<int> enerdyDrinkQueue = new Queue<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            const int MAX_CAFFEINE = 300;

            int initialCaffeine = 0;

            while (true)
            {
                if (caffeineStack.Count == 0)
                {
                    break;
                }

                if (enerdyDrinkQueue.Count == 0)
                {
                    break;
                }

                int caffeine = caffeineStack.Peek() * enerdyDrinkQueue.Peek();

                if (caffeine + initialCaffeine <= MAX_CAFFEINE)
                {
                    caffeineStack.Pop();
                    enerdyDrinkQueue.Dequeue();
                    initialCaffeine += caffeine;
                }
                else
                {
                    caffeineStack.Pop();
                    enerdyDrinkQueue.Enqueue(enerdyDrinkQueue.Dequeue());
                    initialCaffeine -= 30;

                    if (initialCaffeine < 0)
                    {
                        initialCaffeine = 0;
                    }
                }
            }

            if (enerdyDrinkQueue.Count > 0)
            {
                Console.WriteLine($"Drinks left: {String.Join(", ", enerdyDrinkQueue)}");
            }
            else
            {
                Console.WriteLine("At least Stamat wasn't exceeding " +
                    "the maximum caffeine.");
            }

            Console.WriteLine($"Stamat is going to sleep with " +
                $"{initialCaffeine} mg caffeine.");

        }
    }
}