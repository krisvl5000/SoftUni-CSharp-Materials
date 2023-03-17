using System;
using System.Collections.Generic;
using System.Text;
using Easter.Models.Dyes.Contracts;

namespace Easter.Models.Dyes
{
    public class Dye : IDye
    {
        public Dye(int power)
        {
            Power = power;
        }

        private int power;

        public int Power
        {
            get { return power; }
            private set
            {
                if (value < 0)
                {
                    power = 0;
                }
                power = value;
            }
        }

        public void Use()
        {
            Power -= 10;

            if (Power < 0)
            {
                Power = 0;
            }
        }

        public bool IsFinished() => Power == 0;
    }
}
