using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories;
using SpaceStation.Repositories.Contracts;
using SpaceStation.Utilities.Messages;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private IRepository<IAstronaut> astronauts;
        private IRepository<IPlanet> planets;
        public Controller()
        {
            astronauts = new AstronautRepository();
            planets = new PlanetRepository();
        }

        public string AddAstronaut(string type, string astronautName)
        {
            if (type != nameof(Biologist) && type != nameof(Geodesist) && type != nameof(Meteorologist))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidAstronautType));
            }

            IAstronaut astronaut = null;

            if (type == nameof(Biologist))
            {
                astronaut = new Biologist(astronautName);
            }
            else if (type == nameof(Geodesist))
            {
                astronaut = new Geodesist(astronautName);
            }
            else
            {
                astronaut = new Meteorologist(astronautName);
            }

            astronauts.Add(astronaut);

            return String.Format(OutputMessages.AstronautAdded, type, astronautName);
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);

            foreach (var item in items)
            {
                planet.Items.Add(item);
            }

            planets.Add(planet);

            return String.Format(OutputMessages.PlanetAdded, planetName);
        }

        public string RetireAstronaut(string astronautName)
        {
            var astronaut = astronauts.FindByName(astronautName);

            if (astronaut == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            }

            astronauts.Remove(astronaut);

            return String.Format(OutputMessages.AstronautRetired, astronautName);
        }

        public string ExplorePlanet(string planetName)
        {
            var planet = planets.FindByName(planetName);

            var astronautsToSend = astronauts.Models.Where(x => x.Oxygen > 60).ToList();

            if (!astronautsToSend.Any())
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InvalidAstronautCount));
            }

            var mission = new Mission();
            mission.Explore(planet, astronautsToSend);

            var astronautsThatDied = astronautsToSend.Count(x => x.Oxygen == 0);

            return String.Format(OutputMessages.PlanetExplored, planetName, astronautsThatDied);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{planets.Models.Count} planets were explored!"); // might not be the correct number

            sb.AppendLine($"Astronauts info:");

            foreach (var astronaut in astronauts.Models)
            {
                sb.AppendLine($"Name: {astronaut.Name}");
                sb.AppendLine($"Oxygen: {astronaut.Oxygen}");

                if (!astronaut.Bag.Items.Any())
                {
                    sb.AppendLine($"Bag items: none");
                }
                else
                {
                    sb.AppendLine($"Bag items: {String.Join(", ", astronaut.Bag.Items)}");
                }
            }

            return sb.ToString().Trim();
        }
    }
}
