using System;

public class Class1
{

        public static void Main(string[] args)
        {
            int[] Prices = { 7 , 1 , 5 , 3 , 6 , 4 };
            Console.WriteLine($"Maximum Profit : { getMaximumProfit(Prices , Prices.Length) }");
        
        }

        static int getMaximumProfit( int[] Prices , int NumberOfDays )
        {
            int MaximumProfit = 0;
            int MinimumCost = Prices[0] ;

            for ( int Day = 0; Day < NumberOfDays; Day++ )
            {
                int ProfitToday = Prices[Day] - MinimumCost;
                
                if ( ProfitToday > MaximumProfit )
                { 
                    MaximumProfit = ProfitToday;
                }

                if (Prices[Day] < MinimumCost )
                { 
                    MinimumCost = Prices[Day];
                }
            }

            return MaximumProfit;
        
        }

}
