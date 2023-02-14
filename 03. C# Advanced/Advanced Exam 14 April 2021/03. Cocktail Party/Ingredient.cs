using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocktailParty
{
    public class Ingredient
    {
        public Ingredient(string name, int alcohol, int quantity)
        {
            Name = name;
            Alcohol = alcohol;
            Quantity = quantity;
        }

        public string Name { get; set; }

        public int Alcohol { get; set; }

        public int Quantity { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Ingredient: {Name}");
            sb.AppendLine($"Quantity: {Quantity}");
            sb.AppendLine($"Alcohol: {Alcohol}");

            return sb.ToString().TrimEnd();
        }
    }
}
