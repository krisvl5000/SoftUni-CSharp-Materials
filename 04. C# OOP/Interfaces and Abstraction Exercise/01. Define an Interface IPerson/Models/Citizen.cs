namespace PersonInfo.Models
{
    using Interfaces;

    public class Citizen : IPerson
    {
        private string name;
        private int age;

        public Citizen(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name
        {
            get { return name; }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Name cannot be null or empty!");
                }

                name = value;
            }
        }

        public int Age
        {
            get { return age; }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Age must be a positive number!");
                }

                age = value;
            }
        }
    }
}
