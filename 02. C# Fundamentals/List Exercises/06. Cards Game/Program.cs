using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> firstHand = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> secondHand = Console.ReadLine().Split().Select(int.Parse).ToList();

            int sum = 0;

            while (true)
            {                
                    if (firstHand.Count == 0)
                    {
                        Console.WriteLine($"Second player wins! Sum: {secondHand.Sum()}");
                        return;
                    }
                    else if (secondHand.Count == 0)
                    {
                        Console.WriteLine($"First player wins! Sum: {firstHand.Sum()}");
                        return;
                    }

                    if (firstHand[0] > secondHand[0]) // first hand wins the hand
                    {                       
                        firstHand.Add(firstHand[0]);
                        firstHand.RemoveAt(0);
                        firstHand.Add(secondHand[0]);
                        secondHand.Remove(secondHand[0]);
                    }
                    else if (secondHand[0] > firstHand[0]) // second hand wins the hand
                    {                       
                        secondHand.Add(secondHand[0]);
                        secondHand.RemoveAt(0);
                        secondHand.Add(firstHand[0]);
                        firstHand.Remove(firstHand[0]);
                    }
                    else if (firstHand[0] == secondHand[0])
                    {
                        firstHand.Remove(firstHand[0]);
                        secondHand.Remove(secondHand[0]);
                    }
               
            }
            
        }
    }
}