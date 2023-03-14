using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public class Biologist : Astronaut
    {
        private const double INITIAL_OXYGEN = 70;
        public Biologist(string name) : base(name, INITIAL_OXYGEN)
        {
        }

        public override void Breath()
        {
            if (Oxygen - 5 <= 0)
            {
                Oxygen = 0;
                return;
            }

            Oxygen -= 5;
        }
    }
}
