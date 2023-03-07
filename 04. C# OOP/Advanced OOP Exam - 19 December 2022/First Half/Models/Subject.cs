using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Models
{
    public abstract class Subject : ISubject
    {
        public Subject(int subjectId, string subjectName, double subjectRate)
        {
            Id = subjectId;
            Name = subjectName;
            Rate = subjectRate;
        }

        private int id;

        public int Id
        {
            get { return id; }
            private set // might have to be public so it can be set from outside
            {
                id = value;
            }
        }

        private string name;

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(String
                        .Format(ExceptionMessages.NameNullOrWhitespace));
                }
                name = value;
            }
        }

        private double rate;

        public double Rate
        {
            get { return rate; }
            private set
            {
                rate = value;
            }
        }

    }
}
