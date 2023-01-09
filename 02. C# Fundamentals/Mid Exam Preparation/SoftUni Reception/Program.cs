using System; 

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int emp1 = int.Parse(Console.ReadLine());
            int emp2 = int.Parse(Console.ReadLine());
            int emp3 = int.Parse(Console.ReadLine());

            int totalQuestions = emp1 + emp2 + emp3;

            int students = int.Parse(Console.ReadLine());

            int counter = 0;

            do
            {
                if (students <= 0 || totalQuestions <= 0)
                {
                    break;
                }
                students -= totalQuestions;
                counter++;

                if (counter % 4 == 0)
                {
                    counter++;
                }

            } while (students > 0);

            Console.WriteLine($"Time needed: {counter}h.");

        }
    }
}