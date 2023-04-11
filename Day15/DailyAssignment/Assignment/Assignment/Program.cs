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

            DateTime start = DateTime.Now;
            string[] combinations = GenerateBracketPermutations( n );
            DateTime end = DateTime.Now;

            Console.WriteLine( "Bracket Combinations Possible :" );
            foreach ( string combination in combinations )
            { 
                Console.WriteLine( combination );
            }

            Console.WriteLine( $"\nTotal Time Taken : {end-start}\n\n" );

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
                    
                    for ( int length = 1; length <= n*2; length++ )
                    { 
                        memory.Add( current_combination.Substring(0,length) );
                    }

                }
                return;
            }

            if ( openCount < n )
            {
                Recurse(n, current_combination + "(", openCount + 1, closedCount, remaining - 1, combinations, memory);
            }

            if ( closedCount < n )
            {
                Recurse(n, current_combination + ")", openCount, closedCount+1, remaining - 1, combinations, memory);
            }

            if ( openCount < n && closedCount < n )
            {
                Recurse(n, current_combination + "()", openCount+1, closedCount + 1, remaining - 2, combinations, memory);
            }

        }
    }
}