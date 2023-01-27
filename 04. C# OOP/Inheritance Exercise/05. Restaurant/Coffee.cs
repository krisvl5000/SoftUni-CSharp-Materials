using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const double COFFEE_MILILITERS = 50;
        private const decimal COFFEE_PRICE = 3.5m;

        public Coffee(string name, double caffeine) : base(name, COFFEE_PRICE, COFFEE_MILILITERS)
        {
            Caffeine = caffeine;
        }

        public double Caffeine { get; set; }
    }
}
