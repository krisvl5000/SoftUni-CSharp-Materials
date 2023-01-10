using System;
using System.Linq;
using System.Collections.Generic;

namespace HashSet_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Much faster than List<T>, its not used to iterate through, but to 
            // check whether something is already contained within it
            HashSet<int> set = new HashSet<int>();
            set.Add(5);
            set.Add(3);
            set.Add(7);
            set.Add(2);
            set.Add(1);

            foreach (var item in set)
            {
                Console.WriteLine(item);
            }
        }
    }
}
