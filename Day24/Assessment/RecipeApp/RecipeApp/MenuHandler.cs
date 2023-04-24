using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp
{
    internal class MenuHandler
    {
        private static UserHandler user = new UserHandler();
        private static DBHandler db = new DBHandler();

        public MenuHandler() { }

        public void PrintMenu()
        {
            Console.WriteLine("Recipe Surfer (ver 1.0 alpha)");
            if(user.IsLoggedIn())
                Console.WriteLine($"Logged in as {user.GetUserName()}");
            Console.WriteLine("\nSelect Operation:");
            Console.WriteLine( "0.\tExit" );
            Console.WriteLine( !user.IsLoggedIn() ? "1.\tLog in" : "1.\tLog out" );
            Console.WriteLine("2.\tYour Recepies");
            Console.WriteLine("3.\tBrowse Recepies");
            Console.WriteLine("4.\tAdd Recipe");
            if (!user.IsLoggedIn())
                Console.WriteLine("5.\tCreate Account");
        }

        public void PrintExit()
        {
            Console.WriteLine("Thank you, Come again!");
        }

        public void PrintSpacing()
        {
            Console.WriteLine("\n\n\n");
        }

        public void PrintRecipies( int userID = -1 )
        {
            List<Recipe> recipies;
            if ( userID != -1 )
            {
                Console.WriteLine("Your recipies : ");
                recipies = db.getRecipies(userID);
            }
            else {
                Console.WriteLine("Available recipies : ");
                recipies = db.getRecipies(-1);
            }
            foreach (Recipe recipe in recipies)
            {
                if (recipe.RecipeID == 0)
                {
                    continue;
                }
                Console.WriteLine( $"{recipe.RecipeID}.\t{recipe.RecipeName}" );
            }

            int index = 0;

            if (recipies.Count() > 0)
            {
                Console.Write("\nRecipe to view : ");
                index = Convert.ToInt32(Console.ReadLine());

                new RecipeHandler().ViewRecipe(index);
            }
        }

    }
}
