using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp
{
    
    internal class RecipeHandler
    {

        private static DBHandler db = new DBHandler();
        private static HashSet<string> stopwords = new HashSet<string>();
        private static UserHandler user = new UserHandler();

        public RecipeHandler()
        {

            // Initializing stop words
            StreamReader stopwordfile = new StreamReader("./stop_words.txt");
            while ( !stopwordfile.EndOfStream )
            {
                string line = stopwordfile.ReadLine();
                if (line != null)
                    stopwords.Add(line.Trim());
            }
            stopwordfile.Close();

        }

        public void AddRecipe()
        {
            Console.WriteLine( "New Recipe : " );
            Console.Write( "Recipe Name : " );
            string name = Console.ReadLine();

            List<string> Ingredients = new List<string>();
            List<string> Instructions = new List<string>();

            Console.WriteLine("Ingredients (Enter empty string to complete) : ");
            string ingredient = " ";
            while ( ingredient.Length > 0 )
            {
                ingredient = Console.ReadLine().Trim();
                if(ingredient.Length > 0 )
                    Ingredients.Add(ingredient);
            }

            Console.WriteLine($"Registered {Ingredients.Count()} ingredients.\n");

            Console.WriteLine("Instructions (Enter empty string to complete) : ");
            string instruction = " ";
            while (instruction.Length > 0)
            {
                instruction = Console.ReadLine().Trim();
                if (instruction.Length > 0)
                    Instructions.Add(instruction);
            }
            Console.WriteLine($"Registered {Instructions.Count()} instructions.\n");

            Console.WriteLine( "Adding Recipe..." );

            bool success = db.AddRecipe( user.GetUserId() , name , Ingredients , Instructions);

            if ( success )
            {
                Console.WriteLine( "Successfully created recipe!" );
            }
            else {
                Console.WriteLine("Failed to creat recipe.");
            }

        }


        public void ViewRecipe(int recipeID)
        {
            Recipe recipe = db.ViewRecipe(recipeID);

            Console.WriteLine( $"\n\nRecipe for {recipe.RecipeName}:" );
            Console.WriteLine( "Ingredients" );
            int index = 1;
            recipe.ingredients.ForEach( x => Console.WriteLine( $"{index++}.\t{x}" ) );

            Console.WriteLine("\n\nInstructions");
            index = 1;
            recipe.instructions.ForEach(x => Console.WriteLine($"{index++}.\t{x}"));

        }

    }
}
