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
        }

        public string Name { get; set; }

        public int NeededRenovators { get; set; }

        public string Project { get; set; }

        public int Count => renovators.Count;

        public string AddRenovator(Renovator renovator)
        {
            if (string.IsNullOrEmpty(renovator.Name)||
                string.IsNullOrEmpty(renovator.Type))
            {
                return "Invalid renovator's information.";
            }
            else if (renovators.Count == NeededRenovators)
            {
                return "Renovators are no more needed.";
            }
            else if (renovator.Rate > 350)
            {
                return "Invalid renovator's rate.";
            }

            return $"Successfully added {renovator.Name} to hte catalog.";
        }

        public bool RemoveRenovator(string name)
        {
            Renovator renovatorToRemove = renovators.FirstOrDefault(r => r.Name == name);

            if (renovatorToRemove != null)
            {
                renovators.Remove(renovatorToRemove);
                return true;
            }

            return false;
        }

        public int RemoveRenovatorBySpecialty(string type)
        {
            int counter = 0;

            foreach (var renovator in renovators)
            {
                if (renovator.Type == type)
                {
                    renovators.Remove(renovator);
                    counter++;
                }
            }

            return counter;
        }

        public Renovator HireRenovator(string name)
        {
            Renovator renovatorToHire = renovators.FirstOrDefault(r => r.Name == name);

            if (renovatorToHire == null)
            {
                return null;
            }

            renovatorToHire.Hired = true;
            return renovatorToHire;
        }

        public List<Renovator> PayRenovators(int days)
        {
            List<Renovator> renovatorsToBePaid = new List<Renovator>();

            foreach (var renovator in renovators)
            {
                if (renovator.Days >= days)
                {
                    renovatorsToBePaid.Add(renovator);
                }
            }

            return renovatorsToBePaid;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Renovators available for Project {Project}:");

            foreach (var renovator in renovators)
            {
                sb.AppendLine(renovator.ToString());
            }

            return sb.ToString().TrimEnd();
        }


    }
}
