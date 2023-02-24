using System;
using System.Net;
using System.Reflection;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student();
            PrintProperties(DateTime.Now);
        }

        public static void PrintProperties(object obj)
        {
            PropertyInfo[] properties = obj.GetType().GetProperties(); 

            foreach (var property in properties)
            {
                Console.WriteLine($"{property.Name} : {property.PropertyType}");
            }
        }
    }

    public class Student
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public double Score { get; set; }

        public Student Friend { get; set; }
    }
}