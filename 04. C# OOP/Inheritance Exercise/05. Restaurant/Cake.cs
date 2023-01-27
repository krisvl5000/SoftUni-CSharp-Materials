using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Cake : Dessert
    {
        public Cake(string name, decimal price, double grams, double calories)
            : base(name, price, grams, calories)
        {
            Grams = 250;
            Calories = 1000;
            Price = 5;
        }
    }
}
