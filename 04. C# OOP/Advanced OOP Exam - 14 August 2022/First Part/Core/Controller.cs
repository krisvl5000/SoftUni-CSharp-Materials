using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using PlanetWars.Core.Contracts;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Utilities.Messages;

namespace PlanetWars.Core
{
    public class Controller : IController
    {
        private PlanetRepository planets;
        public Controller()
        {
            planets = new PlanetRepository();
        }

        public string CreatePlanet(string name, double budget)
        {
            if (planets.Models.Any(x => x.Name == name))
            {
                return String.Format(OutputMessages.ExistingPlanet, name);
            }

            var planet = new Planet(name, budget);
            planets.AddItem(planet);

            return String.Format(OutputMessages.NewPlanet, name);
        }

        public string AddUnit(string unitTypeName, string planetName)
        {
            var planet = planets.FindByName(planetName);

            if (planet == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (unitTypeName != nameof(StormTroopers) && unitTypeName != nameof(AnonymousImpactUnit) && unitTypeName != nameof(SpaceForces))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.ItemNotAvailable, unitTypeName));
            }

            if (planet.Army.Any(x => x.GetType().Name == unitTypeName))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName,
                    planetName));
            }

            IMilitaryUnit unit = null;

            if (unitTypeName == nameof(StormTroopers))
            {
                unit = new StormTroopers();
            }
            else if (unitTypeName == nameof(AnonymousImpactUnit))
            {
                unit = new AnonymousImpactUnit();
            }
            else
            {
                unit = new SpaceForces();
            }

            planet.Spend(unit.Cost);
            planet.AddUnit(unit); // order of operation not specified

            return String.Format(OutputMessages.UnitAdded, unitTypeName, planetName);
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            var planet = planets.FindByName(planetName);

            if (planet == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (planet.Weapons.Any(x => x.GetType().Name == weaponTypeName))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName,
                    planetName));
            }

            if (weaponTypeName != nameof(NuclearWeapon) && weaponTypeName != nameof(SpaceMissiles) && weaponTypeName != nameof(BioChemicalWeapon))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName));
            }

            IWeapon weapon = null;

            if (weaponTypeName == nameof(SpaceMissiles))
            {
                weapon = new SpaceMissiles(destructionLevel);
            }
            else if (weaponTypeName == nameof(BioChemicalWeapon))
            {
                weapon = new BioChemicalWeapon(destructionLevel);
            }
            else
            {
                weapon = new NuclearWeapon(destructionLevel);
            }

            planet.Spend(weapon.Price);
            planet.AddWeapon(weapon);

            return String.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);
        }

        public string SpecializeForces(string planetName)
        {
            var planet = planets.FindByName(planetName);

            if (planet == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (planet.Army.Count == 0)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.NoUnitsFound));
            }

            planet.Spend(1.25);
            planet.TrainArmy();

            return String.Format(OutputMessages.ForcesUpgraded, planetName);
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            var firstPlanet = planets.FindByName(planetOne);
            var secondPlanet = planets.FindByName(planetTwo);

            if (firstPlanet.MilitaryPower > secondPlanet.MilitaryPower) // first planet wins
            {
                firstPlanet.Spend(firstPlanet.Budget / 2);
                firstPlanet.Profit(secondPlanet.Budget / 2);
                firstPlanet.Profit(secondPlanet.Army.Sum(x => x.Cost) + secondPlanet.Weapons.Sum(x => x.Price));

                planets.RemoveItem(secondPlanet.Name);

                return String.Format(OutputMessages.WinnigTheWar, planetOne, planetTwo);
            }

            if (secondPlanet.MilitaryPower > firstPlanet.MilitaryPower) // second planet wins
            {
                secondPlanet.Spend(secondPlanet.Budget / 2);
                secondPlanet.Profit(firstPlanet.Budget / 2);
                secondPlanet.Profit(firstPlanet.Army.Sum(x => x.Cost) + firstPlanet.Weapons.Sum(x => x.Price));

                planets.RemoveItem(firstPlanet.Name);

                return String.Format(OutputMessages.WinnigTheWar, planetTwo, planetOne);
            }

            if (firstPlanet.Weapons.Any(x => x.GetType().Name == nameof(NuclearWeapon)) && secondPlanet.Weapons.All(x => x.GetType().Name != nameof(NuclearWeapon))) // first planet wins
            {
                firstPlanet.Spend(firstPlanet.Budget / 2);
                firstPlanet.Profit(secondPlanet.Budget / 2);
                firstPlanet.Profit(secondPlanet.Army.Sum(x => x.Cost) + secondPlanet.Weapons.Sum(x => x.Price));

                planets.RemoveItem(secondPlanet.Name);

                return String.Format(OutputMessages.WinnigTheWar, planetOne, planetTwo);
            } 
            
            if (secondPlanet.Weapons.Any(x => x.GetType().Name == nameof(NuclearWeapon)) &&
                  firstPlanet.Weapons.All(x => x.GetType().Name != nameof(NuclearWeapon))) // second planet wins
            {
                secondPlanet.Spend(secondPlanet.Budget / 2);
                secondPlanet.Profit(firstPlanet.Budget / 2);
                secondPlanet.Profit(firstPlanet.Army.Sum(x => x.Cost) + firstPlanet.Weapons.Sum(x => x.Price));

                planets.RemoveItem(firstPlanet.Name);

                return String.Format(OutputMessages.WinnigTheWar, planetTwo, planetOne);
            }

            firstPlanet.Spend(firstPlanet.Budget / 2);
            secondPlanet.Spend(secondPlanet.Budget / 2);

            return String.Format(OutputMessages.NoWinner);
        }

        public string ForcesReport()
        {
            var orderedPlanets = planets.Models
                .OrderByDescending(x => x.MilitaryPower)
                .ThenBy(x => x.Name);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"***UNIVERSE PLANET MILITARY REPORT***");

            foreach (var planet in orderedPlanets)
            {
                sb.AppendLine(planet.PlanetInfo());
            }

            return sb.ToString().Trim();
        }
    }
}
