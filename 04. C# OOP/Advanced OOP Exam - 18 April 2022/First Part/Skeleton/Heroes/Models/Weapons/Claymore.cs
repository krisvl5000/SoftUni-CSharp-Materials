using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models.Weapons
{
    public class Claymore : Weapon
    {
        public Claymore(string name, int durability) : base(name, durability)
        {

        }

        public override int DoDamage()
        {
            Durability -= 1;

            if (Durability <= 0)
            {
                return 0;
            }

            return 20;
        }
    }
}
