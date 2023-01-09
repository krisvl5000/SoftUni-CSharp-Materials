//using System;
//using System.Linq;

//namespace _01._Hello_Softuni
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        { 
//            // size of the field
//            int fieldSize = int.Parse(Console.ReadLine());
//            // initial indexes of ladybugs separated by a blank space
//            int[] ladybugsIndexes = Console.ReadLine().
//                Split(' ', StringSplitOptions.RemoveEmptyEntries)
//                .Select(int.Parse)
//                .ToArray();

//            int[] field = new int[fieldSize];

//            for (int index = 0; index < fieldSize; index++)
//            {
//                if (ladybugsIndexes.Contains(index))
//                {
//                    //If index is present in ladybugsIndexes then there is a ladybug
//                    field[index] = 1;
//                }
//            }

//            //string command = Console.ReadLine();

//            //while (command != "end")
//            //{

//            //    command = Console.ReadLine();
//            //}

//            // IS THE SAME AS 

//            string command;
//            while ((command = Console.ReadLine()) != "end")
//            {
//                string[] cmdArgs = command
//                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
//                    .ToArray();

//                int initialIndex = int.Parse(cmdArgs[0]);
//                string direction = cmdArgs[1];
//                int flyLength = int.Parse(cmdArgs[2]);

//                if (initialIndex < 0 || initialIndex >= field.Length)
//                {
//                    continue;
//                }

//                // if there isnt a ladybug
//                if (field[initialIndex] == 0)
//                {
//                    continue;
//                }

//                field[initialIndex] = 0;

//                int nextIndex = initialIndex;
//                while (true)
//                {
//                    if (direction == "right")
//                    {
//                        nextIndex += flyLength;
//                    }    
//                    else if (direction == "left")
//                    {
//                        nextIndex -= flyLength;
//                    }

//                    if (nextIndex < 0 || nextIndex < field.Length)
//                    {
//                        // the ladybug disappears
//                        break;
//                    }

//                    if (field[nextIndex] == 0)
//                    {
//                        //the ladybug lands on the new spot
//                        break;
//                    }
//                }

//                if (nextIndex >= 0 && nextIndex < field.Length)
//                {
//                    field[nextIndex] = 1;
//                    break;
//                }

//            }

//            Console.WriteLine(String.Join(' ', field));

//        }
//    }
//}

using System;
using System.Linq;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); //size of the field

            int[] field = new int[n]; //field itself

            int[] initialIndexes = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            foreach (int index in initialIndexes)
            {
                if (index >= 0 && index > field.Length) //valid
                {
                    field[index] = 1;
                }
            }

            string command;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] cmdArgs = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                int ladybugIndex = int.Parse(cmdArgs[0]);
                string direction = cmdArgs[1];
                int flyLenght = int.Parse(cmdArgs[2]);

                if (ladybugIndex < 0 || ladybugIndex >= field.Length)
                {
                    continue;
                }

                if (field[ladybugIndex] == 0)
                {
                    continue;
                }
                


            }

        }
    }
}