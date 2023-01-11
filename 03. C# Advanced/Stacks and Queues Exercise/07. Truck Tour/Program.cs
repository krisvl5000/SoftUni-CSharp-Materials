using System;
using System.Linq;
using System.Collections.Generic;

internal class Program
{
    static void Main()
    {
        int numberOfPumps = int.Parse(Console.ReadLine());
        Queue<string> queue = new Queue<string>();
        for (int i = 0; i < numberOfPumps; i++)
        {
            queue.Enqueue(Console.ReadLine());
        }
        for (int index = 0; index < numberOfPumps; index++)
        {
            if (CanCompleteFullCircle(queue))
            {
                Console.WriteLine(index);
                break;
            }
            queue.Enqueue(queue.Dequeue());
        }
    }

    private static bool CanCompleteFullCircle(Queue<string> queue)
    {
        int fuel = 0;
        bool canCompleteCirle = true;
        for (int i = 0; i < queue.Count; i++)
        {
            int petrolAmount = int.Parse(queue.Peek().Split().First());
            int distance = int.Parse(queue.Peek().Split().Last());
            fuel += petrolAmount - distance;
            if (fuel < 0)
                canCompleteCirle = false;
            queue.Enqueue(queue.Dequeue());
        }
        return canCompleteCirle;
    }
}