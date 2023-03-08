﻿using System;
using System.Collections.Generic;
using System.Text;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Utilities.Messages;

namespace PlanetWars.Models.Weapons
{
    public abstract class Weapon : IWeapon
    {
        public Weapon(int destructionlevel, double price)
        {
            DestructionLevel = destructionlevel;
            Price = price;
        }

        private double price;

        public double Price
        {
            get { return price; }
            private set
            {
                price = value;
            }
        }

        private int destructionLevel;

        public int DestructionLevel
        {
            get { return destructionLevel; }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.TooLowDestructionLevel));
                }

                if (value > 10)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.TooHighDestructionLevel));
                }

                destructionLevel = value;
            }
        }

    }
}
