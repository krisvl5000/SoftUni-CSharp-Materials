using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Hello_Softuni
{
    internal class Item
    {
        public Item(string itemName, double itemPrice)
        {
            Name = itemName;
            Price = itemPrice;
        }
        public string Name { get; set; }

        public double Price { get; set; }
    }

    internal class Box
    {
        public Box(int serialNumber,
            string itemName,
            int itemQuantity,
            double itemPrice,
            double boxPrice)
        {
            SerialNumber = serialNumber;
            ItemName = itemName;
            ItemQuantity = itemQuantity;
            ItemPrice = itemPrice;
            BoxPrice = boxPrice;
        }

        public int SerialNumber { get; set; }

        public string ItemName { get; set; }

        public int ItemQuantity { get; set; }

        public double ItemPrice { get; set; }

        public double BoxPrice { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split().ToArray();

            List<Item> items = new List<Item>();
            List<Box> boxes = new List<Box>();
            List<double> prices = new List<double>();

            int serialNumber;
            string itemName;
            int itemQuantity;
            double itemPrice;
            double boxPrice = 0;

            while (input[0] != "end")
            {
                serialNumber = int.Parse(input[0]);
                itemName = input[1];
                itemQuantity = int.Parse(input[2]);
                itemPrice = double.Parse(input[3]);

                boxPrice = itemQuantity * itemPrice;

                Item item = new Item(itemName, itemPrice);
                items.Add(item);

                Box box = new Box(serialNumber,
                    itemName,
                    itemQuantity,
                    itemPrice,
                    boxPrice);

                boxes.Add(box);
                prices.Add(box.BoxPrice);

                input = Console.ReadLine().Split().ToArray();
            }

            //                      VERY IMPORTANT!!!
            List<Box> sortedBoxes = boxes.OrderByDescending(b => b.BoxPrice).ToList();

            foreach (var box in sortedBoxes)
            {
                Console.WriteLine($"{box.SerialNumber}");
                Console.WriteLine($"-- {box.ItemName} - ${box.ItemPrice:F2}: {box.ItemQuantity}");
                Console.WriteLine($"-- ${box.BoxPrice:F2}");
            }

        }
    }
}