using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Heroes.Models.Contracts;

namespace Heroes.Models.Map
{
    public class Map : IMap
    {
        public string Fight(ICollection<IHero> players)
        {
            var barbarians = players.Where(x => x.GetType().Name == "Barbarian");

            var knights = players.Where(x => x.GetType().Name == "Knight");

            int knightCasultyCounter = 0;
            int barbarianCasualtyCounter = 0;

            while (barbarians.Any(x => x.IsAlive) && knights.Any(x => x.IsAlive))
            {
                foreach (var knight in knights.Where(x => x.IsAlive))
                {
                    foreach (var barbarian in barbarians)
                    {
                        barbarian.TakeDamage(knight.Weapon.DoDamage());

                        if (!barbarian.IsAlive)
                        {
                            barbarianCasualtyCounter++;
                        }
                    }
                }

                foreach (var barbarian1 in barbarians.Where(x => x.IsAlive))
                {
                    foreach (var knight1 in knights)
                    {
                        knight1.TakeDamage(barbarian1.Weapon.DoDamage());

                        if (!knight1.IsAlive)
                        {
                            knightCasultyCounter++;
                        }
                    }
                }
            }

            if (!barbarians.Any())
            {
                return $"The knights took {knightCasultyCounter} casualties but won the battle.";
            }

            return $"The barbarians took {barbarianCasualtyCounter} casualties but won the battle.";
        }
    }
}
