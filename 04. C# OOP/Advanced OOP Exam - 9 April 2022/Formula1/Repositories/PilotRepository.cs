using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;

namespace Formula1.Repositories
{
    public class PilotRepository : IRepository<IPilot>
    {
        public PilotRepository()
        {
            models = new List<IPilot>();
        }

        private List<IPilot> models;

        public IReadOnlyCollection<IPilot> Models => models.AsReadOnly();

        public void Add(IPilot model)
        {
            models.Add(model);
        }

        public bool Remove(IPilot model)
        {
            return models.Remove(model);
        }

        public IPilot FindByName(string name)
        {
            return models.FirstOrDefault(x => x.FullName == name);
        }
    }
}
