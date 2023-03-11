using System;
using System.Collections.Generic;
using System.Text;
using Heroes.Models.Contracts;

namespace Heroes.Models.Heroes
{
    public abstract class Hero : IHero
    {
        public Hero(string name, int health, int armour)
        {
            Name = name;
            Health = health;
            Armour = armour;
        }
        
        private string name;

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Hero name cannot be null or empty.");
                }
                name = value;
            }
        }

        private int health;

        public int Health
        {
            get { return health; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Health cannot be below 0.");
                }
                health = value;
            }
        }

        private int armour;

        public int Armour
        {
            get { return armour; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hero armour cannot be below 0.");
                }
                armour = value;
            }
        }

        private IWeapon weapon;

        public IWeapon Weapon
        {
            get { return weapon; }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException("Weapon cannot be null.");
                }
                weapon = value;
            }
        }


        private bool isAlive;

        public bool IsAlive
        {
            get
            {
                if (health > 0)
                {
                    return true;
                }

                return false;
            }

            private set
            {
                isAlive = value;
            }
        }

        public void TakeDamage(int points)
        {
            int remainingDamage = points - Armour;
            
            Armour -= points;

            if (Armour <= 0)
            {
                Armour = 0;

                Health -= remainingDamage;

                if (Health <= 0)
                {
                    Health = 0;
                    IsAlive = false;
                }
            }

        }

        public void AddWeapon(IWeapon weapon)
        {
            Weapon = weapon;
        }
    }
}
