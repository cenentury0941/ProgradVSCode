using System.Drawing;

namespace RotateMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Guru Guru");
            int[,] Matrix3x3 = new int[,] { {  1 , 2 , 3 } , 
                                         {  4 , 5 , 6 } , 
                                         {  7 , 8 , 9 } };

            Console.WriteLine("");
            Console.WriteLine("Normal 3x3 : ");
            PrintMatrix(Matrix3x3, 3, 3);
            
            int[,] Rotated3x3 = RotateMatrix( Matrix3x3 , 3 , 3 );

            Console.WriteLine("");
            Console.WriteLine("Rotated 3x3 : ");
            PrintMatrix( Rotated3x3 , 3 , 3 );


            int[,] Matrix4x4 = new int[,] { {  1 , 2 , 3 , 10 } ,
                                            {  4 , 5 , 6 , 11 } ,
                                            {  7 , 8 , 9 , 12 } ,
                                            { 13 ,14 ,15 , 16 } };
            
            Console.WriteLine("");
            Console.WriteLine("Normal 4x4 : ");
            PrintMatrix(Matrix4x4, 4, 4);

            int[,] Rotated4x4 = RotateMatrix(Matrix4x4, 4, 4);

            Console.WriteLine("");
            Console.WriteLine("Rotated 4x4 : "); 
            PrintMatrix(Rotated4x4, 4, 4);



            Console.WriteLine();

        }

        static void PrintMatrix(int[,] Matrix , int Rows , int Cols )
        {
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Cols; col++)
                {
                    Console.Write($"{Matrix[row,col]} " );

                }
                Console.WriteLine("");
            }
        }

        static int[,] RotateMatrix( int[,] OriginalMatrix , int Rows , int Cols )
        {
            int[,] RotatedMatrix = new int[Rows,Cols];

            for ( int row = 0; row < Rows; row++ )
            {
                for ( int col = 0; col < Cols; col++ )
                {
                    RotatedMatrix[col,Rows-1-row] = OriginalMatrix[row, col];
                }
            }

            return RotatedMatrix;
        }

        //static void RotateMatrixInplace(int[,] Matrix, int Rows, int Cols)
        //{
        //    int CountToSwap = ((Rows * Cols) / 2) - ((Rows*Cols)%2) ;
        //    for (int row = 0; row < Rows; row++)
        //    {
        //        for (int col = 0; col < Cols-row; col++)
        //        {
        //            int Temp = Matrix[col, Rows - 1 - row];
        //            Matrix[col, Rows - 1 - row] = Matrix[row, col];
        //            Matrix[row, col] = Temp;

        //            //CountToSwap -= 1;
        //            if ( CountToSwap == 0 )
        //            {
        //                break;
        //            }
        //        }
        //        if (CountToSwap == 0)
        //        {
        //            break;
        //        }
        //    }

        //}


    }
}