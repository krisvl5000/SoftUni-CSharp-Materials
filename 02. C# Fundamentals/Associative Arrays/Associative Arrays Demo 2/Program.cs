using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        class Student
        {
            public Student(string name, int age, bool isActive)
            {
                Name = name;
                Age = age;
                IsActive = isActive;
            }

            public string Name { get; set; }

            public int Age { get; set; }

            public bool IsActive { get; set; }
        }
        static void Main(string[] args)
        {
            var studentOne = new Student("Ivan", 15, true);
            var studentTwo = new Student("Stamat", 16, true);
            var studentThree = new Student("Maria", 17, true);
            var studentFour = new Student("John", 13, true);
            var studentFive = new Student("Eli", 15, false);

            List<Student> students = new List<Student>();
            {
                students.Add(studentOne);
                students.Add(studentTwo);
                students.Add(studentThree);
                students.Add(studentFour);
                students.Add(studentFive);
            }

            //1. All the students that are above 14 years

            var above14Students = students
                .Where(student => student.Age > 14)
                .Select(student => student.Name)
                .ToList();

            Console.WriteLine(String.Join(" ", above14Students));

            //2. All the students that are active

            var allActiveStudents = students
                .Where(student => student.IsActive == true)
                .Select(student => student.Name)
                .ToList();

            Console.WriteLine(String.Join(" ", allActiveStudents));

            //3. All the names of the students that are inactive

            var allInactiveStudents = students
                .Where(student => student.IsActive == false)
                .Select(student => student.Name)
                .ToList();

            Console.WriteLine(String.Join(" ", allInactiveStudents));

            //4. The average age of all students

            var ageSum = students
                .Average(student => student.Age);

            Console.WriteLine(ageSum);

            //5. Are there any inactive students?

            bool isThereInactiveStudents = students
                .Any(student => student.IsActive == false);

            Console.WriteLine(isThereInactiveStudents);

        }
    }
}