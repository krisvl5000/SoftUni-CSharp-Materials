using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocktailParty
{
    public class Cocktail
    {
        private HashSet<Ingredient> ingredients;

        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcoholLevel;
            this.ingredients = new HashSet<Ingredient>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int MaxAlcoholLevel { get; set; }

        public HashSet<Ingredient> Ingredients => ingredients;

        public int CurrentAlcoholLevel => ingredients.Sum(x => x.Alcohol);

        public void Add(Ingredient ingredient)
        {
            if (!ingredients.Any(x => x.Name == ingredient.Name) &&
                ingredients.Count < Capacity
                && ingredient.Alcohol <= MaxAlcoholLevel)
            {
                ingredients.Add(ingredient);
            }
        }

        public bool Remove(string name)
        {
            Ingredient ingredientToRemove = ingredients
                .FirstOrDefault(x => x.Name == name);

            if (ingredientToRemove != null)
            {
                ingredients.Remove(ingredientToRemove);
                return true;
            }

            return false;
        }

        public Ingredient FindIngredient(string name)
        {
            return ingredients.FirstOrDefault(x => x.Name == name);
        }

        public Ingredient GetMostAlcoholicIngredient()
        {
            return ingredients.OrderByDescending(x => x.Alcohol).FirstOrDefault();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Cocktail: {Name} - Current Alcohol Level: " +
                $"{CurrentAlcoholLevel}");

            foreach (var ingredient in ingredients)
            {
                sb.AppendLine(ingredient.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
