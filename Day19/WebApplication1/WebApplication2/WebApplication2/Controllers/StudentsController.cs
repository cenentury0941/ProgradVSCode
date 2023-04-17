using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Buffers;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication2.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private static string connection_string = "Data Source=DESKTOP-GEG4MT8;Initial Catalog=TrainingDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        // GET: api/<StudentsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<StudentsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            Console.WriteLine(value);
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try {
                Response.ContentType = "text";
                SqlConnection conn = new SqlConnection(connection_string);
                conn.Open();
                SqlCommand comm = new SqlCommand( "DELETE_STUDENT" , conn );
                comm.CommandType = System.Data.CommandType.StoredProcedure;
                comm.Parameters.Add( new SqlParameter( "@UID" , id ) );
                int success = comm.ExecuteNonQuery();
                conn.Close();
                if(success==0)
                {
                    throw new Exception("Unable to Deleted!");
                }
                Response.BodyWriter.Write( Encoding.ASCII.GetBytes("Deleted User.") ); ;
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                Response.BodyWriter.Write(Encoding.ASCII.GetBytes( ex.Message ));
            }
        }
    }
}
