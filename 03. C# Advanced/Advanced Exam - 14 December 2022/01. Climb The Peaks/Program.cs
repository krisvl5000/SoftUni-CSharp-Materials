using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> foodStack = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Queue<int> staminaQueue = new Queue<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            var dict = new Dictionary<string, int>();
            dict.Add("Vihren", 80);
            dict.Add("Kutelo", 90);
            dict.Add("Banski Suhodol", 100);
            dict.Add("Polezhan", 60);
            dict.Add("Kamenitza", 70);

            List<string> conqueredPeaks = new List<string>();

            int counter = 7;
            while (counter != 0 && dict.Count > 0 &&
                foodStack.Count > 0 &&staminaQueue.Count > 0)
            {
                int food = foodStack.Pop();
                int stamina = staminaQueue.Dequeue();

                if (food + stamina >= dict.ElementAt(0).Value)
                {
                    conqueredPeaks.Add(dict.ElementAt(0).Key);
                    dict.Remove(dict.ElementAt(0).Key);
                }

                counter--;
            }

            if (dict.Count == 0)
            {
                Console.WriteLine("Alex did it! He climbed all top five " +
                    "Pirin peaks in one week -> @FIVEinAWEEK");
            }
            else
            {
                Console.WriteLine("Alex failed! He has to organize his journey " +
                    "better next time -> @PIRINWINS");
            }

            if (conqueredPeaks.Count > 0)
            {
                Console.WriteLine("Conquered peaks:");

                foreach (var item in conqueredPeaks)
                {
                    Console.WriteLine(item);
                }
            }
            

        }
    }
}