using System;
using System.Collections.Generic;
using System.Text;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;
using Easter.Utilities.Messages;

namespace Easter.Models.Bunnies
{
    public abstract class Bunny : IBunny
    {
        public Bunny(string name, int energy)
        {
            Name = name;
            Energy = energy;

            dyes = new List<IDye>();
        }

        private string name;

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new AggregateException(String.Format(ExceptionMessages.InvalidBunnyName));
                }
                name = value;
            }
        }

        private int energy;

        public int Energy
        {
            get { return energy; }
            protected set
            {
                if (value < 0)
                {
                    energy = 0;
                }
                energy = value;
            }
        }

        private List<IDye> dyes;

        public ICollection<IDye> Dyes => dyes;
        public virtual void Work()
        {
            Energy -= 10;

            if (Energy < 0)
            {
                Energy = 0;
            }
        }

        public void AddDye(IDye dye)
        {
            dyes.Add(dye);
        }
    }
}
