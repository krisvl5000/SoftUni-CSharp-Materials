using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        private string name;
        private int neededRenovators;
        private string project;
        private List<Renovator> renovators;

        public Catalog(string name, int neededRenovators, string project)
        {
            this.Name = name;
            this.NeededRenovators = neededRenovators;
            this.Project = project;
            this.renovators = new List<Renovator>();
        }

        public string Name { get; private set; }

        public int NeededRenovators { get; private set; }

        public string Project { get; private set; }

        public IReadOnlyCollection<Renovator> Renovators => this.renovators;

        public int Count => this.Renovators.Count;

        public string AddRenovator(Renovator renovator)
        {
            if (string.IsNullOrEmpty(renovator.Name) 
                || string.IsNullOrEmpty(renovator.Type))
            {
                return "Invalid renovator's information.";
            }
            if (this.Count == this.NeededRenovators)
            {
                return "Renovators are no more needed.";
            }
            if (renovator.Rate > 350)
            {
                return "Invalid renovator's rate.";
            }
            this.renovators.Add(renovator);
            return $"Successfully added {renovator.Name} to the catalog";
        }

        public bool RemoveRenovator(string name)
        {
            var targetRenovator = this.Renovators.FirstOrDefault(x => x.Name == name);

            if (targetRenovator == null)
            {
                return false;
            }

            this.renovators.Remove(targetRenovator);
            return true;
        }

        public int RemoveRenovatorBySpecialty(string type)
        {
            var result = 0;
            while (this.Renovators.FirstOrDefault(x => x.Type == type) != null)
            {
                var targetRenovator = this.Renovators.FirstOrDefault(x => x.Type == type);
                this.renovators.Remove(targetRenovator);
                result++;
            }

            return result;
        }

        public Renovator HireRenovator(string name)
        {
            var targetRenovator = this.Renovators.FirstOrDefault(x => x.Name == name);

            if (targetRenovator == null)
            {
                return null;
            }

            this.Renovators.FirstOrDefault(x => x.Name == name).Hired = true;
            return targetRenovator;
        }

        public List<Renovator> PayRenovators(int days)
        {
            List<Renovator> paidRenovators = new List<Renovator>();

            foreach (var item in this.Renovators.Where(x => x.Days >= days))
            {
                paidRenovators.Add(item);
            }

            return paidRenovators;
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Renovators available for Project {this.Project}:");

            foreach (var item in this.Renovators.Where(x => x.Hired == false).Where(x => x.Paid == false))
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
