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

                if (input[0] == "End")
                {
                    break;
                }
                else
                {
                    if (input[0] == "Add")
                    {
                        int toAdd = int.Parse(input[1]);
                        list.Add(toAdd);
                    }
                    else if (input[0] == "Insert")
                    {
                        int size = int.Parse(input[2]);

                        if (!IsIndexValid(list, size))
                        {
                            Console.WriteLine("Invalid index");
                            continue;
                        }
                        else
                        {
                            int index = int.Parse(input[1]);
                            int num = int.Parse(input[2]);

                            list.Insert(num, index);
                        }

                    }
                    else if (input[0] == "Remove")
                    {
                        int size = int.Parse(input[1]);

                        if (!IsIndexValid(list, size))
                        {
                            Console.WriteLine("Invalid index");
                            continue;
                        }
                        else
                        {
                            list.RemoveAt(int.Parse(input[1]));
                        }

                    }
                    else if (input[0] == "Shift")
                    {
                        string direction = input[1];
                        int count = int.Parse(input[2]);

                        if (direction == "left")
                        {
                            ShiftLeft(list, count);
                        }
                       else if (direction == "right")
                        {
                            ShiftRight(list, count);
                        }
                    }
                }
            }

            Console.WriteLine(String.Join(" ", list));

        }

        static void ShiftLeft(List<int> list, int count)
        {
            int realPerformedCount = count % list.Count;

            for (int i = 0; i < realPerformedCount; i++)
            {
                int firstElement = list[0];
                list.Remove(firstElement);
                list.Add(firstElement);
            }
        }

        static void ShiftRight(List<int> list, int count)
        {
            int realPerformedCount = count % list.Count;

            for (int i = 0; i < realPerformedCount; i++)
            {
                int lastElement = list[list.Count - 1];
                list.RemoveAt(list.Count - 1);
                list.Insert(0, lastElement);
            }
        }

        static bool IsIndexValid(List<int> list, int size)
         {
            if (size >= list.Count || size < 0)
            {
                return false;
            }
            else
            {
                return true;
            }          
        }
    }
}
