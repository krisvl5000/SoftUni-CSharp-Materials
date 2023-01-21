using System;

namespace List
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());

                list.Add(input);
            }

            string[] swapArgs = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int firstIndex = int.Parse(swapArgs[0]);
            int secondIndex = int.Parse(swapArgs[1]);

            List<int> swappedList = Swap(list, firstIndex, secondIndex);

            foreach (var item in swappedList)
            {
                Console.WriteLine($"{item.GetType()}: {item}");
            }
        }

        public static List<T> Swap<T>(List<T> list, int firstIndex, int secondIndex)
        {
            T temp = list[firstIndex];
            list[firstIndex] = list[secondIndex];
            list[secondIndex] = temp;
            return list;
        }
    }
}