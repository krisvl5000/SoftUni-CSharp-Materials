using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding
{
    public class Rogue : BaseHero
    {
        private const int POWER = 80;

        public Rogue(string name) : base(name, POWER)
        {

        }

        public override string CastAbility()
        {
            return $"{GetType().Name} - {Name} hit for {Power} damage";
        }
    }
}
