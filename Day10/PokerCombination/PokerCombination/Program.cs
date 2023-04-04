namespace PokerCombination
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string Combination = PokerCombination.GetBestCombination( new string[] { "10h" , "10c" , "8d" , "9H" , "AS" } , 5);
            Console.WriteLine( $"Best Combination : {Combination}" );
        }
    }

    internal class PokerCombination
    {

        private static Dictionary<string, string[]> cardMap;
        private static List<string> cardRanking = new List<string>() { "K" , "Q" , "J" , "10" , "9" , "8", "7", "6", "5", "4", "3", "2", "A" };
        private static string royalFlushMask = "1111000000001";
        private static string straightFlushMask = "11111";
        private static string FourOfAKindMask = "1111111111111";
        

        private static bool IsRoyalFlush()
        {
            foreach ( string key in cardMap.Keys )
            {
                if ( string.Join( "" , cardMap[key]).Equals( royalFlushMask ) )
                {
                    return true;
                }
            }
            return false;
        }

        private static bool IsStraightFlush()
        {
            foreach (string key in cardMap.Keys)
            {
                if (string.Join("", cardMap[key]).Contains(straightFlushMask))
                {
                    return true;
                }
            }
            return false;
        }

        private static bool IsFourOfAKind()
        {
            int result = Convert.ToInt16( FourOfAKindMask.PadLeft( 3 , '0' ) , 2 );

            foreach (string key in cardMap.Keys)
            {
                int BitMask = Convert.ToInt16( string.Join("", cardMap[key]) , 2);
                result = result & BitMask;
            }
            return result == 0 ? false : true;
        }

        private static bool IsFullHouse()
        { 
            int heartMask = Convert.ToInt16(string.Join("", cardMap["H"]) , 2);
            int spadeMask = Convert.ToInt16(string.Join("", cardMap["S"]) , 2);
            int diamondMask = Convert.ToInt16(string.Join("", cardMap["D"]) , 2);
            int clubMask = Convert.ToInt16(string.Join("", cardMap["C"]) , 2);

            int test1 = heartMask & spadeMask & diamondMask & ~clubMask;
            int test2 = heartMask & spadeMask & ~diamondMask & clubMask;
            int test3 = heartMask & ~spadeMask & diamondMask & clubMask;
            int test4 = ~heartMask & spadeMask & diamondMask & clubMask;

            int CombinedTest = test1 | test2 | test3 | test4;

            if ( CombinedTest == 0 )
            {
                return false;
            }

            int inverted_combined_mask = ~CombinedTest;

            heartMask = heartMask & inverted_combined_mask;
            spadeMask = spadeMask & inverted_combined_mask;
            diamondMask = diamondMask & inverted_combined_mask;
            clubMask = clubMask & inverted_combined_mask;

            test1 = heartMask & spadeMask;
            test2 = heartMask & diamondMask;
            test3 = heartMask & clubMask;

            test4 = spadeMask & diamondMask;
            int test5 = spadeMask & clubMask;

            int test6 = diamondMask & clubMask;

            CombinedTest = test1 | test2 | test3 | test4 | test5 | test6;

            if (CombinedTest == 0)
            {
                return false;
            }

            return true;
        }


        private static bool IsFlush()
        {
            foreach (string key in cardMap.Keys)
            {
                if ( cardMap[key].Count( x => x == "1" ) == 5)
                {
                    return true;
                }
            }
            return false;
        }

        private static bool IsStraight()
        {
            int combinedMask = Convert.ToInt16(FourOfAKindMask.PadLeft(3, '0'), 2);
            
            foreach (string key in cardMap.Keys)
            {
                string mask = string.Join("", cardMap[key]);
                combinedMask = combinedMask & Convert.ToInt16( mask.PadLeft(3, '0'), 2);
            }

            string maskString = Convert.ToString(combinedMask, 2);

            return maskString.Contains( straightFlushMask );
        }


        private static bool IsThreeOfAKind()
        {

            int heartMask = Convert.ToInt16(string.Join("", cardMap["H"]), 2);
            int spadeMask = Convert.ToInt16(string.Join("", cardMap["S"]), 2);
            int diamondMask = Convert.ToInt16(string.Join("", cardMap["D"]), 2);
            int clubMask = Convert.ToInt16(string.Join("", cardMap["C"]), 2);

            int test1 = heartMask & spadeMask & diamondMask & ~clubMask;
            int test2 = heartMask & spadeMask & ~diamondMask & clubMask;
            int test3 = heartMask & ~spadeMask & diamondMask & clubMask;
            int test4 = ~heartMask & spadeMask & diamondMask & clubMask;

            int CombinedTest = test1 | test2 | test3 | test4;

            if (CombinedTest == 0)
            {
                return false;
            }
            else {
                return true;
            }
        }

        private static bool IsPair()
        {
            int heartMask = Convert.ToInt16(string.Join("", cardMap["H"]), 2);
            int spadeMask = Convert.ToInt16(string.Join("", cardMap["S"]), 2);
            int diamondMask = Convert.ToInt16(string.Join("", cardMap["D"]), 2);
            int clubMask = Convert.ToInt16(string.Join("", cardMap["C"]), 2);

            int test1 = heartMask & spadeMask;
            int test2 = heartMask & diamondMask;
            int test3 = heartMask & clubMask;

            int test4 = spadeMask & diamondMask;
            int test5 = spadeMask & clubMask;

            int test6 = diamondMask & clubMask;

            int CombinedTest = test1 | test2 | test3 | test4 | test5 | test6;

            if (Convert.ToString(CombinedTest, 2).Count(x => x == '1') == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool IsTwoPair()
        {
            int heartMask = Convert.ToInt16(string.Join("", cardMap["H"]), 2);
            int spadeMask = Convert.ToInt16(string.Join("", cardMap["S"]), 2);
            int diamondMask = Convert.ToInt16(string.Join("", cardMap["D"]), 2);
            int clubMask = Convert.ToInt16(string.Join("", cardMap["C"]), 2);

            int test1 = heartMask & spadeMask;
            int test2 = heartMask & diamondMask;
            int test3 = heartMask & clubMask;

            int test4 = spadeMask & diamondMask;
            int test5 = spadeMask & clubMask;

            int test6 = diamondMask & clubMask;

            int CombinedTest = test1 | test2 | test3 | test4 | test5 | test6 ;

            if ( Convert.ToString( CombinedTest , 2 ).Count( x => x == '1' ) == 2 )
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public static string GetBestCombination( string[] cards , int cardCount) {

            cardMap = new Dictionary<string, string[]>();

            foreach ( string suit in new List<string> { "H" , "C" , "S" , "D" } )
            {
                cardMap[suit] = new string[] { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" };
            }

            for ( int cardIndex = 0; cardIndex < cardCount; cardIndex++ )
            {
                string card = cards[cardIndex].ToUpper();
                string cardRank = card.Length == 2 ? "" + card.First() : "" + card.Substring(0, 2);
                cardMap[""+card.Last()][ cardRanking.IndexOf( cardRank ) ] = "1";
            }

            if ( IsRoyalFlush() )
            {
                return "Royal Flush";
            }

            if (IsStraightFlush())
            {
                return "Straight Flush";
            }

            if (IsFourOfAKind())
            {
                return "Four Of A Kind";
            }

            if (IsFullHouse())
            {
                return "Full House";
            }

            if (IsFlush())
            {
                return "Flush";
            }
            
            if (IsStraight())
            {
                return "Straight";
            }

            if (IsThreeOfAKind())
            {
                return "Three of a kind";
            }

            if (IsTwoPair())
            {
                return "Two Pair";
            }

            if (IsPair())
            {
                return "Pair";
            }


            return "High Card";

        }

    }
}