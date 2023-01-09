using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string weekday = Console.ReadLine();

            switch(weekday)
            {
                case "Monday":
                    Console.WriteLine("12");
                    break;
                case "Tuesday":
                    Console.WriteLine("12");
                    break;
                case "Wednesday":
                    Console.WriteLine("14");
                    break;
                case "Thursday":
                    Console.WriteLine("14");
                    break;
                case "Friday":
                    Console.WriteLine("12");
                    break;
                case "Saturday":
                    Console.WriteLine("16");
                    break;
                case "Sunday":
                    Console.WriteLine("16");
                    break;
            }

        }
    }
}