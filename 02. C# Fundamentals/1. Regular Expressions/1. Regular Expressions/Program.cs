using System;
using System.Text.RegularExpressions;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //                        Regex Syntax

            //   [word] - finds instances of a word
            //   [A-Z] - finds uppercase characters
            //   [a-z] - finds lowercase characters
            //   [0-9] - finds numbers

            //                    Some predefined values

            //   \w - [A-Z] [a-z] [0-9] _
            //   \W everything BUT those above, all non-word characters
            //   \s - " ", finds all spaces
            //   \S - everything except spaces
            //   \d - all digits from 0-9
            //   \D - everything but digits

            //                Difference between *, + and ?

            //   '*' means that you are telling the regex to find 0 or more characters

            //   \+\d* -> +359885976002 a+b -> +359885976002 +

            //   '+' means 1 or more characters

            //   \+\d+ -> +359885976002 a+b -> +359885976002

            //   '?' means 0 or 1 characters

            //   \+\d? -> +359885976002 a+b -> +3 +

            //   {number} means a specified number of characters, where you can even
            //   specify how many or less e.g. {1,4} - from how many to how many

            //   {4} - only four digits
            //   {1, 4} - from one to four (including)
            //   {4,} - from four upwards

            //                       Grouping and naming

            //   We can group expressions hwen we put them in brackets - ()
            //   We can name the groups by writing the name between <>

            //   E.G. - (?<day>\d{2})-(?<month>\w{3})-(?<year>\d{4})

            //   22-Jan-2015 -> 22 is group day, Jan in group month, 2015 is group year

            //   ^ means "should start with"
            //   $ means "should end with"



            //                          Example:

            //string emailPattern = "[A-Za-z0-9]+@[A-za-z]+\\.[a-z]+";

            //string email = "stoyan@shopov.bg";

            //Regex regex = new Regex(emailPattern);

            //Match match = regex.Match(email);

            //Console.WriteLine(match.Success); // returns boolean
            //Console.WriteLine(match.Value);   // returns the match itself

            //MatchCollection matches = regex.Matches(email);

            ////Instead of var, we use Match
            //foreach (Match m in matches)
            //{
            //    Console.WriteLine(m.Value);
            //}

            //                      Another example:

            string pattern = @"\d+"; 
            // if it has a + it changes all numbers to 5
            // otherwise it changes all digits to 5

            string input = "some random text 123 with984 somedigit1";

            Regex regex = new Regex(pattern);

            string replaced = regex.Replace(input, "5");
            Console.WriteLine(replaced);

            //           Example how to split strigns using regex:

            string text = "1   2 3     4";
            string pattern1 = @"\s+";

            string[] results = Regex.Split(text, pattern1);
            Console.WriteLine(string.Join(", ", results));

        }
    }
}