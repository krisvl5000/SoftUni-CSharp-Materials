using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
         //Напишете програма, която чете от конзолата плод(banana / apple / orange / grapefruit / 
         //kiwi / pineapple / grapes), ден от седмицата(Monday / Tuesday / Wednesday / Thursday
         /// Friday / Saturday / Sunday) и количество(реално число) , въведени от потребителя,
         // и пресмята цената според цените от таблиците по-горе.Резултатът да се отпечата закръглен
         // с 2 цифри след десетичната точка. При невалиден ден от седмицата или невалидно име на плод
         // да се отпечата "error".
            string fruit = Console.ReadLine(); 
            string day = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());

           if ((day == "Monday") || (day == "Tuesday") == (day == "Wednesday") || 
               (day == "Thursday") || (day == "Friday"))
           {
               switch (fruit)
               {
                   case "banana":
                       double price = 2.50;
                       //double value = price * quantity;
                        
                       Console.WriteLine( price * quantity);
                       break;
                    case "apple":
                        price = 1.20;
                        Console.WriteLine(price * quantity);
                        break;
                    case "orange":
                        price = 0.85;
                        Console.WriteLine(price * quantity);
                        break;
                    case "grapefruit":
                        price = 1.45;
                        Console.WriteLine(price * quantity);
                        break;
                    case "kiwi":
                        price = 2.70;
                        Console.WriteLine(price * quantity);
                        break;
                    case "pineapple":
                        price = 5.50;
                        Console.WriteLine(price * quantity);
                        break;
                    case "grapes":
                        price = 3.85;
                        Console.WriteLine(price * quantity);
                        break;

                }
               
           }
           else if ((day == "Saturday") || (day == "Sunday"))
           {
                switch (fruit)
                {
                    case "banana":
                        double price = 2.70;
                        //double value = price * quantity;

                        Console.WriteLine(price * quantity);
                        break;
                    case "apple":
                        price = 1.25;
                        Console.WriteLine(price * quantity);
                        break;
                    case "orange":
                        price = 0.90;
                        Console.WriteLine(price * quantity);
                        break;
                    case "grapefruit":
                        price = 1.60;
                        Console.WriteLine(price * quantity);
                        break;
                    case "kiwi":
                        price = 3;
                        Console.WriteLine(price * quantity);
                        break;
                    case "pineapple":
                        price = 5.60;
                        Console.WriteLine(price * quantity);
                        break;
                    case "grapes":
                        price = 4.20;
                        Console.WriteLine(price * quantity);
                        break;

                }

            }
           else
           {
                Console.WriteLine("error");
           }
            
        }
    }
}