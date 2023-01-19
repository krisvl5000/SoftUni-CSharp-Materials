using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DefiningClasses;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Family family = new Family();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = input[0];
                int age = int.Parse(input[1]);

                Person person = new Person(name, age);
                family.AddMember(person);
            }

            List<Person> filteredPeople = family.List
                .Where(x => x.Age > 30)
                .OrderBy(x => x.Name)
                .ToList();

            foreach (var item in filteredPeople)
            {
                Console.WriteLine($"{item.Name} - {item.Age}");
            }
        }
    }
}