using System;
using System.Collections.Generic;
using System.Text;
using CarRacing.Models.Cars.Contracts;

namespace CarRacing.Models.Racers
{
    internal class StreetRacer : Racer
    {
        private const int DRIVING_EXPERIENCE = 10;
        private const string RACING_BEHAVIOR = "aggressive";
        public StreetRacer(string username, ICar car) : base(username, RACING_BEHAVIOR, DRIVING_EXPERIENCE, car)
        {
        }

        public override void Race()
        {
            base.Race();
            DrivingExperience += 5;
        }
    }
}
