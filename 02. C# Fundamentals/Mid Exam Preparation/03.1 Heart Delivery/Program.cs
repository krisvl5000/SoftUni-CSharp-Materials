//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace _01._Hello_Softuni
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            List<int> list = Console.ReadLine().Split("@").Select(int.Parse).ToList();
//            List<int> initialList = list;

//            string[] input = Console.ReadLine().Split().ToArray();

//            int jumpLength;
//            int heartsNeeded;
//            int lastPositionIndex = 0;
//            int index;

//            int counter = 0;

//            while (input[0] != "Love!")
//            {
//                jumpLength = int.Parse(input[1]);

//                for (int i = 0; i <= jumpLength; i++)
//                {
//                    heartsNeeded = list[i];
//                    index = i;

//                    if (i != jumpLength)
//                    {
//                        continue;
//                    }
//                    else
//                    {
//                        if (jumpLength >= list.Count)
//                        {
//                            i = 0;
//                        }

//                        if (heartsNeeded == 0)
//                        {
//                            Console.WriteLine($"Place {index} already had Valentine's day.");
//                            break;
//                        }

//                        heartsNeeded -= 2;

//                        if (heartsNeeded == 0)
//                        {
//                            Console.WriteLine($"Place {index} has Valentine's day.");
//                            break;
//                        }

//                        lastPositionIndex = index;

//                    }

//                }

//                input = Console.ReadLine().Split().ToArray();

//            }

//            for (int i = 0; i < list.Count; i++)
//            {
//                if (list[i] != initialList[i])
//                {
//                    counter++;
//                }
//            }

//            Console.WriteLine($"Cupid's last position was {lastPositionIndex}.");

//            if (counter == 0)
//            {
//                Console.WriteLine("Mission was successful.");
//            }
//            else
//            {
//                Console.WriteLine($"Cupid has failed {counter} places.");
//            }

//        }
//    }
//}

using System;

//https://judge.softuni.org/Contests/Practice/Index/2031#2

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {


        }
    }
}