using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine();
            double sales = double.Parse(Console.ReadLine());
            double percentage = 0;
            
             if ((sales >= 0) && (sales <= 500))
             {
                 switch (city)
                 {
                    case "Sofia":
                        percentage = 5;
                        break;
                    case "Varna":
                        percentage = 4.5;
                        break;
                    case "Plovdiv":
                        percentage = 5.5;
                        break;
                        default:
                        Console.WriteLine("error");
                        return;
                 }
                double commission = (percentage * sales) / 100;
                Console.WriteLine($"{commission:F2}");
            }
             else if ((sales > 500) && (sales <=1000))
             {
                switch (city)
                {
                    case "Sofia":
                        percentage = 7;
                        break;
                    case "Varna":
                        percentage = 7.5;
                        break;
                    case "Plovdiv":
                        percentage = 8;
                        break;
                    default:
                        Console.WriteLine("error");
                        return;
                }
                double commission = (percentage * sales) / 100;
                Console.WriteLine($"{commission:F2}");

            }
             else if ((sales >1000) && (sales <= 10000))
             {
                switch (city)
                {
                    case "Sofia":
                        percentage = 8;
                        break;
                    case "Varna":
                        percentage = 10;
                        break;
                    case "Plovdiv":
                        percentage = 12;
                        break;
                    default:
                        Console.WriteLine("error");
                        return;
                }
                double commission = (percentage * sales) / 100;
                Console.WriteLine($"{commission:F2}");
            }
             else if (sales > 10000)
             {
                switch (city)
                {
                    case "Sofia":
                        percentage = 12;
                        break;
                    case "Varna":
                        percentage = 13;
                        break;
                    case "Plovdiv":
                        percentage = 14.5;
                        break;
                    default:
                        Console.WriteLine("error");
                        return;
                }
                double commission = (percentage * sales) / 100;
                Console.WriteLine($"{commission:F2}");
            }
             else
             {
                Console.WriteLine("error");
             }
            

        }
    }
}