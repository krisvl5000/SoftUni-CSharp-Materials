//using System;
//using System.Collections.Generic;
//using System.Linq;

//          //https://judge.softuni.org/Contests/Practice/Index/2305#2

//namespace _01._Hello_Softuni
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            List<int> targets = Console.ReadLine().Split().Select(int.Parse).ToList();
//            string[] input = Console.ReadLine().Split().ToArray();

//            int index;
//            int power;
//            int value;
//            int radius;
//            int target;

//            while (input[0] != "End")
//            {

//                if (input[0] == "Shoot")
//                {
//                    index = int.Parse(input[1]);
//                    power = int.Parse(input[2]);

//                    if (IsIndexValid(targets, index))
//                    {
//                        targets[index] -= power;

//                        if (targets[index] <= 0)
//                        {
//                            targets.Remove(targets[index]);
//                            input = Console.ReadLine().Split().ToArray();
//                            continue;
//                        }
//                        input = Console.ReadLine().Split().ToArray();
//                        continue;
//                    }
//                    else
//                    {
//                        input = Console.ReadLine().Split().ToArray();
//                        continue;
//                    }
//                }
//                else if (input[0] == "Add")
//                {
//                    index = int.Parse(input[1]);
//                    value = int.Parse(input[2]);

//                    if (IsIndexValid(targets, index))
//                    {
//                        targets[index] += value;
//                        input = Console.ReadLine().Split().ToArray();
//                        continue;

//                    }
//                    else
//                    {
//                        Console.WriteLine("Invalid placement!");
//                        input = Console.ReadLine().Split().ToArray();
//                        continue;
//                    }
//                }
//                else if (input[0] == "Strike")
//                {
//                    index = int.Parse(input[1]);
//                    radius = int.Parse(input[2]);

//                    if (IsIndexValid(targets, index, radius))
//                    {
//                        target = targets[index];

//                        for (int i = targets[index]; i <= index + radius; i--)
//                        {
//                            targets.Remove(targets[index]);
//                        }
//                        for (int i = targets[index]; i >= index + radius; i++)
//                        {
//                            targets.Remove(targets[index]);
//                        }

//                        targets.Remove(targets[index]);

//                        input = Console.ReadLine().Split().ToArray();
//                        continue;
//                    }
//                    else
//                    {
//                        Console.WriteLine("Strike missed!");
//                        input = Console.ReadLine().Split().ToArray();
//                        continue;
//                    }    
//                }

//            }

//            Console.WriteLine(String.Join('|', targets));



//        }

//        static bool IsIndexValid(List<int> targets, int index)
//        {
//            return index >=0 && index < targets.Count;
//        }

//        static bool IsIndexValid(List<int> targets, int index, int radius)
//        {
//            return index - radius >=0 && index + radius < targets.Count;
//        }
//    }
//}

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

            string[] input = Console.ReadLine().Split().ToArray();

            
            int target;

            while (input[0] != "End")
            {
                string command = input[0];
                int index = int.Parse(input[1]);

                if (command == "Shoot")
                {
                    if (!IsIndexValid(list, index))
                    {
                        input = Console.ReadLine().Split().ToArray();
                        continue;
                    }

                    int power = int.Parse(input[2]);
                    list[index] -= power;

                    if (list[index] <= 0)
                    {
                        list.Remove(list[index]);
                    }

                }
                else if (command == "Add")
                {
                    if (!IsIndexValid(list, index))
                    {
                        Console.WriteLine("Invalid placement!");
                        input = Console.ReadLine().Split().ToArray();
                        continue;
                    }
                    int value = int.Parse(input[2]);
                    
                    list.Insert(index, value);
                }
                else if (command == "Strike")
                {
                    int radius = int.Parse(input[2]);

                    if (!IsIndexValid(list, index, radius))
                    {
                        Console.WriteLine("Strike missed!");
                        input = Console.ReadLine().Split().ToArray();
                        continue;
                    }

                    List<int> itemsToRemove = new List<int>();

                    for (int i = 0; i > index; i--)
                    {
                        if (list.IndexOf(list[i]) <= radius + index &&
                            list.IndexOf(list[i]) > radius - index)
                        {
                            itemsToRemove.Add(i);
                        }
                                         
                    }

                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list.Contains(itemsToRemove[i]))
                        {
                            list.Remove(i);
                        }
                    }

                }
                input = Console.ReadLine().Split().ToArray();
            }

        }

        static bool IsIndexValid(List<int> list, int index)
        {
            return index >= 0 && index < list.Count;
        }

        static bool IsIndexValid(List<int> list, int index, int radius)
        {
            return index * radius >=0 && index * radius < list.Count;
        }
    }
}