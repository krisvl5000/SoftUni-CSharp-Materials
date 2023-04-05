using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;

namespace Formula1.Repositories
{
    public class RaceRepository : IRepository<IRace>
    {
        private List<IRace> models;

        public RaceRepository()
        {
            models = new List<IRace>();
        }

        public IReadOnlyCollection<IRace> Models => models.AsReadOnly();

        public void Add(IRace model)
        {
            models.Add(model);
        }

        public bool Remove(IRace model)
        {
            var raceToRemove = models.FirstOrDefault(x => x.RaceName == model.RaceName);

            if (raceToRemove == null)
            {
                return false;
            }

            models.Remove(model);
            return true;
        }

        public IRace FindByName(string name) => models.FirstOrDefault(x => x.RaceName == name);
    }
}
