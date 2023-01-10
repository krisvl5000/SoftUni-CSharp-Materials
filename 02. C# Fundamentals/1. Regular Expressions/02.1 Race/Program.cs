using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> participants = Console.ReadLine().Split(", ").ToList();

            var map = new Dictionary<string, int>();

            string namePattern = @"[A-Za-z+]";
            string kmPattern = @"[0-9]";

            string input;
            while ((input = Console.ReadLine()) != "end of race")
            {
                MatchCollection nameArgs = Regex.Matches(input, namePattern);

                StringBuilder sb = new StringBuilder();
                foreach (Match item in nameArgs)
                {
                    sb.Append(item.Value);
                }

                MatchCollection kmArgs = Regex.Matches(input, kmPattern);

                int kmRan = 0;
                foreach (Match km in kmArgs)
                {
                    kmRan += int.Parse(km.Value);
                }

                string name = sb.ToString();

                if (participants.Contains(name))
                {
                    if (!map.ContainsKey(name))
                    {
                        map[name] = 0;
                    }

                    map[name] += kmRan;
                }
                else
                {
                    continue;
                }
            }

            int i = 1;
            foreach (var person in map.OrderByDescending(x => x.Value))
            {
                if (i == 1)
                {
                    Console.WriteLine($"1st place: {person.Key}");
                }
                else if (i == 2)
                {
                    Console.WriteLine($"2nd place: {person.Key}");
                }
                else if (i == 3)
                {
                    Console.WriteLine($"3rd place: {person.Key}");
                    break;
                }

                i++;
            }

        }
    }
}