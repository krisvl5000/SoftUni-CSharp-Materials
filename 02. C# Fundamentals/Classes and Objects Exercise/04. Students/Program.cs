using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Hello_Softuni
{
    internal class Student
    {
        public Student(string firstName, string secondName, double grade)
        {
            FirstName = firstName;
            SecondName = secondName;
            Grade = grade;
        }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public double Grade { get; set; }

        public override string ToString()
        {
            return $"{this.FirstName} {this.SecondName}: {this.Grade:F2}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfStudents = int.Parse(Console.ReadLine());

            List<Student> list = new List<Student>();

            for (int i = 0; i < numberOfStudents; i++)
            {
                string[] input = Console.ReadLine().Split().ToArray();

                string firstName = input[0];
                string secondName = input[1];
                double grade = double.Parse(input[2]);

                Student student = new Student(firstName, secondName, grade);
                list.Add(student);
            }

            List<Student> sortedStudents = list.OrderByDescending(student => student.Grade).ToList();

            //foreach (var student in sortedStudents)
            //{
            //    Console.WriteLine($"{student.FirstName} {student.SecondName}: {student.Grade:F2}");
            //}

            foreach (var student in sortedStudents)
            {
                Console.WriteLine(student);
            }

        }
    }
}