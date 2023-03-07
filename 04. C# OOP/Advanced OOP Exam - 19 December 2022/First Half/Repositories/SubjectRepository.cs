using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class SubjectRepository : IRepository<ISubject>
    {
        public SubjectRepository()
        {
            models = new List<ISubject>();
        }

        private List<ISubject> models;

        public IReadOnlyCollection<ISubject> Models => models.AsReadOnly();

        public void AddModel(ISubject model)
        {
            models.Add(model);
        }

        public ISubject FindById(int id)
        {
            return models.FirstOrDefault(x => x.Id == id);
        }

        public ISubject FindByName(string name)
        {
            return models.FirstOrDefault(x => x.Name == name);
        }
    }
}
