using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;

namespace CarRacing.Repositories
{
    public class RacerRepository : IRepository<IRacer>
    {
        private List<IRacer> models;

        public RacerRepository()
        {
            models = new List<IRacer>();
        }

        public IReadOnlyCollection<IRacer> Models => models.AsReadOnly();

        public void Add(IRacer model)
        {
            if (model == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InvalidAddRacerRepository));
            }

            models.Add(model);
        }

        public bool Remove(IRacer model)
        {
            var racerToRemove = models.FirstOrDefault(x => x.Username == model.Username);

            if (racerToRemove == null)
            {
                return false;
            }

            models.Remove(racerToRemove);
            return true;
        }

        public IRacer FindBy(string property) => models.FirstOrDefault(x => x.Username == property);
    }
}
