using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTeamGenerator
{
    public class Stats
    {
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Stats(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }

        public int Endurance
        {
            get { return endurance; }

            private set
            {
                if (IsStatInvalid(value))
                {
                    throw new ArgumentException(String.Format(
                        ExceptionMessages.INVALID_STAT_MESSAGE, nameof(this.Endurance)));
                }

                endurance = value;
            }
        }

        public int Sprint
        {
            get { return sprint; }

            private set
            {
                if (IsStatInvalid(value))
                {
                    throw new ArgumentException(String.Format(
                        ExceptionMessages.INVALID_STAT_MESSAGE, nameof(this.Sprint)));
                }

                sprint = value;
            }
        }

        public int Dribble
        {
            get { return dribble; }

            private set
            {
                if (IsStatInvalid(value))
                {
                    throw new ArgumentException(String.Format(
                        ExceptionMessages.INVALID_STAT_MESSAGE, nameof(this.Dribble)));
                }

                dribble = value;
            }
        }

        public int Passing
        {
            get { return passing; }

            private set
            {
                if (IsStatInvalid(value))
                {
                    throw new ArgumentException(String.Format(
                        ExceptionMessages.INVALID_STAT_MESSAGE, nameof(this.Passing)));
                }

                passing = value;
            }
        }

        public int Shooting
        {
            get { return shooting; }

            private set
            {
                if (IsStatInvalid(value))
                {
                    throw new ArgumentException(String.Format(
                        ExceptionMessages.INVALID_STAT_MESSAGE, nameof(this.Shooting)));
                }

                shooting = value;
            }
        }

        private bool IsStatInvalid(int value) => value < 0 || value > 100;
    }
}
