using System;

namespace Polymorphism
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What kitchen type do you want to use?");
            string kitchenType = Console.ReadLine();

            Kitchen kitchen = new RobotKitchen();

            if (kitchenType == "old")
            {
                kitchen = new OldKitchen();
            }
            else if (kitchenType == "normal")
            {
                kitchen = new NormalKitchen();
            }
            else if (kitchenType == "modern")
            {
                kitchen = new ModernKitchen();
            }
            else if (kitchenType == "robot")
            {
                kitchen = new RobotKitchen();
            }

            while (true)
            {
                Console.WriteLine("What is your order?");

                var order = Console.ReadLine();

                if (order == "meat")
                {
                    kitchen.CookMeat();
                }
                if (order == "salad")
                {
                    kitchen.CookSalad();
                }
                if (order == "veggie")
                {
                    kitchen.CookVegetarian();
                }
                if (order == "clean")
                {
                    kitchen.CleanKitchen();
                }
                if (order == "robot clean")
                {
                    if (kitchen is RobotKitchen)
                    {
                        ((RobotKitchen)kitchen).RobotClean();
                    }
                    else
                    {
                        Console.WriteLine("Kuhnqta ti e stara");
                    }
                }
                if (order == "change kitchen")
                {
                    // TODO: change at any time
                }
            }

        }
    }
}