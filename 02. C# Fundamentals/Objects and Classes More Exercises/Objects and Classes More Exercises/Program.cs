using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Hello_Softuni
{
    public class Employee
    {
        public Employee(string name, double salary)
        {
            this.Name = name;
            this.Salary = salary;
        }

        public string Name { get; set; }

        public double Salary { get; set; }
    }

    public class Department
    {
        public Department(string departmentName)
        {
            DepartmentName = departmentName;
        }

        public string DepartmentName { get; set; }

        public List<Employee> Employees { get; set; } = new List<Employee>();

        public double TotalSalaries { get; set; }

        public void AddNewEmployee(string empName, double empSalary)
        {
            this.TotalSalaries += empSalary;
            this.Employees.Add(new Employee(empName, empSalary));
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Department> departments = new List<Department>();

            int numberOfEmployees = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfEmployees; i++)
            {
                string[] inputArr = Console.ReadLine().Split();

                if (!departments.Any(d => d.DepartmentName == inputArr[2]))
                {
                    departments.Add(new Department(inputArr[2]));
                }

                Department currentDepartment = departments
                    .Find(d => d.DepartmentName == inputArr[2]);

                string employeeName = inputArr[0];
                double employeeSalary = double.Parse(inputArr[1]);

                currentDepartment.AddNewEmployee(employeeName, employeeSalary);
            }

            Department bestDepartment = departments
                .OrderByDescending(d => d.TotalSalaries / d.Employees.Count()).First();

            Console.WriteLine($"Highest Average Salary: {bestDepartment.DepartmentName}");

            foreach (var employee in bestDepartment.Employees.OrderByDescending(e => e.Salary))
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:F2}");
            }

        }
    }
}