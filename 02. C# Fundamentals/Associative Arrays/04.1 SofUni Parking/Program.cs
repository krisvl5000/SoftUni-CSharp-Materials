using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                string command = input[0];
                string username = input[1];

                if (command == "register")
                {
                    string licensePlate = input[2];

                    if (!dict.ContainsKey(username))
                    {
                        dict[username] = licensePlate;
                        Console.WriteLine($"{username} registered " +
                            $"{licensePlate} successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: already " +
                            $"registered with plate number {licensePlate}");
                    }

                }
                else if (command == "unregister")
                {
                    if (!dict.ContainsKey(username))
                    {
                        Console.WriteLine($"ERROR: user {username} not found");
                    }
                    else
                    {
                        Console.WriteLine($"{username} unregistered successfully");
                        dict.Remove(username);
                    }
                    
                }
            }

            foreach (var person in dict)
            {
                Console.WriteLine($"{person.Key} => {person.Value}");
            }

        }
    }
}