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
            throw new NotImplementedException();
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            throw new NotImplementedException();
        }

        public string ForcesReport()
        {
            throw new NotImplementedException();
        }
    }
}
