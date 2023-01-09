//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace _01._Hello_Softuni
//{
//    internal class Person
//    {
//        public Person(string name, string iD, int age)
//        {
//            Name = name;
//            ID = iD;
//            Age = age;
//        }

//        public string Name { get; set; }

//        public string ID { get; set; }

//        public int Age { get; set; }

//        public override string ToString()
//        {
//            return $"{this.Name} with ID: {this.ID} " +
//                    $"is {this.Age} years old.";
//        }
//    }
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            List<Person> list = new List<Person>();
//            List<string> idList = new List<string>();

//            string[] input = Console.ReadLine().Split().ToArray();

//            while (input[0] != "End")
//            {
//                string name = input[0];
//                string ID = input[1];
//                int age = int.Parse(input[2]);                

//                Person newPerson = new Person(name, ID, age);

//                if (DoesPersonExist(idList, ID))
//                {
//                    newPerson.Age = age;
//                    newPerson.Name = name;
//                    input = Console.ReadLine().Split().ToArray();
//                    continue;
//                }
//                else
//                {
//                    idList.Add(ID);
//                }

//                list.Add(newPerson);

//                input = Console.ReadLine().Split().ToArray();
//            }

//            List<Person> orderedList = list.OrderBy(x => x.Age).ToList();

//            //foreach (Person person in orderedList)
//            //{
//            //    Console.WriteLine($"{person.Name} with ID: {person.ID} " +
//            //        $"is {person.Age} years old.");
//            //}

//            foreach (Person person in orderedList)
//            {
//                Console.WriteLine(person);
//            }

//        }

//        static bool DoesPersonExist(List<string> idList, string newId)
//        {
//            if (idList.Contains(newId))
//            {
//                return true;
//            }
//            return false;
//        }
//    }
//}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Hello_Softuni
{
    public class Person
    {
        public Person(string name, string newId, int age)
        {
            Name = name;
            ID = newId;
            Age = age;
        }

        public string Name { get; set; }

        public string ID { get; set; }

        public int Age { get; set; }

        public override string ToString()
        {
            return $"{this.Name} with {this.ID} is {this.Age} years old.";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> list = new List<Person>();
            List<string> idList = new List<string>();
            
            string[] input = Console.ReadLine().Split().ToArray();

            while (input[0] != "End")
            {
                string name = input[0];
                string ID = input[1];
                int age = int.Parse(input[2]);

                Person newPerson = new Person(name, ID, age);

                if (DoesPersonExist(idList, ID))
                {
                    newPerson.Name = name;
                    newPerson.Age = age;
                    input = Console.ReadLine().Split().ToArray();
                    continue;
                }
                else
                {
                    idList.Add(ID);
                }
                list.Add(newPerson);
            }

            List<Person> orderedPeople = list.OrderBy(p => p.Age).ToList();
            foreach (Person person in orderedPeople)
            {
                Console.WriteLine(person);
            }

        }

        static bool DoesPersonExist(List<string> idList, string newId)
        {
            if (idList.Contains(newId))
            {
                return true;
            }

            return false;
        }
    }
}