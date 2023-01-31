namespace PersonInfo
{
    public class Citizen : IPerson, IIdentifiable, IBirthable
    {
        private string name;
        private int age;
        private string id;
        private string birthdate;

        public Citizen(string name, int age, string id, string birthdate)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthdate;
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

        public string Id
        {
            get { return id; }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Id cannot be null or empty!");
                }

                id = value;
            }
        }

        public string Birthdate
        {
            get { return birthdate; }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Birthdate cannot be null or empty!");
                }

                birthdate = value;
            }
        }
    }
}
