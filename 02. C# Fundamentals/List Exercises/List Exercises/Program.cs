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
            int maxCap = int.Parse(Console.ReadLine());

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
                    if (input.Length == 2)
                    {
                        int toAdd = int.Parse(input[1]);
                        list.Add(toAdd);
                    }
                    else if (input.Length == 1)
                    {
                        int addition = int.Parse(input[0]);

                        for (int i = 0; i < list.Count; i++)
                        {
                            if (addition + list[i] < maxCap)
                            {
                                list[i] += addition;
                                continue;
                            }
                            else if (addition + list[i] < maxCap)
                            {
                                list[+ 1] = addition + list[+ 1]; //no, it doesnt have anything to do
                                break;
                            }
                        }
                    }
                }               
            }
            Console.WriteLine(string.Join(" ", list));

        }
    }
}