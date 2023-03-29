using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.MilitaryUnits
{
    public class SpaceForces : MilitaryUnit
    {
        private const double PRICE = 11.0;
        public SpaceForces() : base(PRICE)
        {
        }
    }
}
