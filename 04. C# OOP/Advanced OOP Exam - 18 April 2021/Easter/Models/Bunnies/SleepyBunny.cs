using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Bunnies
{
    public class SleepyBunny : Bunny
    {
        private const int INITIAL_ENERGY = 50;
        public SleepyBunny(string name) : base(name, INITIAL_ENERGY)
        {
        }

        public override void Work()
        {
            base.Work();
            Energy -= 5;

            if (Energy < 0)
            {
                Energy = 0;
            }
        }
    }
}
