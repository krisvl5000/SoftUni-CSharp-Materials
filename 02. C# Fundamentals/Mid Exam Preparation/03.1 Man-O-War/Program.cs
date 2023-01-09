using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> pirateShip = Console.ReadLine()
                .Split(">").Select(int.Parse).ToList();

            List<int> warShip = Console.ReadLine()
                .Split(">").Select(int.Parse).ToList();

            int maxHealth = int.Parse(Console.ReadLine());

            string[] input = Console.ReadLine().Split().ToArray();

            while (input[0] != "Retire")
            {
                string command = input[0];

                if (command == "Fire")
                {
                    int index = int.Parse(input[1]);
                    int damage = int.Parse(input[2]);

                    if (IsIndexValidWar(warShip, index))
                    {
                        warShip[index] -= damage;

                        if (warShip[index] <= 0)
                        {
                            Console.WriteLine("You won! The enemy ship has sunken.");
                            return;
                        }
                    }
                    else
                    {
                        input = Console.ReadLine().Split().ToArray();
                        continue;
                    }
                }
                else if (command == "Defend")
                {
                    int startIndex = int.Parse(input[1]);
                    int endIndex = int.Parse(input[2]);
                    int damage = int.Parse(input[3]);

                    if (IsIndexValidPirate(pirateShip, startIndex, endIndex))
                    {
                        for (int i = startIndex; i <= endIndex; i++)
                        {
                            pirateShip[i] -= damage;

                            if (pirateShip[i] <= 0)
                            {
                                Console.WriteLine("You lost! The pirate ship has sunken.");
                                return;
                            }
                        }
                    }
                    else
                    {
                        input = Console.ReadLine().Split().ToArray();
                        continue;
                    }
                }
                else if (command == "Repair")
                {
                    int index = int.Parse(input[1]);
                    int healthToRestore = int.Parse(input[2]);

                    if (IsIndexValidPirate(pirateShip, index))
                    {
                        pirateShip[index] += healthToRestore;

                        if (pirateShip[index] > maxHealth)
                        {
                            pirateShip[index] = maxHealth;
                        }
                    }
                }
                else if (command == "Status")
                {
                    int counter = 0;

                    foreach (var section in pirateShip)
                    {
                        if (section < maxHealth * 0.2)
                        {
                            counter++;
                        }
                    }

                    Console.WriteLine($"{counter} sections need repair.");
                }

                input = Console.ReadLine().Split().ToArray();
            }

            int pirateShipSum = 0;
            foreach (var section in pirateShip)
            {
                pirateShipSum += section;
            }

            int warShipSum = 0;
            foreach (var section in warShip)
            {
                warShipSum += section;
            }

            Console.WriteLine($"Pirate ship status: {pirateShipSum}");
            Console.WriteLine($"Warship status: {warShipSum}");

        }

        static bool IsIndexValidWar(List<int> warShip, int index)
        {
            return index >= 0 && index < warShip.Count;
        }

        static bool IsIndexValidPirate(List<int> pirateShip, int startIndex, int endIndex)
        {
            return startIndex >= 0 && startIndex < pirateShip.Count 
                  && endIndex >= 0 && endIndex < pirateShip.Count
                  && startIndex < endIndex;
        }

        static bool IsIndexValidPirate(List<int> pirateShip, int index)
        {
            return (index >= 0 && index < pirateShip.Count);
        }
    }
}