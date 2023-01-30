using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private int money;

        public Person(string name, int money)
        {
            Name = name;
            Money = money;
            Products = new List<Product>();
        }

        public string Name
        {
            get { return name; }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                name = value;
            }
        }

        public int Money
        {
            get { return money; }

             set
            {
                if (double.IsNegative(value))
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                money = value;
            }
        }

        public List<Product> Products { get; set; }
    }
}
