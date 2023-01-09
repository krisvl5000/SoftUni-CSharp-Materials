using System;
using System.Linq;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] rooms = Console.ReadLine().Split("|").ToArray();

            int health = 100;
            int bitcoins = 0;

            int roomCounter = 0;
            int healCounter = 0;

            for (int i = 0; i < rooms.Length; i++)
            {
                string[] input = rooms[i].Split();

                string command = input[0];

                roomCounter++;

                if (command == "potion")
                {
                    int healthToRestore = int.Parse(input[1]);
                    while (health < 100 && healthToRestore > 0)
                    {
                        healthToRestore--;
                        health++;
                        healCounter++;
                    }

                    Console.WriteLine($"You healed for {healCounter} hp.");
                    Console.WriteLine($"Current health: {health} hp.");
                    healCounter = 0;
                }
                else if (command == "chest")
                {
                    int bitcoinsFound = int.Parse(input[1]);
                    bitcoins += bitcoinsFound;
                    Console.WriteLine($"You found {bitcoinsFound} bitcoins.");
                }
                else
                {
                    string monster = input[0];
                    int attack = int.Parse(input[1]);

                    health -= attack;

                    if (health > 0)
                    {
                        Console.WriteLine($"You slayed {monster}.");
                    }
                    else
                    {
                        Console.WriteLine($"You died! Killed by {monster}.");
                        Console.WriteLine($"Best room: {roomCounter}");
                        return;
                    }
                }
            }

            Console.WriteLine("You've made it!");
            Console.WriteLine($"Bitcoins: {bitcoins}");
            Console.WriteLine($"Health: {health}");

        }
    }
}