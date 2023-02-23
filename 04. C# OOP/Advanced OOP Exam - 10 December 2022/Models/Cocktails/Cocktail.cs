using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Cocktails
{
    public abstract class Cocktail : ICocktail
    {
        private string name;
        private double price;

        public Cocktail(string cocktailName, string size, double price)
        {
            Name = cocktailName;
            Size = size;
            Price = price;
        }

        public string Name
        {
            get { return name; }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }

                name = value;
            }
        }

        public string Size {get; private set;}

        public double Price
        {
            get => price;

            private set
            {
                price = Size switch
                {
                    "Middle" => value / 3 * 2,
                    "Small" => value / 3,
                    _ => value
                };
            }
        }

        public override string ToString()
        {
            return $"{Name} ({Size}) - {Price:F2} lv";
        }
    }
}
