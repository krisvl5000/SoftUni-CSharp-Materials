using System;
using System.Linq;
using System.Collections.Generic;

namespace _07._Parking_Lot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> set = new HashSet<string>();
            string[] input = Console.ReadLine().Split(", ");

            while (input[0] != "END")
            {
                string command = input[0];
                string number = input[1];

                if (command == "IN")
                {
                    set.Add(number);
                }
                else if (command == "OUT")
                {
                    set.Remove(number);
                }

                input = Console.ReadLine().Split(", ");
            }

            if (set.Count > 0)
            {
                foreach (var item in set)
                {
                    Console.WriteLine(item);
                }
            }
            else

            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
