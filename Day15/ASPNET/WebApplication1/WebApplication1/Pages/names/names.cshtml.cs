using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System.Data.SqlTypes;

namespace WebApplication1.Pages.Students
{
    public class namesModel : PageModel
    {
        public List<Names> nameList;
        public static string str = "object, eh?";
        public void OnGet()
        {
            SqlConnection conn = null;
            nameList = new List<Names>();

            try {
                conn = new SqlConnection("Data Source=MSI;Initial Catalog=TrainingDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                conn.Open();
                SqlCommand command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM GenericNames ORDER BY ID DESC;";
                
                Console.WriteLine( "Page Accessed" );

                SqlDataReader reader = command.ExecuteReader();

                while ( reader.Read() )
                { 

                    Names name = new Names();
                    name.Id = reader.GetInt32(0);
                    name.Name = reader.GetString(1);
                    name.Designation = reader.GetString(2);
                    name.TS = reader.GetDateTime(3);

                    nameList.Add(name);

                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if ( conn != null ) { conn.Close(); }
            }
            Console.WriteLine( "Done." );
        }

        public void OnPost()
        {

            SqlConnection conn = null;
            nameList = new List<Names>();

            try
            {
                conn = new SqlConnection("Data Source=MSI;Initial Catalog=TrainingDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                conn.Open();
                SqlCommand command = conn.CreateCommand();
                string desig = Request.Form["Designation"];
                command.CommandText = $"SELECT * FROM GenericNames WHERE designation = '{desig}' ORDER BY ID DESC;";

                Console.WriteLine("Page Accessed");

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    Names name = new Names();
                    name.Id = reader.GetInt32(0);
                    name.Name = reader.GetString(1);
                    name.Designation = reader.GetString(2);
                    name.TS = reader.GetDateTime(3);

                    nameList.Add(name);

                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (conn != null) { conn.Close(); }
            }
            Console.WriteLine("Done.");


        }
    }


}

public class Names
{

    public Names() { }

    public string Name { get; set; }
    public int Id { get; set; }
    public string Designation { get; set; }
    public SqlDateTime TS { get; set; }
}
