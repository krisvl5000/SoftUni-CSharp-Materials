using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    public class Person
    {
        private string name;
        private int age;

        public Person(string name, int age)
        {
            Name = name;
            Age = age;

            if (age < 0)
            {
                age = 0;
            }
            else if (age > 15)
            {
                age = 15;
            }
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(String.Format($"Name: {Name}, Age: {Age}"));

            return sb.ToString();
        }
    }
}
