using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Sets_and_Dictionaries_Advanced
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Only C# calls KeyValuePair structures "Dictionaries"
            //Sorted dictionaries are dictionaries that are sorted by Key
            //However, if we want to print the contents in reverse order, we need to use
            //the comparer method

            SortedDictionary<int, string> map = new SortedDictionary<int, string>
                (new NumbersComparer());

            map.Add(13, "Peshata");
            map.Add(12, "Dimitrichko");
            map.Add(3, "Gogi");
            map.Add(24, "Bobi");

            foreach (var item in map)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }

        class NumbersComparer : IComparer<int>
        {
            public int Compare([AllowNull] int x, [AllowNull] int y)
            {
                return y - x;
            }
        }
    }
}
