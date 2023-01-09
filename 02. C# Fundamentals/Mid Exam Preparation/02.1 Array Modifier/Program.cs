using System;
using System.Linq;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string[] input = Console.ReadLine().Split().ToArray();

            while (input[0] != "end")
             {
                if (input[0] == "swap")
                {
                    int index1 = int.Parse(input[1]);//index
                    int index2 = int.Parse(input[2]);//index

                    int firstItem = arr[index1];//elements value
                    int secondItem = arr[index2];//elements value

                    int temp = firstItem;

                    arr[index1] = secondItem;
                    arr[index2] = temp;
                }
                else if (input[0] == "multiply")
                {
                    int index1 = int.Parse(input[1]);
                    int index2 = int.Parse(input[2]);

                    arr[index1] *= arr[index2];
                }
                else if (input[0] == "decrease")
                {
                    for (int i = 0; i < arr.Length; i++)
                    {
                        arr[i] -= 1;
                    }
                }
                input = Console.ReadLine().Split().ToArray();
            }

            Console.WriteLine(String.Join(", ", arr));

        }
    }
}