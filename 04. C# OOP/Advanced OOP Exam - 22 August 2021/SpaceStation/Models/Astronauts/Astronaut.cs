using System;
using System.Collections.Generic;
using System.Text;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Bags;
using SpaceStation.Models.Bags.Contracts;
using SpaceStation.Utilities.Messages;

namespace SpaceStation.Models.Astronauts
{
    public abstract class Astronaut : IAstronaut
    {
        public Astronaut(string name, double oxygen)
        {
            Name = name;
            Oxygen = oxygen;
            Bag = new Backpack();
        }

        private string name;

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(String.Format(ExceptionMessages.InvalidAstronautName));
                }
                name = value;
            }
        }

        private double oxygen;

        public double Oxygen
        {
            get { return oxygen; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidOxygen));
                }
                oxygen = value;
            }
        }

        public bool CanBreath { get; }

        public IBag Bag { get; }

        public virtual void Breath()
        {
            if (Oxygen - 10 <= 0)
            {
                Oxygen = 0;
                return;
            }

            Oxygen -= 10;
        }
    }
}
