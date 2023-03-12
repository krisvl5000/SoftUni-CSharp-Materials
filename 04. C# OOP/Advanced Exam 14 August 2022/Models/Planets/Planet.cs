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
        public Planet(string name, double budget)
        {
            Name = name;
            Budget = budget;
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
            get { return CalculateMilitaryPower(); }
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
            get { return weapons.AsReadOnly(); }
        }


        public void AddUnit(IMilitaryUnit unit)
        {
            Spend(unit.Cost); // might not need to be implemented for units
            army.Add(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            Spend(weapon.Price);
            weapons.Add(weapon);  
        }

        public void TrainArmy()
        {
            foreach (var unit in army)
            {
                unit.IncreaseEndurance();
            }
        }

        public void Spend(double amount)
        {
            if (Budget < amount)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.UnsufficientBudget));
            }

            Budget -= amount;
        }

        public void Profit(double amount)
        {
            Budget += amount;
        }

        public string PlanetInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Planet: {Name}");
            sb.AppendLine($"--Budget: {Budget} billion QUID");

            if (Army.Count > 0)
            {
                var list = army.Select(x => x.GetType().Name).ToList();
                sb.AppendLine($"--Forces: {String.Join(", ", list)}"); // might not print the names
            }
            else
            {
                sb.AppendLine("--Forces: No units");
            }
            if (Weapons.Count > 0)
            {
                var list = weapons.Select(x => x.GetType().Name).ToList();

                sb.AppendLine($"--Combat equipment: {String.Join(", ", list)}"); // might not print the names
            }
            else
            {
                sb.AppendLine("--Combat equipment: No weapons");
            }

            sb.AppendLine($"--Military Power: {CalculateMilitaryPower()}");

            return sb.ToString().Trim();
        }
    }
}
