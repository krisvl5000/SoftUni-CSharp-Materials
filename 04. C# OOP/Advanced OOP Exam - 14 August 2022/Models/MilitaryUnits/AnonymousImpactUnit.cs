using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.MilitaryUnits
{
    public class AnonymousImpactUnit : MilitaryUnit
    {
        private const double PRICE = 30.0;
        public AnonymousImpactUnit() : base(PRICE)
        {
        }
    }
}
