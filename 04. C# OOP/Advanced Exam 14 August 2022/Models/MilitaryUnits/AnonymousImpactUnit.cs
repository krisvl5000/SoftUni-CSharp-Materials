using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.MilitaryUnits
{
    internal class AnonymousImpactUnit : MilitaryUnit
    {
        private const double COST = 30.0;
        public AnonymousImpactUnit() : base(COST)
        {

        }
    }
}
