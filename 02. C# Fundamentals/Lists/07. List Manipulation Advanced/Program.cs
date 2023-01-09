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
            List<int> initialList = list;

            string[] input;

            int changes = 0;

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
                        changes++;
                    }
                    else if (input[0] == "Remove")
                    {
                        int newNum = int.Parse(input[1]);
                        list.Remove(newNum);
                        changes++;
                    }
                    else if (input[0] == "RemoveAt")
                    {
                        int newNum = int.Parse(input[1]);
                        list.RemoveAt(newNum);
                        changes++;
                    }
                    else if (input[0] == "Insert")
                    {
                        int newNum = int.Parse(input[1]);
                        int newNum2 = int.Parse(input[2]);
                        list.Insert(newNum2, newNum);
                        changes++;
                    }
                    else if (input[0] == "Contains")
                    {
                        int newNum = int.Parse(input[1]);
                        if (list.Contains(newNum))
                        {
                            Console.WriteLine("Yes");
                        }
                        else
                        {
                            Console.WriteLine("No such number");
                        }

                    }
                    else if (input[0] == "PrintEven")
                    {
                        List<int> newList = new List<int>();

                        for (int i = 0; i < list.Count; i++)
                        {                           
                            if (list[i] % 2 == 0)
                            {
                                newList.Add(list[i]);
                            }
                        }
                        Console.WriteLine(String.Join(" ", newList));
                    }
                    else if (input[0] == "PrintOdd")
                    {
                        List<int> newList = new List<int>();

                        for (int i = 0; i < list.Count; i++)
                        {
                            if (list[i] % 2 == 1)
                            {
                                newList.Add(list[i]);
                            }
                        }
                        Console.WriteLine(String.Join(" ", newList));
                    }
                    else if (input[0] == "GetSum")
                    {
                        int sum = 0;

                        for (int i = 0; i < list.Count; i++)
                        {
                            sum += list[i];
                        }
                        Console.WriteLine(sum);
                    }
                    else if (input[0] == "Filter")
                    {
                        if (input[1] == ">" || input[1] == "<")
                        {
                            int num = int.Parse(input[2]);

                            if (input[1] == "<")
                            {
                                List<int> newList = new List<int>();

                                for (int i = 0; i < list.Count; i++)
                                {
                                    if (list[i] < num)
                                    {
                                        newList.Add(list[i]);
                                    }
                                }
                                Console.WriteLine(String.Join(" ", newList));

                            }
                            else if (input[1] == ">")
                            {
                                List<int> newList = new List<int>();

                                for (int i = 0; i < list.Count; i++)
                                {
                                    if (list[i] > num)
                                    {
                                        newList.Add(list[i]);
                                    }
                                }
                                Console.WriteLine(String.Join(" ", newList));
                            }
                        }
                        else
                        {
                            if (input[1] == ">=")
                            {
                                int num = int.Parse(input[2]);
                                List<int> newList = new List<int>();

                                for (int i = 0; i < list.Count; i++)
                                {
                                    if (list[i] >= num)
                                    {
                                        newList.Add(list[i]);
                                    }
                                }
                                Console.WriteLine(String.Join(" ", newList));
                            }
                            else if (input[1] == "<=")
                            {
                                int num = int.Parse(input[2]);
                                List<int> newList = new List<int>();

                                for (int i = 0; i < list.Count; i++)
                                {
                                    if (list[i] <= num)
                                    {
                                        newList.Add(list[i]);
                                    }
                                }
                                Console.WriteLine(String.Join(" ", newList));
                            }
                        }
                    }
                }
            }
            if (changes > 0)
            {
                Console.WriteLine(String.Join(' ', list));
            }
            else
            {
                return;
            }    

        }
    }
}