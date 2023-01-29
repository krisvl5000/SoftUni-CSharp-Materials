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
        private List<Player> playerList;

        private Team()
        {
            this.playerList = new List<Player>();
        }

        public Team(string name) : this()
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

        public int Rating 
            => playerList.Count > 0 ?
            (int)Math.Round(playerList.Average(p => p.OverallRating), 0) : 0;

        public void AddPlayer(Player player)
        {
            playerList.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            Player playerToRemove = playerList.FirstOrDefault(p => p.Name == playerName);

            if (playerToRemove == null)
            {
                throw new InvalidOperationException(String
                    .Format(ExceptionMessages
                    .MISSING_PLAYER_MESSAGE, playerName, Name));
            }

            playerList.Remove(playerToRemove);
        }
    }
}
