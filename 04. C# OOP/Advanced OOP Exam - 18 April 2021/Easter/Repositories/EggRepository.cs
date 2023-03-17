using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Easter.Models.Eggs.Contracts;
using Easter.Repositories.Contracts;

namespace Easter.Repositories
{
    public class EggRepository : IRepository<IEgg>
    {
        private List<IEgg> models;

        public EggRepository()
        {
            models = new List<IEgg>();
        }

        public IReadOnlyCollection<IEgg> Models => models.AsReadOnly();

        public void Add(IEgg model)
        {
            models.Add(model);
        }

        public bool Remove(IEgg model)
        {
            if (models.All(x => x.Name != model.Name))
            {
                return false;
            }

            models.Remove(model);
            return true;
        }

        public IEgg FindByName(string name) => models.FirstOrDefault(x => x.Name == name);
    }
}
