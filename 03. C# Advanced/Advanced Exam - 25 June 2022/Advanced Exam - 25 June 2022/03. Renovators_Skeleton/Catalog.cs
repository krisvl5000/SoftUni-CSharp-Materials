using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        private List<Renovator> renovators;

        public Catalog(string name, int neededRenovators, string project)
        {
            Name = name;
            NeededRenovators = neededRenovators;
            Project = project;
            this.renovators = new List<Renovator>();
        }

        public string Name { get; set; }

        public int NeededRenovators { get; set; }

        public string Project { get; set; }

        public int Count => renovators.Count;

        public string AddRenovator(Renovator renovator)
        {
            if (renovator.Name != null && renovator.Type != null)
            {
                return "Invalid renovator's information.";
            }

            if (renovators.Count >= NeededRenovators)
            {
                return "Renovators are no more needed.";
            }

            if (renovator.Rate > 350)
            {
                return "Invalid renovator's rate.";
            }

            renovators.Add(renovator);
            return $"Successfully added {renovator.Name} to the catalog";
        }

        public bool RemoveRenovator(string name)
        {
            if (renovators.Any(x => x.Name == name))
            {
                Renovator renovatorToRemove = renovators
                    .FirstOrDefault(x => x.Name == name);

                renovators.Remove(renovatorToRemove);
                return true;
            }

            return false;
        }

        public int RemoveRenovatorBySpecialty(string type)
        {
            if (renovators.Any(x => x.Type == type))
            {
                List<Renovator> renovatorsToRemove = renovators
                    .Where(x => x.Type == type).ToList();

                foreach (var item in renovatorsToRemove)
                {
                    renovators.Remove(item);
                }

                return renovatorsToRemove.Count;
            }

            return 0;
        }

        public Renovator HireRenovator(string name)
        {
            if (renovators.Any(x => x.Name == name))
            {
                Renovator renovatorToHire = renovators.First(x => x.Name == name);
                renovatorToHire.Hired = true;
                return renovatorToHire;
            }

            return null;
        }

        public List<Renovator> PayRenovators(int days)
        {
            List<Renovator> renovators = new List<Renovator>();

            foreach (var item in renovators)
            {
                if (item.Days >= days)
                {
                    renovators.Add(item);
                }
            }

            return renovators;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Renovators available for Project {this.Project}:");

            foreach (var item in renovators)
            {
                if (!item.Hired)
                {
                    sb.AppendLine(item.ToString());
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
