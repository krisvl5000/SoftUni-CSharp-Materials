using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories.Contracts;
using PlanetWars.Utilities.Messages;

namespace PlanetWars.Models.Planets
{
    public class Planet : IPlanet
    {
        public Planet()
        {
            army = new List<IMilitaryUnit>();
            weapons = new List<IWeapon>();
        }

        private string name;

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(String.Format(ExceptionMessages.InvalidPlanetName));
                }
                name = value;
            }
        }

        private double budget;

        public double Budget
        {
            get { return budget; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidBudgetAmount));
                }
                budget = value;
            }
        }

        private double militaryPower;

        public double MilitaryPower
        {
            get { return militaryPower; }
            private set
            {
                value = CalculateMilitaryPower();
                militaryPower = value;
            }
        }

        private double CalculateMilitaryPower()
        {
            double sumOfPower = 0;

            foreach (var unit in Army)
            {
                sumOfPower += unit.EnduranceLevel;
            }

            foreach (var weapon in Weapons)
            {
                sumOfPower += weapon.DestructionLevel;
            }

            if (Army.Any(x => x.GetType().Name == "AnonymousImpactUnit"))
            {
                sumOfPower += sumOfPower * 30 / 100;
            }

            if (Weapons.Any(x => x.GetType().Name == "NuclearWeapon"))
            {
                sumOfPower += sumOfPower * 45 / 100;
            }

            return Math.Round(sumOfPower, 3);

        }

        private List<IMilitaryUnit> army;

        public IReadOnlyCollection<IMilitaryUnit> Army
        {
            get { return army.AsReadOnly(); }
        }

        private List<IWeapon> weapons;

        public IReadOnlyCollection<IWeapon> Weapons
        {
            get { return weapons.AsReadOnly(); } // might need to add setters
        }


        public void AddUnit(IMilitaryUnit unit)
        {
            throw new NotImplementedException();
        }

        public void AddWeapon(IWeapon weapon)
        {
            throw new NotImplementedException();
        }

        public void TrainArmy()
        {
            throw new NotImplementedException();
        }

        public void Spend(double amount)
        {
            throw new NotImplementedException();
        }

        public void Profit(double amount)
        {
            throw new NotImplementedException();
        }

        public string PlanetInfo()
        {
            throw new NotImplementedException();
        }
    }
}
