using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();

            
            double grade = 0;
            double gradeSum = 0;
            double averageGrade = 0;
            double failThreshold = 0;

            while (grade < 12)
            {
                double gradeResult = double.Parse(Console.ReadLine());
                gradeSum += gradeResult;
               

                if (gradeResult < 4)
                {
                    failThreshold ++;
                    if (failThreshold > 1)
                    {
                        Console.WriteLine($"{name} has been excluded at {grade} grade");
                        break;
                    }
                }
                grade++;
            }
            averageGrade = gradeSum / grade;
            
            if (failThreshold < 2)
            {
                Console.WriteLine($"{name} graduated. Average grade: {averageGrade:F2}");
            }
        }
    }
}