using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public class Employee
    {
        public Employee()
        {

        }

        public Employee(string name)
        {
            Console.WriteLine($"In employee constructor with the name {name}");
            Name = name;
        }

        public Employee(decimal salary)
        {
            Console.WriteLine($"In employee constructor with salary {salary}");
        }

        public decimal Salary { get; set; }

        public string Name { get; set; }

        public int HappinessLevel { get; set; }

        public void GetPaid()
        {
            HappinessLevel += 10;
            Console.WriteLine("Yooho");
        }
    }
}
