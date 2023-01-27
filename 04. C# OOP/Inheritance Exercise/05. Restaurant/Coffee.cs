using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        public Coffee(string name, decimal price, double mililiters) : base(name, price, mililiters)
        {

        }

        public double CoffeeMililiters { get; set; } = 50;

        public decimal CoffeePrice { get; set; } = 3.50m;

        public double Caffeine { get; set; }
    }
}
