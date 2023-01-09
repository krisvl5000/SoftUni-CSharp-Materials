using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Hello_Softuni
{
    internal class Student
    {
        public Student(string name1, string name2, string age, string hometown)
        {
            FirstName = name1;
            LastName = name2;
            Age = age;
            Hometown = hometown;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Age { get; set; }

        public string Hometown { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            string[] input = Console.ReadLine().Split().ToArray();

            while (input[0] != "end")
            {
                string name1 = input[0];
                string name2 = input[1];
                string age = input[2];
                string hometown = input[3];

                Student student = new Student(name1, name2, age, hometown);
                students.Add(student);

                input = Console.ReadLine().Split().ToArray();
            }

            string town = Console.ReadLine();

            List<Student> townStudents = new List<Student>();

            foreach (var student in students)
            {
                if (student.Hometown == town)
                {
                    townStudents.Add(student);
                }
            }

            foreach (var student in townStudents)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} " +
                    $"is {student.Age} years old.");
            }

        }
    }
}