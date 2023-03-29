using System.Reflection.Metadata.Ecma335;

namespace Delegates_Again
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Func<int, int> factorial = null;

            factorial = (x) => { return x == 1 ? 1 : x*factorial(x - 1); };

            Console.WriteLine(factorial(5));


            List<int> lst = new List<int> { 1, 2, 3, 4, 5, 6 };
            
            Predicate<int> AreGreaterThan5 = (x) => { return x > 5; };
            Console.WriteLine( lst.Fin );
            

        }
    }
}