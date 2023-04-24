namespace RecipeApp
{
    internal class Program
    {
        private static RecipeHandler recipe;
        private static MenuHandler menu;
        private static DBHandler db;
        private static UserHandler user;

        static void Main(string[] args)
        {
            recipe = new RecipeHandler();
            menu = new MenuHandler();
            db = new DBHandler();
            user = new UserHandler();

            bool exit = false;
            while (!exit)
            { 
                menu.PrintMenu();
                Console.Write("Your Choice : ");
                int userChoice = Convert.ToInt32(Console.ReadLine());
                switch ( userChoice )
                {
                    case 0:
                        exit = true; break;
                    case 1:
                        if (user.IsLoggedIn())
                        {   
                            user.Logout();
                        }
                        else {
                            user.Login();
                        }
                        break;
                    case 2:
                        if (user.IsLoggedIn())
                        {
                            menu.PrintRecipies(user.GetUserId());
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid Input");
                            break;
                        }
                        break;
                    case 3:
                        menu.PrintRecipies(-1);
                        break;
                    case 4:
                        if (user.IsLoggedIn())
                        {
                            recipe.AddRecipe();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid Input");
                            break;
                        }
                    case 5:
                        if (!user.IsLoggedIn())
                        {
                            user.CreateAccount();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid Input");
                            break;
                        }
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
                menu.PrintSpacing();
            }
            menu.PrintExit();

        }


    }
}