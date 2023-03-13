using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Repositories.Contracts;
using Gym.Utilities.Messages;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {
        public Gym(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;

            equipment = new List<IEquipment>();
            athletes = new List<IAthlete>();
        }

        private string name;

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidGymName));
                }
                name = value;
            }
        }

        public int Capacity { get; }

        public double EquipmentWeight => equipment.Sum(x => x.Weight);

        private List<IEquipment> equipment;
        public ICollection<IEquipment> Equipment => equipment;

        private List<IAthlete> athletes;
        public ICollection<IAthlete> Athletes => athletes;

        public void AddAthlete(IAthlete athlete)
        {
            if (athletes.Count < Capacity)
            {
                athletes.Add(athlete);
            }
            else
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.NotEnoughSize));
            }
        }

        public bool RemoveAthlete(IAthlete athlete)
        {
            var athleteToRemove = athletes.FirstOrDefault(x => x.FullName == athlete.FullName);

            if (athleteToRemove == null)
            {
                return false;
            }

            athletes.Remove(athleteToRemove);
            return true;
        }

        public void AddEquipment(IEquipment equipment)
        {
            this.equipment.Add(equipment);
        }

        public void Exercise()
        {
            foreach (var athlete in athletes)
            {
                athlete.Exercise();
            }
        }

        public string GymInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{Name} is a {GetType().Name}");

            if (!athletes.Any())
            {
                sb.AppendLine($"Athletes: No athletes");
            }
            else
            {
                var list = new List<string>();

                foreach (var athlete in athletes)
                {
                    list.Add(athlete.FullName);
                }

                sb.AppendLine($"Athletes: {String.Join(", ", list)}");
            }

            sb.AppendLine($"Equipment total count: {equipment.Count}");
            sb.AppendLine($"Equipment total weight: {EquipmentWeight:F2} grams");

            return sb.ToString().TrimEnd();
        }
    }
}
