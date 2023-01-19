using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> list;

        public List<Person> List { get; set; } = new List<Person>();

        public void AddMember(Person member)
        {
            List.Add(member);
        }

        public Person GetOldestMember()
        {
            return list.OrderBy(x => x.Age).First();
        }
    }
}
