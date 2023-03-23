using System.Runtime.CompilerServices;
using System;

namespace ConsoleApp3
{
    class Program
    {

        public enum days { 
        Monday, Tuesday, Wednesday, Thursday, Friday
        }

        static void Main(string[] args)
        {

            foreach ( days val in Enum.GetValues(typeof(days)) )
            {
                Console.WriteLine(val);
            }

            int[,] arr = new int[5,5];

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    arr[i,j] = i * j;
                }

            }


            try
            {
                Console.WriteLine(arr[2,4]);
            }
            catch( IndexOutOfRangeException ) {
                Console.WriteLine("Out of bounds, yo!");
            }            
        }

        public void greet()
        {
            Console.WriteLine("Greeting");
        }

    }
}