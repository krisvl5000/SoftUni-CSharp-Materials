using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();

            while (list.Count < 10)
            {
                try
                {
                    if (!list.Any())
                    {
                        list.Add(ReadNumber(1, 100));
                    }
                    else
                    {
                        list.Add(ReadNumber(list.Max(), 100));
                    }
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            Console.WriteLine(String.Join(", ", list));
        }

        static int ReadNumber(int start, int end)
        {
            int num;
            try
            {
                num = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                throw new FormatException("Invalid Number!");
            }

            if (num <= start || num >= end)
            {
                throw new ArgumentException
                    ($"Your number is not in range {start} - {end}!");
            }

            return num;
        }
    }
}