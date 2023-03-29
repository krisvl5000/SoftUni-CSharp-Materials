using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Utilities.Messages;

namespace PlanetWars.Models.Planets
{
    public class Planet : IPlanet
    {
        private UnitRepository units;
        private WeaponRepository weapons;

        public Planet(string name, double budget)
        {
            Name = name;
            Budget = budget;

            units = new UnitRepository();
            weapons = new WeaponRepository();
        }

        private string name;

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidPlanetName));
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


        public IReadOnlyCollection<IMilitaryUnit> Army => units.Models;
        public IReadOnlyCollection<IWeapon> Weapons => weapons.Models;

        private double CalculateMilitaryPower()
        {
            double totalSum = Army.Sum(x => x.EnduranceLevel) + Weapons.Sum(x => x.DestructionLevel);

            if (Army.Any(x => x.GetType().Name == nameof(AnonymousImpactUnit)))
            {
                totalSum += totalSum * 30 / 100;
            }

            if (Weapons.Any(x => x.GetType().Name == nameof(NuclearWeapon))) // we do not know whether they stack
            {
                totalSum += totalSum * 45 / 100;
            }

            return Math.Round(totalSum, 3);
        }

        public void AddUnit(IMilitaryUnit unit)
        {
            units.AddItem(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            weapons.AddItem(weapon);
        }

        public void TrainArmy()
        {
            foreach (var unit in units.Models)
            {
                unit.IncreaseEndurance();
            }
        }

        public void Spend(double amount)
        {
            if (Budget - amount < 0)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnsufficientBudget));
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

            if (units.Models.Any())
            {
                var unitList = new List<string>();

                foreach (var militaryUnit in units.Models)
                {
                    unitList.Add(militaryUnit.GetType().Name);
                }

                sb.AppendLine($"--Forces: {String.Join(", ", unitList)}");
            }
            else
            {
                sb.AppendLine($"--Forces: No units");
            }

            if (weapons.Models.Any())
            {
                var weaponList = new List<string>();

                foreach (var weapon in weapons.Models)
                {
                    weaponList.Add(weapon.GetType().Name);
                }

                sb.AppendLine($"--Combat equipment: {String.Join(", ", weaponList)}");
            }
            else
            {
                sb.AppendLine($"--Combat equipment: No weapons");
            }

            sb.AppendLine($"--Military Power: {MilitaryPower}");

            return sb.ToString().Trim();
        }
    }
}
