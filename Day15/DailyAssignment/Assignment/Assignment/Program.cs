using System.ComponentModel.DataAnnotations;

namespace Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bracket Checker");
            Console.Write( "Enter value of n : " );
            
            int n = Convert.ToInt32( Console.ReadLine() );


            Console.WriteLine("\n\nUsing Recursion");

            DateTime start = DateTime.Now;
            string[] combinations = GenerateBracketPermutations(n);
            DateTime end = DateTime.Now;

            Console.WriteLine("Bracket Combinations Possible :");
            foreach (string combination in combinations)
            {
                Console.WriteLine(combination);
            }

            Console.WriteLine($"\nTotal Time Taken : {end - start}\n\n");



            Console.WriteLine("\n\nUsing Stacks");

            start = DateTime.Now;
            combinations = GenerateBracketPermutationsUsingStack(n);
            end = DateTime.Now;

            Console.WriteLine("Bracket Combinations Possible :");
            foreach (string combination in combinations)
            {
                Console.WriteLine(combination);
            }

            Console.WriteLine($"\nTotal Time Taken : {end - start}\n\n");



        }


        static string[] GenerateBracketPermutationsUsingStack(int n)
        {
            List<string> bracketPermutations = new List<string>();

            for (int permutation = 0 ; permutation < Math.Pow( 2 , 2*n ); permutation++  )
            {
                String combination = Convert.ToString( permutation , 2 ).PadLeft( 2*n , '0' );
                combination = combination.Replace("0", "(").Replace("1" , ")");
                if ( IsValidCombination(combination) )
                { 
                    bracketPermutations.Add( combination );
                }
            }
            return bracketPermutations.ToArray();
        }

        static bool IsValidCombination( string combination )
        {

            Stack<char> bracketStack = new Stack<char>();
            foreach ( char character in combination )
            {
                if (character == ')')
                {
                    if (bracketStack.Count == 0)
                    {
                        return false;
                    }
                    else
                    {
                        bracketStack.Pop();
                    }
                }
                else { 
                    bracketStack.Push( character );
                }
            }

            if ( bracketStack.Count == 0 ){
                return true; }
            else {
                return false; }

        }


        static string[] GenerateBracketPermutations( int n )
        {
            List<string> bracketPermutations = new List<string>();
            HashSet<string> memory = new HashSet<string>();
            Recurse( n , "" , 0 , 0 , n*2 , bracketPermutations , memory );
            return bracketPermutations.ToArray();
        }

        static void Recurse( int n , string current_combination , int openCount , int closedCount , int remaining , List<string> combinations , HashSet<string> memory )
        {
            if ( memory.Contains(current_combination) )
            {
                return;
            }

            if ( closedCount > openCount )
            {
                return;
            }

            if ( remaining == 0 ) 
            {
                if ( openCount == closedCount )
                {
                    combinations.Add( current_combination );
                }
                return;
            }
            
            memory.Add(current_combination);

            if ( openCount < n )
            {
                Recurse(n, current_combination + "(", openCount + 1, closedCount, remaining - 1, combinations, memory);
            }

            if ( closedCount < n )
            {
                Recurse(n, current_combination + ")", openCount, closedCount+1, remaining - 1, combinations, memory);
            }


        }


    }
}