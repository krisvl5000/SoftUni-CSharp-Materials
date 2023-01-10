using System;
using System.Linq;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string key = Console.ReadLine();

            string[] input = Console.ReadLine().Split(">>>");

            while (input[0] != "Generate")
            {
                string command = input[0];

                if (command == "Contains")
                {
                    string substring = input[1];

                    if (key.Contains(substring))
                    {
                        Console.WriteLine($"{key} contains {substring}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }
                }
                else if (command == "Flip")
                {
                    string type = input[1];
                    int startIndex = int.Parse(input[2]);
                    int endIndex = int.Parse(input[3]);

                    string substringToChange = key
                        .Substring(startIndex, endIndex - startIndex);

                    if (type == "Upper")
                    {
                        string newSubstring = string.Empty;

                        foreach (var ch in substringToChange)
                        {
                            newSubstring += char.ToUpper(ch);
                        }

                        key = key.Remove(startIndex, endIndex - startIndex);
                        key = key.Insert(startIndex, newSubstring);
                    }
                    else if (type == "Lower")
                    {
                        string newSubstring = string.Empty;

                        foreach (var ch in substringToChange)
                        {
                            newSubstring += char.ToLower(ch);
                        }

                        key = key.Remove(startIndex, endIndex - startIndex);
                        key = key.Insert(startIndex, newSubstring);
                    }

                    Console.WriteLine(key);
                }
                else if (command == "Slice")
                {
                    int startIndex = int.Parse(input[1]);
                    int endIndex = int.Parse(input[2]);

                    key = key.Remove(startIndex, endIndex - startIndex);

                    Console.WriteLine(key);
                }

                input = Console.ReadLine().Split(">>>");
            }

            Console.WriteLine($"Your activation key is: {key}");

        }
    }
}