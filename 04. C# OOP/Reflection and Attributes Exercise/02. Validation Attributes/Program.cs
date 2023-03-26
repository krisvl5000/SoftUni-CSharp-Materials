using _02._Validation_Attributes.Models;
using ValidationAttributes.Utilities;

namespace _02._Validation_Attributes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var person = new Person("Pesho", 20);

            bool isValidEntity = Validator.IsValid(person);

            Console.WriteLine(isValidEntity); // Needs touch ups

        }
    }
}