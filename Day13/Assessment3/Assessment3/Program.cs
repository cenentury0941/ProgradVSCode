using System.Security.Cryptography.X509Certificates;

namespace Assessment3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choice;
            while ( true ) {
                Console.WriteLine("College sports management system");
                Console.WriteLine("Select Operation :");
                Console.WriteLine("1. Create Tournament");
                Console.WriteLine("2. Delete Tournament");
                Console.WriteLine("3. Create Sport");
                Console.WriteLine("4. Delete Sport");
                Console.WriteLine("5. Add Sport to Tournament");
                Console.WriteLine("6. Drop Sport from Tournament");

                Console.Write( "\nYour Choice : " );
                choice = Convert.ToInt32(Console.ReadLine()); ;

                switch (choice)
                {
                    case 1:
                        SportsManagementSystem.CreateTournament();
                        break;
                    case 2:
                        SportsManagementSystem.DeleteTournament();
                        break;
                    case 3:
                        SportsManagementSystem.CreateSport();
                        break;
                    case 4:
                        SportsManagementSystem.DeleteSport();
                        break;
                    case 5:
                        SportsManagementSystem.AddSport();
                        break;
                    case 6:
                        SportsManagementSystem.RemoveSport();
                        break;
                    default:
                        Console.WriteLine( "Exiting..." );
                        return;
                }

            }
        }
    }


    internal class SportsManagementSystem {
        public static void CreateTournament()
        {
            Console.Write( "\nEnter Tournament Name : " );
            string tournamentName = Console.ReadLine().Trim();
            try {

                if ( !Directory.Exists($"{tournamentName}") )
                {
                    Directory.CreateDirectory($"{tournamentName}");
                    File.WriteAllText( $"{tournamentName}/Sports.txt" , "" );
                }
                else {
                    throw new Exception( "Tournament of same name exists!" );
                }

                StreamWriter tournaments = File.AppendText("Tournaments.txt");
                tournaments.WriteLine( $"{tournamentName}" );
                tournaments.Close();
            }
            catch( Exception ex )
                {
                Console.WriteLine( "Sorry, Unable to create tournament." );
                Console.WriteLine( ex.Message );
            }
        }

        public static void DeleteTournament()
        {
            {
                string[] tournamentNames = GetFileContents("Tournaments.txt");

                if ( tournamentNames.Length == 0 )
                {
                    Console.WriteLine( "No Available Tournaments!" );
                    return;
                }

                PrintContents( "Available Tournaments : " , tournamentNames );


                Console.Write("\nEnter Tournament Name : ");
                string tournamentName = Console.ReadLine().Trim();
                try
                {

                    if (Directory.Exists($"{tournamentName}"))
                    {
                        Directory.Delete($"{tournamentName}");
                    }
                    else
                    {
                        throw new Exception("Tournament Does not exist!");
                    }

                    List<string> tournamentList = new List<string>(tournamentNames);
                    tournamentList.Remove( tournamentName );
                    tournamentNames = tournamentList.ToArray();

                    WriteContents( "Tournaments.txt" , tournamentNames );

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Sorry, Unable to delete tournament.");
                    Console.WriteLine(ex.Message);
                }
            }
        }



        public static void CreateSport()
        {
            Console.Write("\nEnter Sport Name : ");
            string sportName = Console.ReadLine().Trim();
            try
            {
                List<string> sportNames = new List<string>( GetFileContents( $"Sports.txt" ) );

                if ( sportNames.Contains(sportName) )
                {
                    throw new Exception("Sport of that name already exists !");
                }

                sportNames.Add( sportName );
                File.WriteAllText( $"Sports.txt" , string.Join( "\n" , sportNames ) );
                Console.WriteLine( "Sport created successfully !" );

            }
            catch (Exception ex)
            {
                Console.WriteLine("Sorry, Unable to create sport.");
                Console.WriteLine(ex.Message);
            }
        }

        public static void DeleteSport()
        {
            {
                string[] sportNames = GetFileContents("Sports.txt");

                if (sportNames.Length == 0)
                {
                    Console.WriteLine("No Available Sports!");
                    return;
                }

                PrintContents("Available Sports : ", sportNames);


                Console.Write("\nEnter Sport Name : ");
                string sportName = Console.ReadLine().Trim();
                try
                {

                    List<string> sportList = new List<string>(sportNames);
                    sportList.Remove(sportName);
                    sportNames = sportList.ToArray();

                    WriteContents("Sports.txt", sportNames);

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Sorry, Unable to delete tournament.");
                    Console.WriteLine(ex.Message);
                }
            }
        }


        public static void AddSport()
        {
            
            try
            {
                Console.WriteLine("Enter name of tournament : ");
                string tournamentName = Console.ReadLine().Trim();

                if (!Directory.Exists($"{tournamentName}"))
                {
                    throw new Exception("Tournament Does not exist!");
                }

                Console.WriteLine("Enter name of sport : ");
                string sportName = Console.ReadLine().Trim();

                List<string> allSportNames = new List<string> ( GetFileContents( $"Sports.txt" ) );

                if ( !allSportNames.Contains(sportName) )
                {
                    throw new Exception("Sport Does not exist!");
                }

                List<string> currentSportNames = new List<string> ( GetFileContents( $"{tournamentName}/Sports.txt" ) );

                if ( currentSportNames.Contains(sportName) )
                {
                    throw new Exception("Sport already added!");
                }

                currentSportNames.Add(sportName);
                File.WriteAllText( $"{tournamentName}/Sports.txt" , string.Join( "\n" , currentSportNames ) );

                Console.WriteLine( "Sport successfully added!" );
            }
            catch (Exception ex)
            {
                Console.WriteLine("Sorry, Unable to add sport.");
                Console.WriteLine(ex.Message);
            }



        }

        public static void RemoveSport() {



            try
            {
                Console.WriteLine("Enter name of tournament : ");
                string tournamentName = Console.ReadLine().Trim();

                if (!Directory.Exists($"{tournamentName}"))
                {
                    throw new Exception("Tournament Does not exist!");
                }

                Console.WriteLine("Enter name of sport : ");
                string sportName = Console.ReadLine().Trim();

                List<string> allSportNames = new List<string>(GetFileContents($"Sports.txt"));

                if (!allSportNames.Contains(sportName))
                {
                    throw new Exception("Sport Does not exist!");
                }

                List<string> currentSportNames = new List<string>(GetFileContents($"{tournamentName}/Sports.txt"));

                if (!currentSportNames.Contains(sportName))
                {
                    throw new Exception("Sport not in tournament!");
                }

                currentSportNames.Remove(sportName);
                File.WriteAllText($"{tournamentName}/Sports.txt", string.Join("\n", currentSportNames));

                Console.WriteLine("Sport successfully removed!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Sorry, Unable to remove sport.");
                Console.WriteLine(ex.Message);
            }







        }

        public static void CreatePlayer()
        {

            Console.WriteLine("\nEnter Tournament Name : ");
            string tournamentName = Console.ReadLine().Trim();

            Console.WriteLine("\nEnter Sport Name : ");
            string sportName = Console.ReadLine().Trim();

            Console.Write("\nEnter Player Name : ");
            string playerName = Console.ReadLine().Trim();


            try
            {
                StreamWriter sports = File.AppendText($"{tournamentName}/{sportName}/Players.txt");
                sports.WriteLine($"{playerName}");
                sports.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Sorry, Unable to add player.");
                Console.WriteLine(ex.Message);
            }
        }

        public static void DeletePlayer()
        {

            Console.WriteLine("\nEnter Tournament Name : ");
            string tournamentName = Console.ReadLine().Trim();

            Console.WriteLine("\nEnter Sport Name : ");
            string sportName = Console.ReadLine().Trim();


            string[] playerNames = GetFileContents($"{tournamentName}/{sportName}/Players.txt");

                if (playerNames.Length == 0)
                {
                    Console.WriteLine("No Available Players!");
                    return;
                }

                PrintContents("Available Players : ", playerNames);


                Console.Write("\nEnter Player Name : ");
                string playerName = Console.ReadLine().Trim();
                try
                {
                    List<string> playerList = new List<string>(playerNames);
                    playerList.Remove(sportName);
                    playerNames = playerList.ToArray();

                    WriteContents($"{tournamentName}/{sportName}/Players.txt", playerNames);

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Sorry, Unable to remove player.");
                    Console.WriteLine(ex.Message);
                }
            
        }





        public static string[] GetFileContents( string fileAddr )
        { 
            StreamReader fileReader = new StreamReader(fileAddr);
            string fileContents = fileReader.ReadToEnd().Trim();
            if (fileContents.Length == 0 )
            {
                fileReader.Close();
                return new string[0];
            }
            string[] contents = fileContents.Split("\n");
            fileReader.Close();
            return contents;
        }

        public static void PrintContents(string header, string[] contents)
        {
            Console.WriteLine("\n" + header);
            int index = 1;
            foreach (string content in contents)
            {
                Console.WriteLine($"{index} {content}");
            }
        }

        public static void WriteContents(string fileAddr, string[] contents)
        {
            StreamWriter fileWriter = new StreamWriter(fileAddr, false);
            string buffer = "";
            foreach ( string content in contents )
            {
                buffer += content + "\n";
            }
            fileWriter.Close();
            File.WriteAllText( fileAddr , buffer);
        }

    }

}