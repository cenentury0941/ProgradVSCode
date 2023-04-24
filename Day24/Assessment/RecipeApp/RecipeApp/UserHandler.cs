using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp
{
    internal class UserHandler
    {
        private static bool loggedIn = false;
        private static int UserID = -1;
        private static string username;
        private static string password;
        private static DBHandler db = new DBHandler();

        public bool IsLoggedIn()
        {
            return loggedIn;
        }

        public void Login()
        {
            Console.Write("Enter Username : ");
            string uname = Console.ReadLine().Trim().ToLower();
            Console.Write("Enter Password : ");
            string pwd = Console.ReadLine().Trim();
            
            int userid = db.TestUserLogin(uname, pwd);

            if (userid != -1)
            {
                loggedIn = true;
                username = uname; 
                password = pwd;
                UserID = userid;
                Console.WriteLine( $"Logged in as {username}" );
            }
            else {
                loggedIn = false;
                username = null;
                password = null;
                UserID = -1;
                Console.WriteLine( "Error invalid credentials." );
            }

        }

        public void CreateAccount() {
            Console.Write("Enter Username : ");
            string uname = Console.ReadLine().Trim().ToLower();
            Console.Write("Enter Password : ");
            string pwd = Console.ReadLine().Trim();

            bool usercreated = db.CreateUser(uname, pwd);

            if (usercreated)
            {

                int userid = db.TestUserLogin(uname, pwd);
                loggedIn = true;
                username = uname;
                password = pwd;
                UserID = userid;
                Console.WriteLine($"Logged in as {username}");

            }
            else
            {
                loggedIn = false;
                username = null;
                password = null;
                UserID = -1;
                Console.WriteLine("Error Couldn't Create Account.");
            }
        }

        public void Logout()
        {
            loggedIn = false;
            username = null;
            password = null;
            UserID = -1;
            Console.WriteLine("Logged out.");

        }

        public string GetUserName()
        {
            return username;
        }

        public int GetUserId()
        {
            return UserID;
        }

    }
}
