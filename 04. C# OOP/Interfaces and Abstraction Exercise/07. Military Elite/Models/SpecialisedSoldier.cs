using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite
{
    public class SpecialisedSoldier : Soldier, ISpecialisedSoldier
    {
        private string corps;

        public SpecialisedSoldier(string corps)
        {
            Corps = corps;
        }

        public string Corps
        {
            get
            {
                return corps;
            }
            set
            {
                if (value != "AirForces" || value != "Marines")
                {
                    return;
                }

                corps = value;
            }
        }
    }
}
