namespace HeroVillianGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Thunderdome!\n");
            string gunman;
            GameState Game = new GameState();
            while (Game.H_Remaining_Bullets >= 1 && Game.V_Remaining_Bullets >= 3)
            {
                Console.Write("Who fires the bullet? (HERO/VILL) : ");
                gunman = Console.ReadLine().Trim();

                if (string.Compare(gunman, "HERO") == 0)
                {
                    Game.HeroFires();
                }
                else if (string.Compare(gunman, "VILL") == 0)
                {
                    Game.VillianFires();
                }
            }
            Console.WriteLine( "GAME OVER" );
            
        }
    }

    class GameState
    {
        public int H_Remaining_Bullets, V_Remaining_Bullets;
        int Hero_Tally;
        int Villian_Tally;

        public GameState()
        {
            this.H_Remaining_Bullets = 10;
            this.V_Remaining_Bullets = 10;
            this.Hero_Tally = 0;
            this.Villian_Tally = 0;
        }

        public int HeroFires()
        {
            this.H_Remaining_Bullets -= 1;
            this.Hero_Tally += 1;
            Console.WriteLine("");
            Console.WriteLine("       ------ > "); 
            Console.WriteLine("");
            Console.WriteLine($"Hero Fired 1 Bullet, Remaining Bullets : {this.H_Remaining_Bullets}");
            Console.WriteLine($"Hero Has Fired {this.Hero_Tally} Bullet(s)");
            Console.WriteLine($"Villian Has Fired {this.Villian_Tally} Bullet(s)");
            Console.WriteLine("\n\n\n");
            return this.H_Remaining_Bullets;
        }


        public int VillianFires()
        {
            if ( this.V_Remaining_Bullets < 3 )
            {
                Console.WriteLine( "Not Enough Bullets..." );
                return -1;
            }

            this.V_Remaining_Bullets -= 3;
            this.Villian_Tally += 3;

            Console.WriteLine("             < ------ ");
            Console.WriteLine("       < ------ ");
            Console.WriteLine("                     < ------ ");
            Console.WriteLine($"Villian Fired 3 Bullets, Remaining Bullets : {this.V_Remaining_Bullets}");
            Console.WriteLine($"Hero Has Fired {this.Hero_Tally} Bullet(s)");
            Console.WriteLine($"Villian Has Fired {this.Villian_Tally} Bullet(s)");
            Console.WriteLine("\n\n\n");

            return this.V_Remaining_Bullets;
        }

    }

}