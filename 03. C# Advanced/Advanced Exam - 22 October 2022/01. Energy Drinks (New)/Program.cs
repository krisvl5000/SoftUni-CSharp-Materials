using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] miligramsOfCaffeine = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] energyDrinks = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int totalCaffeine = 0;
            const int MAXCAFFEINE = 300;

            Stack<int> caffeineStack = new Stack<int>(miligramsOfCaffeine);
            Queue<int> drinksQueue = new Queue<int>(energyDrinks);

            while (caffeineStack.Count > 0 && drinksQueue.Count > 0)
            {
                int caffeineInjested = caffeineStack.Peek() * drinksQueue.Peek();

                if (caffeineInjested + totalCaffeine <= MAXCAFFEINE)
                {
                    caffeineStack.Pop();
                    drinksQueue.Dequeue();

                    totalCaffeine += caffeineInjested;
                }
                else
                {
                    caffeineStack.Pop();
                    int temp = drinksQueue.Dequeue();
                    drinksQueue.Enqueue(temp);

                    totalCaffeine -= 30;

                    if (totalCaffeine < 0)
                    {
                        totalCaffeine = 0;
                    }
                }
            }

            if (drinksQueue.Count > 0)
            {
                Console.WriteLine($"Drinks left: {String.Join(", ", drinksQueue)}");
            }
            else
            {
                Console.WriteLine("At least Stamat wasn't exceeding " +
                    "the maximum caffeine.");
            }

            Console.WriteLine($"Stamat is going to " +
                $"sleep with {totalCaffeine} mg caffeine.");
        }
    }
}
