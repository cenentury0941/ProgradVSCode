using System.ComponentModel;

namespace Practise
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Write a C# Sharp program to exchange the first and last characters
            //in a given string and return the new string


            Console.WriteLine("Enter A String : ");
            string EnteredValue = Console.ReadLine().Trim();
            if (EnteredValue.Length <= 1)
            {
                Console.WriteLine($"Swapped String : {EnteredValue}");
            }
            else
            {
                string Swapped = EnteredValue[EnteredValue.Length - 1] + EnteredValue.Substring(1, EnteredValue.Length - 2) + EnteredValue[0];
                Console.WriteLine($"Swapped String : {Swapped}");
            }
            Console.WriteLine( "\n\n\n" );


            //Write a C# Sharp program to create a new string with the last char
            //added at the front and back of a given string of length 1 or more.


            Console.WriteLine("Enter A String : ");
            EnteredValue = Console.ReadLine().Trim();
            if (EnteredValue.Length < 1)
            {
                Console.WriteLine("String Is Too Short.");
            }
            else
            {
                string Modified = EnteredValue.Last() + EnteredValue + EnteredValue.Last();
                Console.WriteLine($"Modified String : {Modified}");
            }
            
            Console.WriteLine("\n\n\n");


            //Write a C# Sharp program to check if a string 'ok' appears in a given string.
            //If it appears return a string without 'ok' otherwise return the original string.

            Console.WriteLine("Enter A String : ");
            EnteredValue = Console.ReadLine().Trim();
            string DuplicateValue = EnteredValue;
            if (EnteredValue.Length <= 1)
            {
                Console.WriteLine( $"String Without ok : {EnteredValue}");
            }
            else
            {
                while (  EnteredValue.Contains("ok") )
                {
                    EnteredValue = EnteredValue.Replace("ok" , "");
                }
                Console.WriteLine($"String Without ok : {EnteredValue}");
            }


            //Different Approach

            while ( DuplicateValue.Contains("ok") )
            {
                string[] segs = DuplicateValue.Split("ok");
                DuplicateValue = string.Join("", segs); 
            }

            Console.WriteLine($"String Without ok : {DuplicateValue}");



            Console.WriteLine("\n\n\n");


        }
    }
}