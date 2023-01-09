using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine().Split().ToList();

            string[] input = Console.ReadLine().Split().ToArray();

            int counter = 0;

            while (input[0] != "end")
            {
                counter++;

                int firstIndex = int.Parse(input[0]);
                int secondIndex = int.Parse(input[1]);

                if (!IsIndexValid(list, input))
                {
                    string itemToAdd = $"-{counter}a";
                    int middleOfElements = list.Count / 2;

                    list.Insert(middleOfElements, itemToAdd);
                    list.Insert(middleOfElements + 1, itemToAdd);

                    Console.WriteLine("Invalid input! " +
                        "Adding additional elements to the board");

                    input = Console.ReadLine().Split().ToArray();
                    continue;
                }

                if (list[firstIndex] == list[secondIndex])
                {
                    string itemToRemove = list[firstIndex];

                    list.Remove(itemToRemove);
                    list.Remove(itemToRemove);

                    Console.WriteLine($"Congrats! " +
                        $"You have found matching elements - {itemToRemove}!");
                }
                else if (list[firstIndex] != list[secondIndex])
                {
                    Console.WriteLine("Try again!");

                    input = Console.ReadLine().Split().ToArray();
                    continue;
                }

                if (list.Count == 0)
                {
                    Console.WriteLine($"You have won in {counter} turns!");
                    return;
                }

                input = Console.ReadLine().Split().ToArray();
            }

            Console.WriteLine("Sorry you lose :(");
            Console.WriteLine(String.Join(" ", list));

        }

        static bool IsIndexValid(List<string> list, string[] input)
        {
            int firstIndex = int.Parse(input[0]);
            int secondIndex = int.Parse(input[1]);

            if (firstIndex < 0 || secondIndex < 0
                || firstIndex >= list.Count || secondIndex >= list.Count
                || firstIndex == secondIndex)
            {
                return false;
            }

            return true;
        }
    }
}