using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();

            string[] input;

            while (true)
            {
                input = Console.ReadLine().Split().ToArray();

                if (input[0] == "end")
                {
                    break;
                }
                else
                {
                    if (input[0] == "Add")
                    {
                        int newNum = int.Parse(input[1]);
                        list.Add(newNum);
                    }
                    else if (input[0] == "Remove")
                    {
                        int newNum = int.Parse(input[1]);
                        list.Remove(newNum);
                    }
                    else if (input[0] == "RemoveAt")
                    {
                        int newNum = int.Parse(input[1]);
                        list.RemoveAt(newNum);
                    }
                    else if (input[0] == "Insert")
                    {
                        int newNum = int.Parse(input[1]);
                        int newNum2 = int.Parse(input[2]);
                        list.Insert(newNum2, newNum);
                    }
                }
            }
            Console.WriteLine(String.Join(' ', list));

        }
    }
}