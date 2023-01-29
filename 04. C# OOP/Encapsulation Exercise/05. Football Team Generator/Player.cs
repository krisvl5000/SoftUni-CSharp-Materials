using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTeamGenerator
{
    public class Player
    {
        private string name;

        public Player(string name, int endurance, int sprint, 
            int dribble, int passing, int shooting)
        {
            Name = name;
            Stats = new Stats(endurance, sprint, dribble, passing, shooting);
        }

        public string Name
        {
            get { return name; }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    // We should never directly write on the console in getters/setters/ctors/metohs
                    // and so on...
                    // We should not access directly the console or another writer in a model class
                    throw new ArgumentException(ExceptionMessages
                        .NAME_CANNOT_BE_NULL_OR_WHITESPACE);
                }

                name = value;
            }
        }

        public Stats Stats { get; private set; }

        public double OverallRating
            => (Stats.Endurance + 
               Stats.Sprint + 
               Stats.Dribble + 
               Stats.Passing + 
               Stats.Shooting) / 5.0;
    }
}
