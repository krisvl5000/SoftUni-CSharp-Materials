using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Cake : Dessert
    {
        private const double CAKE_GRAMS = 250;
        private const double CAKE_CALORIES = 1000;
        private const decimal CAKE_PRICE = 5m;
        public Cake(string name)
            : base(name, CAKE_PRICE, CAKE_GRAMS, CAKE_CALORIES)
        {
            Name = name;
        }
    }
}
