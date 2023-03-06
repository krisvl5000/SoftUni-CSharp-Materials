using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;

namespace Formula1.Repositories
{
    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        public FormulaOneCarRepository()
        {
            models = new List<IFormulaOneCar>();
        }

        private List<IFormulaOneCar> models;

        public IReadOnlyCollection<IFormulaOneCar> Models => models.AsReadOnly();

        public void Add(IFormulaOneCar model)
        {
            models.Add(model);
        }

        public bool Remove(IFormulaOneCar model)
        {
            return models.Remove(model);
        }

        public IFormulaOneCar FindByName(string name)
        {
            return models.FirstOrDefault(x => x.Model == name);
        }
    }
}
