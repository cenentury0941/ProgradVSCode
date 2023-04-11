using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System.Data.SqlTypes;

namespace WebApplication1.Pages.names
{
    public class createNameModel : PageModel
    {
        public string errMessage { get; set; }

        public void OnGet()
        {
            errMessage = null;
        }

        public void OnPost() {

            SqlConnection conn = null;
            errMessage = "0";
            try
            {
                conn = new SqlConnection("Data Source=MSI;Initial Catalog=TrainingDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                conn.Open();
                SqlCommand command = conn.CreateCommand();

                Names name = new Names();

                name.Name = Request.Form["name"];
                name.Id = Convert.ToInt32( Request.Form["id"] );
                name.Designation = Request.Form["designation"];


                SqlDateTime curTime = System.DateTime.Now;

                command.CommandText = $"insert into GenericNames values( { name.Id } ,'{ name.Name }','{ name.Designation }' , '{curTime}');";
                Console.WriteLine("Page Accessed");

                int alteredRows = command.ExecuteNonQuery();

                if ( alteredRows == 0 )
                {
                    Console.WriteLine("Didn't add name");
                }
                else { 
                    Console.WriteLine("Added name");
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                errMessage = ex.Message;
            }
            finally
            {
                if (conn != null) { conn.Close(); }
            }
            this.Response.Headers["Custom-Header-Yo"] = "Beheaded!";
            Console.WriteLine("Done.");


        }

    }
}
