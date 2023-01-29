using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTeamGenerator
{
    public class Team
    {
        private string name;

        public Team(string name)
        {
            Name = name;
        }

        public string Name
        {
            get { return name; }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(
                        ExceptionMessages.NAME_CANNOT_BE_NULL_OR_WHITESPACE);
                }

                name = value;
            }
        }
    }
}
