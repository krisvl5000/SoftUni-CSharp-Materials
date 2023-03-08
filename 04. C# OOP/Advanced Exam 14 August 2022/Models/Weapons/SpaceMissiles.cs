using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.Weapons
{
    public class SpaceMissiles : Weapon
    {
        private const double PRICE = 8.75;
        public SpaceMissiles(int destructionlevel) : base(destructionlevel, PRICE)
        {

        }
    }
}
