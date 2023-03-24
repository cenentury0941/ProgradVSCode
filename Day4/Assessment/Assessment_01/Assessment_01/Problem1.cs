using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_01
{
    class Problem1
    {

        public static void main()
        {
            Console.WriteLine("psychology thesis");

            before_question:
            Console.WriteLine( "Is this the First Question? (Y/N)" );
            string ans = Console.ReadLine();

            if (ans.CompareTo("Y") == 0)
            { Console.WriteLine("That's True"); }
            else if (ans.CompareTo("N") == 0)
            { Console.WriteLine("That isn't True, Are you sure?"); }
            else { goto before_question; }

            Console.WriteLine("Select A Month:");
            int Month = Convert.ToInt32(Console.ReadLine());
            switch (Month)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                    Console.WriteLine( "Your Partner is an Ox" );
                    break;

                case 5:
                case 6:
                case 7:
                case 8:
                    Console.WriteLine("Your Partner is a Pony");
                    break;

                case 9:
                case 10:
                case 11:
                case 12:
                    Console.WriteLine("Your Partner is an Alien");
                    break;

                default:
                    Console.WriteLine("InvalidMonth");
                    break;
            }

        }

    }
}
