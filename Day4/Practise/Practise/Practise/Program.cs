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
            string Swapped = EnteredValue[EnteredValue.Length-1] + EnteredValue.Substring(1,EnteredValue.Length-2) + EnteredValue[0];
            Console.WriteLine($"Swapped String : {Swapped}");

            Console.WriteLine( "\n\n\n" );










        }
    }
}