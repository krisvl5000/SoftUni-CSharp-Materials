using System;
using System.Collections.Generic;
using System.Text;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public Map()
        {
            
        }

        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            IRacer winner = null;

            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return String.Format(OutputMessages.RaceCannotBeCompleted);
            } 
            
            if (racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                winner = racerOne;

                return String.Format(OutputMessages.OneRacerIsNotAvailable, winner.Username, racerTwo.Username);
            }
            else if (!racerOne.IsAvailable() && racerTwo.IsAvailable())
            {
                winner = racerTwo;

                return String.Format(OutputMessages.OneRacerIsNotAvailable, winner.Username, racerOne.Username);
            }

            if (racerOne.IsAvailable() && racerTwo.IsAvailable())
            {
                racerOne.Race();
                racerTwo.Race();

                double firstRacerChance = racerOne.Car.HorsePower * racerOne.DrivingExperience * CalculateMultiplier(racerOne);

                double secondRacerChance = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * CalculateMultiplier(racerTwo);

                if (firstRacerChance > secondRacerChance)
                {
                    winner = racerOne;
                }
                else
                {
                    winner = racerTwo;
                }
            }

            return String.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, winner.Username);
        }

        private double CalculateMultiplier(IRacer racer)
        {
            if (racer.RacingBehavior == "strict")
            {
                return 1.2;
            }

            return 1.1;
        }
    }
}
