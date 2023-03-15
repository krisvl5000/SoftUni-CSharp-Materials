using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;

namespace CarRacing.Repositories
{
    public class CarRepository : IRepository<ICar>
    {
        private List<ICar> models;

        public CarRepository()
        {
            models = new List<ICar>();
        }

        public IReadOnlyCollection<ICar> Models => models.AsReadOnly();

        public void Add(ICar model)
        {
            if (model == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InvalidAddRacerRepository));
            }

            models.Add(model);
        }

        public bool Remove(ICar model)
        {
            var carToRemove = models.FirstOrDefault(x => x.VIN == model.VIN);

            if (carToRemove == null)
            {
                return false;
            }

            models.Remove(carToRemove);
            return true;
        }

        public ICar FindBy(string property) => models.FirstOrDefault(x => x.VIN == property);
    }
}
