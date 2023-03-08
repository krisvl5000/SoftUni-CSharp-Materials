using System;
using System.Collections.Generic;
using System.Text;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Utilities.Messages;

namespace PlanetWars.Models.MilitaryUnits
{
    public abstract class MilitaryUnit : IMilitaryUnit
    {
        public MilitaryUnit(double cost)
        {
            Cost = cost;
            EnduranceLevel = 1;
        }

        public double Cost { get; private set; }
        public int EnduranceLevel { get; private set; }
        public void IncreaseEndurance()
        {
            EnduranceLevel++;

            if (EnduranceLevel > 20)
            {
                EnduranceLevel = 20;

                throw new ArgumentException(String.Format(ExceptionMessages.EnduranceLevelExceeded));
            }
        }
    }
}
