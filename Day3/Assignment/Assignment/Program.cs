using System.ComponentModel;
using System.Net.Http.Headers;

namespace Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {


            //Write a program in C# Sharp to count a 
            //total number of duplicate elements in 
            //an array.

            int[] arr = { 1, 2, 3, 3, 2, 4, 5, 1, 2, 8 };
            HashSet<int> hash = new HashSet<int>(arr);
            Console.WriteLine( $"Number of duplicate elements : {arr.Length-hash.Count}" );


            Console.WriteLine("\n");

            //Write a program in C# Sharp to merge two arrays of 
            //same size sorted in ascending order.

            int[] arr1 = { 1, 4, 7, 8 };
            int[] arr2 = { 3, 5, 7, 9 };
            int[] arr3 = new int[arr1.Length + arr2.Length];
            int arr1_index = 0, arr2_index = 0, arr3_index = 0;
            while ( arr1_index < arr1.Length && arr2_index < arr2.Length )
            {
                if (arr1[arr1_index] <= arr2[arr2_index] )
                {
                    arr3[arr3_index++] = arr1[arr1_index++];
                }
                else
                {
                    arr3[arr3_index++] = arr2[arr2_index++];
                }
            }

            while (arr1_index < arr1.Length)
            {
                arr3[arr3_index++] = arr1[arr1_index++];
            }
            
            while (arr2_index < arr2.Length)
            {
                arr3[arr3_index++] = arr2[arr2_index++];
            }

            Console.Write( "Elements of arr3 : " );
            foreach ( int i in arr3 )
            {
                Console.Write( $" {i} |" );
            }

            Console.WriteLine("\n");


            //Write a program in C# Sharp to separate 
            //odd and even integers in separate arrays

            List<int> Even = new List<int>() , Odd = new List<int>() ;

            foreach ( int i in arr3 )
            {
                if ( i%2 == 0 )
                {
                    Even.Add(i);
                }
                else {
                    Odd.Add(i);
                }
            }

            Console.Write("Even Numbers : ");
            Even.ForEach(x => Console.Write($"{x} - "));
            Console.WriteLine();

            Console.Write("Odd Numbers : ");
            Odd.ForEach(x => Console.Write($"{x} - "));
            Console.WriteLine();

        }
    }
}