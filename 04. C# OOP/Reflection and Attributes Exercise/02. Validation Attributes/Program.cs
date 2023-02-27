using ValidationAttributes.Models;
using ValidationAttributes.Utilities;


namespace ValidationAttributes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var person = new Person(null, -1);

            bool isValidEntity = Validator.IsValid(person);

            Console.WriteLine(isValidEntity);

        }
    }
}