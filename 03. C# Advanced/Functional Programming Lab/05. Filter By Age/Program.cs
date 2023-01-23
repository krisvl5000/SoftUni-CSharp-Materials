using System;

namespace _01._Hello_Softuni
{
    public class Person
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
            List<Person> list = new List<Person>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string name = input[0];
                int age = int.Parse(input[1]);

                list.Add(new Person(name, age));
            }

            string filterInput = Console.ReadLine();
            int ageFilter = int.Parse(Console.ReadLine());
            string formatInput = Console.ReadLine();

            Func<Person, int, bool> filter = GetFilter(filterInput);
            list = list.Where(x => filter(x, ageFilter)).ToList();

            Action<Person> printer = GetPrinter(formatInput);
            list.ForEach(printer);
        }

        private static Action<Person> GetPrinter(string formatInput)
        {
            switch (formatInput)
            {
                case "name":
                    return s => Console.WriteLine(s.Name);
                case "age":
                    return s => Console.WriteLine(s.Age);
                case "name age":
                    return s => Console.WriteLine(s.Name + " - " + s.Age);
                default:
                    return null;
            }
        }

        private static Func<Person, int, bool> GetFilter(string filterInput)
        {
            switch (filterInput)
            {
                case "older":
                    return (s, age) => s.Age >= age;
                case "younger":
                    return (s, age) => s.Age < age;
                default:
                    return null;
            }
        }
    }
}