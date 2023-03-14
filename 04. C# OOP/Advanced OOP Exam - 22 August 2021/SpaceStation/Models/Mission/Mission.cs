using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Bags;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets.Contracts;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public Mission()
        {
            
        }

        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            foreach (var astronaut in astronauts.Where(x => x.Oxygen > 0))
            {
                while (true)
                {
                    var item = planet.Items.FirstOrDefault(); 
                    // we don't know what happens if the planet runs out of items while there are still remaining astronauts


                    if (!planet.Items.Any())
                    {
                        break;
                    }

                    astronaut.Breath();

                    astronaut.Bag.Items.Add(item);
                    planet.Items.Remove(item);

                    if (astronaut.Oxygen < 0) // the specific order of operations hasn't been specified, might need to be moved up
                    {
                        break;
                    }
                }
            }
        }
    }
}
