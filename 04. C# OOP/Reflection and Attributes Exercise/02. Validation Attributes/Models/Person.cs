using ValidationAttributes.Utilities.Attributes;

namespace ValidationAttributes.Models;

public class Person
{
    private const int MINAGE = 12;
    private const int MAXAGE = 90;

    public Person(string fullName, int age)
    {
        FullName = fullName;
        Age = age;
    }

    [MyRequired]
    public string FullName { get; private set; }

    [MyRange(MINAGE, MAXAGE)]
    public int Age { get; private set; }
}