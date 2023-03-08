using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using PlanetWars.Core.Contracts;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Repositories.Contracts;
using PlanetWars.Utilities.Messages;

namespace PlanetWars.Core
{
    public class Controller : IController
    {
        private IRepository<IPlanet> planetRepository;

        public Controller()
        {
            planetRepository = new PlanetRepository();
        }

        public string CreatePlanet(string name, double budget)
        {
            if (planetRepository.Models.Any(x => x.Name == name))
            {
                return  String.Format(OutputMessages.ExistingPlanet, name);
            }

            IPlanet planet = new Planet(name, budget);
            return String.Format(OutputMessages.NewPlanet, name);
        }

        public string AddUnit(string unitTypeName, string planetName)
        {
            var planet = planetRepository.Models.FirstOrDefault(x => x.Name == planetName);

            if (planet == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (unitTypeName != "AnonymousImpactUnit" &&
                unitTypeName != "SpaceForces" &&
                unitTypeName != "StormTroopers")
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.ItemNotAvailable, unitTypeName));
            }

            if (planetRepository.Models.Any(x => x.GetType().Name == unitTypeName))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName,
                    planetName));
            }

            IMilitaryUnit unit = null;

            if (unitTypeName == "AnonymousImpactUnit")
            {
                unit = new AnonymousImpactUnit();
            }
            else if (unitTypeName == "SpaceForces")
            {
                unit = new SpaceForces();
            }
            else if (unitTypeName == "StormTroopers")
            {
                unit = new StormTroopers();
            }

            planet.AddUnit(unit);

            return String.Format(OutputMessages.UnitAdded, unitTypeName, planetName);

        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            var planet = planetRepository.Models.FirstOrDefault(x => x.Name == planetName);

            if (planet == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (weaponTypeName != "BioChemicalWeapon" &&
                weaponTypeName != "NuclearWeapon" &&
                weaponTypeName != "SpaceMissiles")
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName));
            }

            if (planetRepository.Models.Any(x => x.GetType().Name == weaponTypeName))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName,
                    planetName));
            }

            IWeapon weapon = null;

            if (weaponTypeName == "BioChemicalWeapon")
            {
                weapon = new BioChemicalWeapon(destructionLevel);
            }
            else if (weaponTypeName == "NuclearWeapon")
            {
                weapon = new NuclearWeapon(destructionLevel);
            }
            else if (weaponTypeName == "SpaceMissiles")
            {
                weapon = new SpaceMissiles(destructionLevel);
            }

            planet.AddWeapon(weapon);

            return String.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);
        }

        public string SpecializeForces(string planetName)
        {
            var planet = planetRepository.Models.FirstOrDefault(x => x.Name == planetName);

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
            var firstPlanet = planetRepository.FindByName(planetOne);
            var secondPlanet = planetRepository.FindByName(planetTwo);

            var winningPlanet = "";

            if (firstPlanet.MilitaryPower == secondPlanet.MilitaryPower)
            {
                if ((firstPlanet.Weapons.Any(x => x.GetType().Name == "NuclearWeapon") && 
                    secondPlanet.Weapons.Any(x => x.GetType().Name == "NuclearWeapon"))  || (firstPlanet.Weapons.All(x => x.GetType().Name != "NuclearWeapon") && secondPlanet.Weapons.All(x => x.GetType().Name != "NuclearWeapon"))) // no one wins
                {
                    firstPlanet.Spend(firstPlanet.Budget / 2);
                    secondPlanet.Spend(secondPlanet.Budget / 2);
                    return String.Format(OutputMessages.NoWinner);
                }

                if (firstPlanet.Weapons.Any(x => x.GetType().Name == "NuclearWeapon")) // first planet wins
                {
                    firstPlanet.Spend(firstPlanet.Budget / 2);
                    firstPlanet.Profit(secondPlanet.Budget / 2);

                    double allForcesAndWeaponsCost = 0.0;

                    foreach (var unit in secondPlanet.Army)
                    {
                        allForcesAndWeaponsCost += unit.Cost;
                    }

                    foreach (var weapon in secondPlanet.Weapons)
                    {
                        allForcesAndWeaponsCost += weapon.Price;
                    }

                    firstPlanet.Profit(allForcesAndWeaponsCost);
                    planetRepository.RemoveItem(planetTwo);

                    return String.Format(OutputMessages.WinnigTheWar, firstPlanet, secondPlanet);
                }
                else if (secondPlanet.Weapons.Any(x => x.GetType().Name == "NuclearWeapon")) // second planet wins
                {
                    secondPlanet.Spend(secondPlanet.Budget / 2);
                    secondPlanet.Profit(firstPlanet.Budget / 2);

                    double allForcesAndWeaponsCost = 0.0;

                    foreach (var unit in firstPlanet.Army)
                    {
                        allForcesAndWeaponsCost += unit.Cost;
                    }

                    foreach (var weapon in firstPlanet.Weapons)
                    {
                        allForcesAndWeaponsCost += weapon.Price;
                    }

                    secondPlanet.Profit(allForcesAndWeaponsCost);
                    planetRepository.RemoveItem(planetOne);

                    return String.Format(OutputMessages.WinnigTheWar, secondPlanet, firstPlanet);
                }
            }

            if (firstPlanet.MilitaryPower > secondPlanet.MilitaryPower) // first planet wins
            {
                firstPlanet.Spend(firstPlanet.Budget / 2);
                firstPlanet.Profit(secondPlanet.Budget / 2);

                double allForcesAndWeaponsCost = 0.0;

                foreach (var unit in secondPlanet.Army)
                {
                    allForcesAndWeaponsCost += unit.Cost;
                }

                foreach (var weapon in secondPlanet.Weapons)
                {
                    allForcesAndWeaponsCost += weapon.Price;
                }

                firstPlanet.Profit(allForcesAndWeaponsCost);
                planetRepository.RemoveItem(planetTwo);

                return String.Format(OutputMessages.WinnigTheWar, firstPlanet, secondPlanet);
            }
            else // second planet wins
            {
                secondPlanet.Spend(secondPlanet.Budget / 2);
                secondPlanet.Profit(firstPlanet.Budget / 2);

                double allForcesAndWeaponsCost = 0.0;

                foreach (var unit in firstPlanet.Army)
                {
                    allForcesAndWeaponsCost += unit.Cost;
                }

                foreach (var weapon in firstPlanet.Weapons)
                {
                    allForcesAndWeaponsCost += weapon.Price;
                }

                secondPlanet.Profit(allForcesAndWeaponsCost);
                planetRepository.RemoveItem(planetOne);

                return String.Format(OutputMessages.WinnigTheWar, secondPlanet, firstPlanet);
            }
        }

        public string ForcesReport()
        {
            var orderedPlanets = planetRepository.Models.OrderByDescending(x => x.MilitaryPower).ThenBy(x => x.Name);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("***UNIVERSE MILITARY REPORT***");

            foreach (var planet in orderedPlanets)
            {
                sb.AppendLine(planet.PlanetInfo());
            }

            return sb.ToString().Trim();
        }
    }
}
