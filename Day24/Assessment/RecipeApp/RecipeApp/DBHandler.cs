using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;


namespace RecipeApp
{

    internal class DBHandler
    {

        private static string conn_string = "Data Source=DESKTOP-GEG4MT8;Initial Catalog=RecipeDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        private static SqlConnection conn;
        public DBHandler() { 
        conn = new SqlConnection(conn_string);
        }

        public int TestUserLogin(string username , string password)
        {
            conn.Open();
            SqlCommand comm = conn.CreateCommand();
            comm.CommandText = $"select userID from Users WHERE UserName = '{username}' AND Password = '{password}'";
            SqlDataReader reader = comm.ExecuteReader();
            if (reader.Read())
            {
                int userid = reader.GetInt32(0);
                conn.Close();
                return userid;
            }
            conn.Close();
            return -1;
        }

        public bool CreateUser(string username, string password)
        {
            conn.Open();
            SqlCommand comm = conn.CreateCommand();
            comm.CommandText = "CREATEUSER";
            comm.Parameters.Add( new SqlParameter("@USERNAME", username) );
            comm.Parameters.Add(new SqlParameter("@PASSWORD", password));
            comm.CommandType = System.Data.CommandType.StoredProcedure;
            int row_count = comm.ExecuteNonQuery();
            conn.Close();
            if (row_count == 1)
            {
                return true;
            }
            return false;
        }

        public List<Recipe> getRecipies( int userID = -1 )
        { 
            List<Recipe> recipies = new List<Recipe>();

            conn.Open();
            SqlCommand comm = conn.CreateCommand();
            comm.CommandType = System.Data.CommandType.StoredProcedure;
            if ( userID == -1 )
            {
                comm.CommandText = "ALLRECIPES";
            }
            else {
                comm.CommandText = "USERRECIPES";
                comm.Parameters.Add(new SqlParameter("@UID", userID));
            }
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            { 
                Recipe recipe = new Recipe();
                recipe.RecipeID = reader.GetInt32(0);
                recipe.RecipeName = reader.GetString(1);
                recipies.Add(recipe);
            }
            conn.Close();
            return recipies;
        }

        public bool AddRecipe(int userid, string recipename, List<string> ingredients, List<string> instructions)
        {
            conn.Open();
            SqlCommand comm = conn.CreateCommand();
            comm.CommandText = "ADDRECIPE";
            comm.Parameters.Add(new SqlParameter("@USERID", userid));
            comm.Parameters.Add(new SqlParameter("@NAME", recipename));
            var recipeID = comm.Parameters.Add("@RID", SqlDbType.Int);
            recipeID.Direction = ParameterDirection.ReturnValue;
            comm.CommandType = System.Data.CommandType.StoredProcedure;
            int row_count = comm.ExecuteNonQuery();

            if (row_count == 0)
            {
                return false;
            }

            int recId = Convert.ToInt32( recipeID.Value );

            foreach ( string ing in ingredients )
            {
                comm = conn.CreateCommand();
                comm.CommandText = "ADD_ING";
                comm.Parameters.Add(new SqlParameter("@RECIPEID", recId));
                comm.Parameters.Add(new SqlParameter("@ING", ing));

                comm.CommandType = System.Data.CommandType.StoredProcedure;
                row_count = comm.ExecuteNonQuery();

                if (row_count == 0)
                {
                    return false;
                }
            }

            foreach (string ins in instructions)
            {
                comm = conn.CreateCommand();
                comm.CommandText = "ADD_INS";
                comm.Parameters.Add(new SqlParameter("@RECIPEID", recId));
                comm.Parameters.Add(new SqlParameter("@INS", ins));

                comm.CommandType = System.Data.CommandType.StoredProcedure;
                row_count = comm.ExecuteNonQuery();

                if (row_count == 0)
                {
                    return false;
                }
            }


            conn.Close();
            return true;
        }



        public Recipe ViewRecipe(int recipeID)
        {
            Recipe recipe = new Recipe();
            recipe.RecipeID = recipeID;
            recipe.ingredients = new List<string>();
            recipe.instructions = new List<string>();

            string recipenamecmd = $"select RecipeName from RECIPES where RecipeID = {recipeID}";
            string recipeingcmd = $"select ItemEntry from ITEMS where RecipeID = {recipeID}";
            string recipeinscmd = $"select InstructionEntry from INSTRUCTIONS where RecipeID = {recipeID}";

            conn.Open();
            SqlCommand comm = conn.CreateCommand ();

            comm.CommandText = recipenamecmd;
            SqlDataReader reader = comm.ExecuteReader();
            reader.Read();
            recipe.RecipeName = reader.GetString(0);

            conn.Close();
            conn.Open();

            comm = conn.CreateCommand();
            comm.CommandText = recipeingcmd;
            reader = comm.ExecuteReader();
            while (reader.Read())
            {
                recipe.ingredients.Add(reader.GetString(0));
            }

            conn.Close();
            conn.Open();

            comm = conn.CreateCommand();
            comm.CommandText = recipeinscmd;
            reader = comm.ExecuteReader();
            while (reader.Read())
            {
                recipe.instructions.Add(reader.GetString(0));
            }

            conn.Close();
            return recipe;
        }




    }
}
