using System.Collections;
using System.Runtime.InteropServices;

namespace Delegates
{

    delegate int SumDelegate(int LOp, int ROp);

    internal class Program
    {
        static void Main(string[] args)
        {
            int X = 69;
            int Y = 420;

            SumDelegate SD = Sum;
            SD += Diff;
            SD -= Sum;

            Console.WriteLine(SD.Invoke(X, Y));

            SD = delegate (int x, int y) { return x * y; };

            Console.WriteLine(SD.Invoke(X, Y));

            //Console.WriteLine(Sum(X,Y));


            List<int> L1 = new List<int>() { 1,2,3, 10 ,4,5,6,7,8, 15 };
            List<int> DivisibleBy5 = L1.FindAll( n => n%5==0 );
            List<string> S1 = new List<string>() { "abc", "dfg", "asd", "qwe" };
            
            List<string> ContainsA = S1.OrderBy( s => string.CompareOrdinal( s , "           " )*-1 ).ToList();

            Dictionary<int, int[]> Dict = new Dictionary<int, int[]>() {
                { 1 , new int[]{ 2 , 3} },
                { 2 , new int[]{ 3 , 4} },
                { 3 , new int[]{ 2 , 4 } },
                { 4 , new int[]{ 2 , 5 } },
                { 5 , new int[]{ 3 , 6 } },
                { 6 , new int[]{ 2 , 4 } },
                { 7 , new int[]{ 2 , 4 } },
                { 8 , new int[]{ 3 , 2 } }
            };

            foreach ( var kv in Dict.OrderBy( x => x.Value[1]*-1 ).OrderBy( x => x.Value[0] ) )
            {
                Console.WriteLine( $" [ {kv.Value[0]} , {kv.Value[1]} ]" );
            }





            foreach ( string s in ContainsA )
            {
                Console.WriteLine(s);
            }




        }


        static int customComparer( int[] arg )
        {
            return 0;
        }

        static int Sum(int LOperand, int ROperand)
        {
            return LOperand + ROperand;
        }

        static int Diff(int LOperand, int ROperand)
        {
            return LOperand - ROperand;
        }


    }
}