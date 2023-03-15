using System;
using System.Collections.Generic;
using System.Text;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;

namespace CarRacing.Models.Racers
{
    public abstract class Racer : IRacer
    {
        private string username;

        public string Username
        {
            get { return username; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidRacerName));
                }
                username = value;
            }
        }

        private string racingBehavior;

        public string RacingBehavior
        {
            get { return racingBehavior; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidRacerBehavior));
                }
                racingBehavior = value;
            }
        }

        private int drivingExperience;

        public int DrivingExperience
        {
            get { return drivingExperience; }
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidRacerDrivingExperience));
                }
                drivingExperience = value;
            }
        }

        private ICar car;

        public ICar Car
        {
            get { return car; }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidRacerCar));
                }
                car = value;
            }
        }

        public void Race()
        {
            throw new NotImplementedException();
        }

        public bool IsAvailable()
        {
            throw new NotImplementedException();
        }
    }
}
