using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm
{
    public class Hen : Bird
    {
        private const double HEN_WEIGHT_MULTIPLIER = 0.35;

        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {

        }

        public override IReadOnlyCollection<Type> PreferredFoods => 
            new HashSet<Type>
            { typeof(Vegetable), typeof(Fruit), typeof(Meat), typeof(Seeds) };

        protected override double WeightMultiplier =>
            HEN_WEIGHT_MULTIPLIER;

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
