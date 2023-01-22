using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5 };

            //numbers = numbers.Where(x => x > 3).ToList();
            numbers = Where(numbers, IsBigerThanThree);
            Console.WriteLine(String.Join(" ", numbers));
        }

        static bool IsBigerThanThree(int number)
        {
            return number > 3;
        }

        public static List<int> Where(List<int> list, Func<int, bool> checker)
        {
            List<int> result = new List<int>();

            foreach (var item in list)
            {
                if (checker(item))
                {
                    result.Add(item);
                }    
            }

            return result;
        }
    }
}