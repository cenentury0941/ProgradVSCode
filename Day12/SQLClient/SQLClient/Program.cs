using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace SQLClient
{
    internal class Program
    {
        private static string connectionString = "Data Source=DESKTOP-GEG4MT8;Initial Catalog=TrainingDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        static void Main(string[] args)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            DbCommand cmd = conn.CreateCommand();
            //"SELECT * FROM STUDENTS";
            //SqlDataReader read = (SqlDataReader)cmd.ExecuteReader();
            
            
            cmd.CommandText = "DELETE FROM LOGS WHERE ID = 0"; 
            int rowCount = cmd.ExecuteNonQuery();

            if ( rowCount == 0 )
            {
                Console.WriteLine( "No Records" );
            }
            else {

                Console.WriteLine($" {rowCount} Records Erased");
            }
            conn.Close();
            return;

        }
    }
}