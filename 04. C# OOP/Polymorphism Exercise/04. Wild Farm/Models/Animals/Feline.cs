using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm
{
    public abstract class Feline : Animal, IFeline
    {
        public Feline(string name, double weight, string breed)
            : base(name, weight)
        {
            Breed = breed;
        }

        public string Breed { get; private set; }
    }
}
