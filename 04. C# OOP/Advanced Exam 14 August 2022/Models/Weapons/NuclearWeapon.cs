using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.Weapons
{
    public class NuclearWeapon : Weapon
    {
        private const double PRICE = 15.0;
        public NuclearWeapon(int destructionlevel) : base(destructionlevel, PRICE)
        {

        }
    }
}
