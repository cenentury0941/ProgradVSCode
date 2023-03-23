using System.Runtime.CompilerServices;
using System;
using Microsoft.VisualBasic.FileIO;

namespace ConsoleApp3
{
    class Program
    {

        int Value;

        public Program( int Val ) {
            this.Value = Val;
            Console.WriteLine( "Program Created");
        }

        ~Program() {
            Console.WriteLine("Get Wrecked!");
        }

        public void DisplayValues()
        {
            Console.WriteLine( $"Value of Program is : {this.Value}" );
        }

        public enum days { 
        Monday, Tuesday, Wednesday, Thursday, Friday
        }

        static void destroyer()
        {
            Program prog = new Program(420);
            prog.DisplayValues();
            prog = null;
            System.GC.Collect();
        }

        static void Main(string[] args)
        {
            destroyer();

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
                throw new AgeException("FBI");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Out of bounds, yo!");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Don't you go dividing by zero now!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected : " + e.Message);
            }
            finally {
                Console.WriteLine("Safe!");
            }
        }

        public void greet()
        {
            Console.WriteLine("Greeting");
        }

    }



    public class AgeException : Exception { 
        public AgeException(string myMessage) : base(myMessage) { 
        }
    }
}