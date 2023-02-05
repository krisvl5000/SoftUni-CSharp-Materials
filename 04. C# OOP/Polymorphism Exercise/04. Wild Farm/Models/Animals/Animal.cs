using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm
{
    public abstract class Animal : IAnimal
    {
        private Animal()
        {
            FoodEaten = 0;
        }
        protected Animal(string name, double weight) : this()
        {
            Name = name;
            Weight = weight;
        }

        public string Name { get; private set; }

        public double Weight {get; private set; }

        public int FoodEaten {get; private set; }

        protected abstract double WeightMultiplier { get; }

        public abstract IReadOnlyCollection<Type> PreferredFoods { get; }

        public void Eat(IFood food)
        {
            if (!PreferredFoods.Any(t => food.GetType().Name == t.Name))
            {
                throw new FoodNotEdibleException(String
                    .Format(ExceptionMessages
                    .FOOD_NOT_EDIBLE_EXCEPTION_MESSAGE,
                    GetType().Name,
                    food.GetType().Name));
            }

            Weight += food.Quantity * WeightMultiplier;
            FoodEaten += food.Quantity;
        }

        public abstract string ProduceSound();
    }
}
