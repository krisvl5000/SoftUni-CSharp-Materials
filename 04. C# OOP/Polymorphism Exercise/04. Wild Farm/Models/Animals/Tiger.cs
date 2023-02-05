using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm
{
    public class Tiger : Feline
    {
        private const double TIGER_WEIGHT_MULTIPLIER = 1.00;

        public Tiger(string name, double weight, string breed)
            : base(name, weight, breed)
        {

        }

        public override IReadOnlyCollection<Type> PreferredFoods =>
            new HashSet<Type>() { typeof(Meat) };

        protected override double WeightMultiplier =>
            TIGER_WEIGHT_MULTIPLIER;

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
