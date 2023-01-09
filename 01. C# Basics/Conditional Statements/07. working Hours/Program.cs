using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int hour = int.Parse(Console.ReadLine());
            string weekday = Console.ReadLine();

            if ((hour >=10) && (hour<18))
            {
                switch(weekday)
                {
                    case "Monday":
                        Console.WriteLine("open");
                        break;
                    case "Tuesday":
                        Console.WriteLine("open");
                        break;
                    case "Wednesday":
                        Console.WriteLine("open");
                        break;
                    case "Thursday":
                        Console.WriteLine("open");
                        break;
                    case "Friday":
                        Console.WriteLine("open");
                        break;
                    case "Saturday":
                        Console.WriteLine("open");
                        break;
                }
            }
            else
            {
                Console.WriteLine("closed");
            }

        }
    }
}