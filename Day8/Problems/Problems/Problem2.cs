using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
    internal class Problem2
    {

        public Problem2()
        {

            Console.WriteLine("Lucky Number Predictor : ");
            Console.Write( "Enter Your Date of Birth : (DD/MM/YY) :" );
            string dob = Console.ReadLine().Trim();
            int luckyNumber = GetLuckyNumber( dob );
            if ( luckyNumber > 0 )
            {
                Console.WriteLine( $"Your Lucky Number is : {luckyNumber}" );
            }
        }

        private int GetLuckyNumber( string dob )
        { 
            return NumberPredictor.Predict( dob );
        }

    }

    internal class NumberPredictor
    {
        public static int Predict(string dob)
        {

            try
            {
                if (dob.Length != 8)
                {
                    throw new Exception();
                }

                int dob_int = Convert.ToInt32(string.Join("", dob.Split("/")));

                int luckynumber = FibonacciLocalizer( dob_int );
                return luckynumber;
            
            }
            catch (Exception ex) {
                Console.WriteLine( $"Invalid DOB. Follow DD/MM/YY : Error : {ex}");
            }
            return 0;
        }

        private static int FibonacciLocalizer( int dob_int )
        {

            int val1 = 0, val2 = 1;
            int temp = 0;

            while ( dob_int > val2   )
            {
                temp = val1;
                val1 = val2;
                val2 += temp;
            }

            return Math.Abs(dob_int-val1) < Math.Abs(dob_int-val2) ? val1 : val2; ;
        }


    }
}
