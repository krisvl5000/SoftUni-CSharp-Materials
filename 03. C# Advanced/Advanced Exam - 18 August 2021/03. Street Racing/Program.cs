using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> guestQueue = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Stack<int> platesStack = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            int wastedFood = 0;

            while (guestQueue.Count > 0 && platesStack.Count > 0)
            {
                int guest = guestQueue.Peek();
                int plate = platesStack.Peek();

                if (plate >= guest)
                {
                    wastedFood += plate - guest;
                    guestQueue.Dequeue();
                    platesStack.Pop();
                }
                else
                {
                    int lastPositiveValue = guest;
                    int lastPlateValue = 0;

                    while (guest > 0)
                    {
                        lastPlateValue = platesStack.Pop();
                        guest -= lastPlateValue;

                        if (guest > 0)
                        {
                            lastPositiveValue = guest;
                        }
                        
                    }
                    wastedFood += lastPlateValue - lastPositiveValue;
                    guestQueue.Dequeue();
                }
            }

            if (guestQueue.Count > 0)
            {
                Console.WriteLine($"Guests: {String.Join(" ", guestQueue)}");
            }
            else
            {
                Console.WriteLine($"Plates: {String.Join(" ", platesStack)}");
            }

            Console.WriteLine($"Wasted grams of food: {wastedFood}");
        }
    }
}