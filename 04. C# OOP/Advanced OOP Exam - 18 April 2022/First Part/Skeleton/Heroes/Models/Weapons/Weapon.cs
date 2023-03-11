using System;
using System.Collections.Generic;
using System.Text;
using Heroes.Models.Contracts;

namespace Heroes.Models.Weapons
{
    public abstract class Weapon : IWeapon
    {
        public Weapon(string name, int durability)
        {
            Name = name;
            Durability = durability;
        }

        private string name;

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Weapon type cannot be null or empty.");
                }
                name = value;
            }
        }

        private int durability;

        public int Durability
        {
            get { return durability; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Durability cannot be below 0.");
                }
                durability = value;
            }
        }

        public abstract int DoDamage();
    }
}
