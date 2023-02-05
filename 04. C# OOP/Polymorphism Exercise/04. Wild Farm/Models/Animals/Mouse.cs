using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm
{
    public class Mouse : Mammal
    {
        private const double MOUSE_WEIGHT_MULTIPLIER = 0.10;

        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {

        }

        public override IReadOnlyCollection<Type> PreferredFoods => 
            new HashSet<Type> { typeof(Vegetable), typeof(Fruit) };

        protected override double WeightMultiplier =>
            MOUSE_WEIGHT_MULTIPLIER;

        public override string ProduceSound()
        {
            return "Squeak";
        }
    }
}
