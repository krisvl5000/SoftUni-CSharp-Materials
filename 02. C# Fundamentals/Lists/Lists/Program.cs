using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string[] namesArray = new string[]
            //{
            //    "Ivan",
            //    "Ivan",
            //    "Teodor",
            //    "Georgi"
            //};
            //                     Array to List
            //List<string> names = new List<string>(namesArray);
            //List<string> names = namesArray.ToList();

            List<string> names = new List<string>()
            {
                "Ivan",
                "Ivan",
                "Teodor",
                "Georgi"
            };
            names.Remove("Ivan");

            Console.WriteLine(names.Remove("Teodor"));

            names.Insert(0, "Maria");

            names.Add("Ceco");

            names.RemoveAt(3);

            Console.WriteLine(string.Join(", ", names));

            //             How to read lists from the console

            int length = int.Parse(Console.ReadLine());
            List<int> list = new List<int>();

            for (int i = 0; i < length; i++)
            {
                int number = int.Parse(Console.ReadLine());
                list.Add(number);
            }

            //                  Easier way
            string values = Console.ReadLine();
            List<string> items = values.Split(' ').ToList();

            //                 Easiest way
            List<int> list2 = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
        }
    }
}