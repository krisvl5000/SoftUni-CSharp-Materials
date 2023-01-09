using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Hello_Softuni
{
    class Family
    {
        public Family()
        {
            List<Person> list = new List<Person>();
        }

        public List<Person> List { get; set; }

        public void AddMember(Person member, List<Person> peopleList)
        {
            peopleList.Add(member);
        }

        public static Person GetOldestMember(List<Person> peopleList)
        {
            List<Person> orderedPeople = peopleList.OrderByDescending(b => b.Age).ToList();
            Person oldestPerson = orderedPeople[0];
            return oldestPerson;
        }
       
    }

    class Person
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }

        public int Age { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> peopleList = new List<Person>();

            Family family = new Family();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split().ToArray();

                string name = input[0];
                int age = int.Parse(input[1]);

                Person newPerson = new Person(name, age);

                family.AddMember(newPerson, peopleList);
            }

            Person oldestPerson = Family.GetOldestMember(peopleList);

            Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");


        }
    }
}