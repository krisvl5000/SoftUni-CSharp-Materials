using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding
{
    public class Druid : BaseHero
    {
        private const int POWER = 80;

        public Druid(string name) : base(name, POWER)
        {

        }

        public override string CastAbility()
        {
            return $"{GetType().Name} - {Name} healed for {Power}"; 
        }
    }
}
