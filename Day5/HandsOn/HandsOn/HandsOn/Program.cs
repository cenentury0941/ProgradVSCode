namespace HandsOn
{
    internal class Program
    {
        static void Main1(string[] args)
        {
            Console.WriteLine("Spairaru Matoriksu!");

            
            int[,] Matrix1 = new int[4, 4] { { 1 , 2 , 3 , 4 },
                                            { 5 , 6 , 7 , 8},
                                            { 9, 10 , 11 , 12},
                                            { 13 , 14 , 15 , 16} };
            

            int[,] Matrix2 = new int[3, 4] { { 1 , 2 , 3 , 4 },
                                            { 5 , 6 , 7 , 8},
                                            { 9, 10 , 11 , 12} };

            Console.WriteLine("Matrix 1 : ");
            printSpiralMatrix(Matrix1, 4, 4);
            Console.WriteLine( "Matrix 2 : " );
            printSpiralMatrix(Matrix2, 3, 4);

        }


        static void printSpiralMatrix(int[,] Matrix , int rows , int cols)
        {
            int Rows = rows, Colls = cols;
            int X_mod = 1, Y_mod = 0;
            int X = 0, Y = 0;
            int XMaxLimit = Colls - 1, XMinLimit = -1;
            int YMaxLimit = Rows - 1, YMinLimit = 0;

            for (int i = 0; i < Rows * Colls; i++)
            {
                Console.Write($"{Matrix[Y, X]} ");
                
                if (X == 0 && Y == 0)
                { }
                else if (X_mod + X > XMaxLimit)
                {
                    X_mod = 0;
                    Y_mod = 1;
                    YMinLimit += 1;
                }
                else if (X + X_mod < XMinLimit)
                {
                    X_mod = 0;
                    Y_mod = -1;
                    YMaxLimit -= 1;
                }
                else if (Y + Y_mod < YMinLimit)
                {
                    Y_mod = 0;
                    X_mod = 1;
                    XMaxLimit -= 1;
                }
                else if (Y + Y_mod > YMaxLimit)
                {
                    Y_mod = 0;
                    X_mod = -1;
                    XMinLimit += 1;
                }


                X += X_mod;
                Y += Y_mod;

            }

            Console.WriteLine( "" );
        }
    }
}