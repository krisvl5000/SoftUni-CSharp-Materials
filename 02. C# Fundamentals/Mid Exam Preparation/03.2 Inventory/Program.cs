using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine().Split(", ").ToList();

            string[] input = Console.ReadLine().Split(" - ").ToArray();

            while (input[0] != "Craft!")
            {
                string command = input[0];

                if (command == "Collect")
                {
                    string item = input[1];

                    if (!DoesItemExist(list, item))
                    {
                        list.Add(item);
                    }
                    else
                    {
                        input = Console.ReadLine().Split(" - ").ToArray();
                        continue;
                    }
                }
                else if (command == "Drop")
                {
                    string item = input[1];

                    if (DoesItemExist(list, item))
                    {
                        list.Remove(item);
                    }
                    else
                    {
                        input = Console.ReadLine().Split(" - ").ToArray();
                        continue;
                    }
                }
                else if (command == "Combine Items")
                {
                    string[] oldAndNew = input[1].Split(":").ToArray();

                    string oldItem = oldAndNew[0];

                    if (DoesItemExist(list, oldItem))
                    {
                        list.Insert(list.IndexOf(oldItem) + 1, oldAndNew[1]);
                    }
                    else
                    {
                        input = Console.ReadLine().Split(" - ").ToArray();
                        continue;
                    }
                }
                else if (command == "Renew")
                {
                    string item = input[1];

                    if (DoesItemExist(list, item))
                    {
                        list.Add(item);
                        list.Remove(item);
                    }
                    else
                    {
                        input = Console.ReadLine().Split(" - ").ToArray();
                        continue;
                    }
                }

                if (command == "Craft!")
                {
                    break;
                }

                input = Console.ReadLine().Split(" - ").ToArray();
            }

            Console.WriteLine(String.Join(", ", list));

        }

        static bool DoesItemExist(List<string> list, string item)
        {
            return list.Contains(item);
        }
    }
}