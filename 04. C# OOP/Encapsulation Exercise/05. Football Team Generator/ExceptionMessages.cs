using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTeamGenerator
{
    public static class ExceptionMessages
    {
        public const string NAME_CANNOT_BE_NULL_OR_WHITESPACE =
            "A name should not be empty.";

        public const string INVALID_STAT_MESSAGE =
            "{0} should be between 0 and 100.";
    }
}
