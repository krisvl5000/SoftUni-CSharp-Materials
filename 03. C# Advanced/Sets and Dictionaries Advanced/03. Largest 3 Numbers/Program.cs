using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._Largest_3_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            //int[] orderedArr = arr.OrderByDescending(x => x).ToArray();

            //if (orderedArr.Length > 3)
            //{
            //    for (int i = 0; i < 3; i++)
            //    {
            //        Console.Write(orderedArr[i] + " ");
            //    }
            //}
            //else
            //{
            //    Console.WriteLine(String.Join(" ", orderedArr));
            //}

            //                           Quicker way

            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] newArr = arr.OrderByDescending(x => x).Take(3).ToArray();
            Console.WriteLine(String.Join(" ", newArr));
        }
    }
}
