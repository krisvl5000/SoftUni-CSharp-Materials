using System;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> personList = new List<Person>();
            List<Product> productList = new List<Product>();

            string[] peopleArgs = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in peopleArgs)
            {
                string name = item.Split('=')[0];
                int money = int.Parse(item.Split('=')[1]);

                Person person = new Person(name, money);
                personList.Add(person);
            }

            string[] productArgs = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in productArgs)
            {
                string name = item.Split('=')[0];
                int cost = int.Parse(item.Split('=')[1]);

                Product product = new Product(name, cost);
                productList.Add(product);
            }

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] buyingArgs = command.Split(" ");

                string name = buyingArgs[0];
                string productToBuy = buyingArgs[1];

                Person personToBuy = personList
                    .First(x => x.Name == name);

                Product productToBeBought = productList
                    .First(x => x.Name == productToBuy);

                if (personToBuy.Money >= productToBeBought.Cost)
                {
                    personToBuy.Products.Add(productToBeBought);
                    personToBuy.Money -= productToBeBought.Cost;
                }
                else
                {
                    Console.WriteLine($"{personToBuy.Name} " +
                        $"can't afford {productToBeBought.Name}");
                }
            }
        }
    }
}