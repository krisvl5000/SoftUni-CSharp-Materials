using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            string city = Console.ReadLine();   
            double quantity = double.Parse(Console.ReadLine());
        
            if (city == "Sofia")
            {
                switch (product)
                {
                    case "coffee":
                        double price = 0.50;
                        Console.WriteLine(price * quantity);
                        break;
                    case "water":
                        price = 0.80;
                        Console.WriteLine(price * quantity);
                        break;
                    case "beer":
                        price = 1.20;
                        Console.WriteLine(price * quantity);
                        break;
                    case "sweets":
                        price = 1.45;
                        Console.WriteLine(price * quantity);
                        break;
                    case "peanuts":
                        price = 1.60;
                        Console.WriteLine(price * quantity);
                        break;
                        
                        
                }
                
            } 
            else if (city == "Plovdiv")
            {
                switch (product)
                {
                    case "coffee":
                        double price = 0.40;
                        Console.WriteLine(price * quantity);
                        break;
                    case "water":
                        price = 0.70;
                        Console.WriteLine(price * quantity);
                        break;
                    case "beer":
                        price = 1.15;
                        Console.WriteLine(price * quantity);
                        break;
                    case "sweets":
                        price = 1.30;
                        Console.WriteLine(price * quantity);
                        break;
                    case "peanuts":
                        price = 1.50;
                        Console.WriteLine(price * quantity);
                        break;
                        
                }
            }
            else if (city == "Varna")
            {
                switch (product)
                {
                    case "coffee":
                        double price = 0.45;
                        Console.WriteLine(price * quantity);
                        break;
                    case "water":
                        price = 0.70;
                        Console.WriteLine(price * quantity);
                        break;
                    case "beer":
                        price = 1.10;
                        Console.WriteLine(price * quantity);
                        break;
                    case "sweets":
                        price = 1.35;
                        Console.WriteLine(price * quantity);
                        break;
                    case "peanuts":
                        price = 1.55;
                        Console.WriteLine(price * quantity);
                        break;
                        
                }
            }

           
          

        }
    }
}