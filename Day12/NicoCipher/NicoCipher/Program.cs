namespace NicoCipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = "edabitisamazing";
            string key = "matt";
            string encoded = NicoCipher.Encode(message , key);
            Console.WriteLine( $" Message : '{message}'\n Encoded with Key : '{key}'\n is : '{encoded}'" );
        }
    }

    internal class NicoCipher {

        public static string Encode( string message , string key )
        {
            key = key.ToLower();
            int[] colOrder = new int[key.Length];
            int messageMatrixSize = message.Length / key.Length;
            messageMatrixSize += (message.Length % key.Length == 0) ? 0 : 1;

            int index = 1;
            for ( char testChar = (char)0; testChar < 256; testChar++ )
            {
                for ( int charIndex = 0; charIndex < key.Length; charIndex++ )
                {
                    if ( key[charIndex] == testChar )
                    {
                        colOrder[charIndex] = index++;
                    }
                }
            }

            Dictionary<int, string[]> messageMatrix = new Dictionary<int, string[]>();

            for ( int indexKey = 1; indexKey <= key.Length; indexKey++ )
            {
                messageMatrix[indexKey] = new string[messageMatrixSize];
                for( int _ = 0; _ < messageMatrixSize; _++ )
                {
                    messageMatrix[indexKey][_] = " "; 
                }
            }



            int charsLeft = message.Length;
            int matrixRow = 0;
            int messageIndex = 0;
            int colIndex = 0;
            while ( charsLeft > 0 )
            {
                messageMatrix[colOrder[colIndex++]][ matrixRow ] = "" + message[messageIndex++];
                colIndex %= key.Length;
                if ( colIndex == 0 )
                {
                    matrixRow += 1;
                }
                charsLeft -= 1;
            }


            /*
            for (int indexKey = 1; indexKey <= key.Length; indexKey++)
            {
                Console.WriteLine(indexKey);
                for (int _ = 0; _ < messageMatrixSize; _++)
                {
                    Console.Write(messageMatrix[indexKey][_]);
                }
                Console.WriteLine("\n");
            }
            */

            string encodedMessage = "";

            for ( int row = 0; row < messageMatrixSize; row++ ) {
                for (int col = 1; col <= key.Length; col++)
                {
                    encodedMessage += messageMatrix[col][row];
                }
            }

            return encodedMessage;
        }

    }
}