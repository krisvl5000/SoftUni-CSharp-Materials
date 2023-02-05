using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm
{
    public abstract class Mammal : Animal, IMammal
    {
        public Mammal(string name, double weight, string livingRegion)
            : base (name, weight)
        {
            LivingRegion = livingRegion;
        }

        public string LivingRegion { get; private set; }
    }
}
