using System;
using System.Collections.Generic;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> phoneBook 
                = new Dictionary<string, string>();

            //The first parameter is the type of the key
            //The second parameter is the type of the value that is stored
            //It is initialized like a list is, but with one more parameter

            //Adding new components works like adding to a list, the are saved
            //in the order in which they have been added
            phoneBook.Add("Teodor", "+35966666666");

            //Another way to do it is like that, it's the same as the above example,
            //with the difference that it overwrites the value, whereas you cannot
            //do this with the other method
            phoneBook["Maria"] = "+33333333";
            phoneBook["Maria"] = "999999";
            
            phoneBook.Add("Teodor1", "3444");
            phoneBook.Add("Ivan", "3444");

            //We can print them using a foreach, specifying which is the key
            //and which is the value
            foreach (var item in phoneBook)//KeyValuePair<string, string> is behind var
            {
                Console.WriteLine($"Name: {item.Key}, Phone: {item.Value}");
            }

            //Every item has a unique key, we can't use a key more than once

            //The only difference between a normal dict and a sorted one is 
            //that the sorted is automatically sorted by value

            //We can use .Remove(key) to remove elements by their keys
            phoneBook.Remove("Ivan");

            //We can check both by using .ContainsKey(key) and .ContainsValue(value)
            Console.WriteLine(phoneBook.ContainsKey("Teodor"));


        }
    }
}