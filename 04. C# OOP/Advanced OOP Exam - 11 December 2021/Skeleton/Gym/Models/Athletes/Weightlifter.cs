using System;
using System.Collections.Generic;
using System.Text;
using Gym.Utilities.Messages;

namespace Gym.Models.Athletes
{
    public class Weightlifter : Athlete
    {
        private const int INITIAL_STAMINA = 50;

        public Weightlifter(string fullName, string motivation, int numberOfMedals) : base(fullName, motivation, numberOfMedals, INITIAL_STAMINA)
        {
        }

        public override void Exercise() // only in weightlifting gym
        {
            Stamina += 10;

            if (Stamina > 100)
            {
                Stamina = 100;

                throw new ArgumentException(String.Format(ExceptionMessages.InvalidStamina));
            }
        }
    }
}
