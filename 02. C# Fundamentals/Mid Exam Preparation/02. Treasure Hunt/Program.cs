using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine().Split("|").ToList();

            string[] input = Console.ReadLine().Split().ToArray();

            while (input[0] != "Yohoho!")
            {
                string command = input[0];

                if (command == "Loot")
                {
                    string[] loot = input.Skip(1).ToArray();

                    for (int i = 0; i < loot.Length; i++)
                    {
                        if (!list.Contains(loot[i]))
                        {
                            list.Insert(0, loot[i]);
                        }
                    }
                }
                else if (command == "Drop")
                {
                    int index = int.Parse(input[1]);

                    if (IsIndexValid(list, index))
                    {
                        string item = list[index];
                        list.RemoveAt(index);
                        list.Add(item);
                    }
                    else
                    {
                        input = Console.ReadLine().Split().ToArray();
                        continue;
                    }
                }
                else if (command == "Steal")
                {
                    List<string> stolenItems = new List<string>();
                    int count = int.Parse(input[1]);

                    if (list.Count > count)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            stolenItems.Add(list.Last());
                            list.Remove(list.Last());
                        }
                    }
                    else
                    {
                        for (int i = 0; i < list.Count; i++)
                        {
                            stolenItems.Add(list[i]);
                        }
                        list.Clear();

                        stolenItems.Reverse();
                    }

                    stolenItems.Reverse();
                    Console.WriteLine(String.Join(", ", stolenItems));
                }

                input = Console.ReadLine().Split().ToArray();
            }

            if (list.Count > 0)
            {
                double totalGain = 0;

                for (int i = 0; i < list.Count; i++)
                {
                    totalGain += list[i].Length;
                }

                double averageGain = totalGain / list.Count;

                Console.WriteLine($"Average treasure gain: {averageGain:F2} pirate credits.");
            }
            else
            {
                Console.WriteLine("Failed treasure hunt.");
            }

        }

        static bool IsIndexValid(List<string> list, int index)
        {
            return index > 0 && index < list.Count;
        }
    }
}