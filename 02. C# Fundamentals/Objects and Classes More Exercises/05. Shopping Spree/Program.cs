using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Hello_Softuni
{
    public class Product
    {
        public Product(string name, double cost)
        {
            Name = name;
            Cost = cost;
        }

        public string Name { get; set; }

        public double Cost { get; set; }
    }

    public class Person
    {
        public Person(string name, double money)
        {
            Name = name;
            Money = money;
            Products = new List<Product>();
        }

        public string Name { get; set; }

        public double Money { get; set; }

        public List<Product> Products { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            string[] input = Console.ReadLine()
                .Split(new char[] { ';' }, StringSplitOptions
                .RemoveEmptyEntries);

            //initialising new people
            for (int i = 0; i < input.Length; i++)
            {
                string[] nameAndMoney = input[i]
                    .Split(new char[] { '=' }, StringSplitOptions
                    .RemoveEmptyEntries)
                    .ToArray();

                Person newPerson = new Person(nameAndMoney[0], 
                    double.Parse(nameAndMoney[1]));

                people.Add(newPerson);
            }

            //reading products info and adding to list
            List<Product> products = new List<Product>();
            input = Console.ReadLine()
                .Split(new char[] { ';' }, StringSplitOptions
                .RemoveEmptyEntries);

            for (int i = 0; i < input.Length; i++)
            {
                string[] nameAndCost = input[i]
                    .Split(new char[] { '=' }, StringSplitOptions
                    .RemoveEmptyEntries);

                Product newProduct = new Product(nameAndCost[0], 
                    double.Parse(nameAndCost[1]));

                products.Add(newProduct);

            }

            //taking user commands
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "END")
            {
                input = command.Split();

                string buyerName = input[0];
                string productToBuy = input[1];

                int indexPerson = people.FindIndex(x => x.Name == buyerName);
                int indexProduct = products.FindIndex(x => x.Name == productToBuy);

                if (products[indexProduct].Cost > people[indexPerson].Money)
                {
                    Console.WriteLine($"{buyerName} can't afford {productToBuy}");
                }
                else
                {
                    Console.WriteLine($"{buyerName} bought {productToBuy}");
                    people[indexPerson].Money -= products[indexProduct].Cost;
                    people[indexPerson].Products.Add(products[indexProduct]);
                }
            }

            foreach (Person person in people)
            {
                if (person.Products.Count > 0)
                {
                    Console.WriteLine($"{person.Name} - " +
                        $"{String.Join(", ", person.Products.Select(x => x.Name))}");
                }
                else
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }
            }

        }
    }
}