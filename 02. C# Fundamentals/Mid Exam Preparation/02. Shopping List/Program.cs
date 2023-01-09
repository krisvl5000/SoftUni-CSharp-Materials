using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine().Split("!").ToList();

            string[] input = Console.ReadLine().Split().ToArray();

            while (input[0] != "Go" && input[1] != "Shopping!")
            {
                string command = input[0];

                if (command == "Urgent")
                {
                    string item = input[1];

                    if (!list.Contains(item))
                    {
                        list.Insert(0, item);
                    }
                    else
                    {
                        input = Console.ReadLine().Split().ToArray();
                        continue;
                    }
                }
                else if (command == "Unnecessary")
                {
                    string item = input[1];

                    if (list.Contains(item))
                    {
                        list.Remove(item);
                    }
                    else
                    {
                        input = Console.ReadLine().Split().ToArray();
                        continue;
                    }
                }
                else if (command == "Correct")
                {
                    string oldItem = input[1];
                    string newItem = input[2];

                    if (list.Contains(oldItem))
                    {
                        list.Insert(list.IndexOf(oldItem), newItem);
                        list.Remove(oldItem);
                    }
                    else
                    {
                        input = Console.ReadLine().Split().ToArray();
                        continue;
                    }
                }
                else if (command == "Rearrange")
                {
                    string item = input[1];
                    
                    if (list.Contains(item))
                    {
                        list.Remove(item);
                        list.Add(item);
                    }
                    else
                    {
                        input = Console.ReadLine().Split().ToArray();
                        continue;
                    }
                }

                input = Console.ReadLine().Split().ToArray();
                continue;
            }

            Console.WriteLine(String.Join(", ", list));

        }
    }
}