using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_01
{
    class Problem2
    {
        public static void main()
        {
            Console.WriteLine("Hell2o");
        }
    }

    class Dispenser {

        List<string> Chocolates;
        public static Dictionary<string, int> ChocolateCounter;

        public Dispenser() { 
        Chocolates = new List<string>();
        }

        public void AddChocolates(string Color , int Count)
        {
            for (int i = 0; i < Count; i++)
            {
                this.Chocolates.Append(Color);
            }
        }

        public string[] RemoveChocolates(int Count) {
            string[] retrieved = new string[Count];

            if (Count > this.Chocolates.Count)
            {
                return null;
            }

            for ( int i = 0; i < Count; i++ )
            {
                retrieved[i] = this.Chocolates[this.Chocolates.Count()-1];
                this.Chocolates.RemoveAt(this.Chocolates.Count() - 1);
            }
            return retrieved;
        }


        public string[] DispenseChocolates(int Count)
        {
            string[] retrieved = new string[Count];

            if (Count > this.Chocolates.Count)
            {
                return null;
            }

            for (int i = 0; i < Count; i++)
            {
                retrieved[i] = this.Chocolates[0];
                this.Chocolates.RemoveAt(0);
            }
            return retrieved;
        }

        

        public string[] DispenseChocolatesOfColor(string Color, int Count)
        {
            if ( this.Chocolates.Count < Count )
            {
                return null;
            }


            string[] retrieved = new string[Count];
            int currentindex = 0;

            for (int i = 0; i < this.Chocolates.Count; i++)
            {
                if (this.Chocolates[i].CompareTo(Color) == 0 )
                {
                    retrieved[currentindex++] = Color;
                }
            }

            if ( retrieved.Length < Count )
            {
                return null;
            }

            for ( int i = 0; i < Count; i++ )
            {
                this.Chocolates.Remove(Color);
            }

            return retrieved;

        }

        public enum Colors{ green, silver, blue, crimson, purple, red, pink };

        public Dictionary<string, int> NoOfChocolates( bool print_output = true )
        {
            Dictionary<string,int> ChocolateCounter = new Dictionary<string,int>();

            foreach ( string col in Enum.GetNames(typeof(Colors)) )
            {
                ChocolateCounter.Add(col, 0);
            }

            foreach ( string choco in this.Chocolates )
            {
                int Count = ChocolateCounter[choco];
                ChocolateCounter.Add( choco , Count+1 );
            }

            if (!print_output)
            {
                return ChocolateCounter;
            }

            foreach (string col in Enum.GetNames(typeof(Colors)))
            {
                Console.WriteLine( $"Number of {col} Chocolates : {ChocolateCounter[col]}" );
            }

            return ChocolateCounter;
        }

        public void SortChocolateBasedOnCount()
        {
            Dictionary<string, int> ChocolateCounter = NoOfChocolates(false);
            Dispenser.ChocolateCounter = ChocolateCounter;

            this.Chocolates.Sort( new HigherCountFirst() );

            foreach (string choco in this.Chocolates)
            {
                Console.WriteLine(choco);
            }
        }

        public void ChangeChocolateColor()
        { 
        


        }



    }

    public class HigherCountFirst : Comparer<string>
    {
        public override int Compare(string x, string y)
        {

            return Dispenser.ChocolateCounter[x] - Dispenser.ChocolateCounter[y]; 

        }
    }


}
