using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NavalVessels.Models.Contracts;
using NavalVessels.Repositories.Contracts;

namespace NavalVessels.Repositories
{
    public class VesselRepository : IRepository<IVessel>
    {
        public VesselRepository()
        {
            models = new List<IVessel>();
        }

        private List<IVessel> models;

        public IReadOnlyCollection<IVessel> Models => models.AsReadOnly();

        public void Add(IVessel model)
        {
            models.Add(model);
        }

        public bool Remove(IVessel model)
        {
            var vesselToRemove = models.FirstOrDefault(x => x.Name == model.Name);

            if (vesselToRemove == null)
            {
                return false;
            }

            models.Remove(vesselToRemove);
            return true;
        }

        public IVessel FindByName(string name)
        {
            return models.FirstOrDefault(x => x.Name == name);
        }
    }
}
