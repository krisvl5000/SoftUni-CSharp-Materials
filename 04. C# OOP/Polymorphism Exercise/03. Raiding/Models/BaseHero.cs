using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding
{
    public abstract class BaseHero : IBaseHero
    {
        public BaseHero()
        {

        }

        public BaseHero(string name, int power) : this()
        {
            Name = name;
            Power = power;
        }

        public string Name { get; set; }

        public int Power { get; set; }

        public abstract string CastAbility();
    }
}
