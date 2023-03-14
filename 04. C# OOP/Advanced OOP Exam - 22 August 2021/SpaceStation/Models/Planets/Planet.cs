using System;
using System.Collections.Generic;
using System.Text;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Utilities.Messages;

namespace SpaceStation.Models.Planets
{
    public class Planet : IPlanet
    {
        public Planet(string name)
        {
            Name = name;
            Items = new List<string>();
        }

        private string name;

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(String.Format(ExceptionMessages.InvalidPlanetName));
                }
                name = value;
            }
        }

        public ICollection<string> Items { get; }
    }
}
