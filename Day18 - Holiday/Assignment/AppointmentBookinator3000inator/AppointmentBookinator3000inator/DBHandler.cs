using AppointmentBookinator3000inator.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Data.SqlClient;

namespace AppointmentBookinator3000inator
{
    public class DBHandler
    {
        private static string CONNECTION_STR = "Data Source=MSI;Initial Catalog=AppointDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static bool LoginUser( string email , string password )
        {
            try
            {
                SqlConnection conn = new SqlConnection(CONNECTION_STR);
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand( "LOGIN_USER" , conn );
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter("@UEMAIL", email));
                sqlCommand.Parameters.Add(new SqlParameter("@UPASS", password));
                SqlDataReader reader = sqlCommand.ExecuteReader();
                reader.Read();
                if ( reader.HasRows )
                {
                    UserData.userName = reader.GetString(2);
                    UserData.email = reader.GetString(1);
                    UserData.userID = reader.GetInt32(0);
                }
                else {
                    UserData.userName = null;
                    UserData.email = null;
                    UserData.userID = -1;
                }
                conn.Close();
            }catch( SqlException ex) { 
                Console.WriteLine(ex.ToString() );
            }
            return UserData.email != null ;
        }

        public static bool CreateUser( string username , string email, string password)
        {
            try
            {
                SqlConnection conn = new SqlConnection(CONNECTION_STR);
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand("CREATE_USER", conn);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter("@UEMAIL", email));
                sqlCommand.Parameters.Add(new SqlParameter("@UPASS", password));
                sqlCommand.Parameters.Add(new SqlParameter("@UNAME", username));
                int row_count = sqlCommand.ExecuteNonQuery();
                conn.Close();
                LoginUser(email, password);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return UserData.email != null;
        }

        public static List<AppointmentModel> FetchAppointments()
        { 
            List<AppointmentModel> appointments = new List<AppointmentModel>();

            try
            {
                SqlConnection conn = new SqlConnection(CONNECTION_STR);
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand("GET_APPOINTMENTS", conn);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter("@USERID", UserData.userID));
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while( reader.Read() )
                {
                    AppointmentModel appointment = new AppointmentModel();
                    appointment.id = reader.GetInt32(0);
                    appointment.title = reader.GetString(2);
                    appointment.individual= reader.GetString(3);
                    appointment.start = reader.GetDateTime(4);
                    appointment.end = reader.GetDateTime(5);
                    appointments.Add(appointment);
                }
                conn.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return appointments;
        }

        public static List<AppointmentModel> FetchAppointments( string id , string title , string individual , string start , string end )
        {
            List<AppointmentModel> appointments = new List<AppointmentModel>();

            try
            {
                SqlConnection conn = new SqlConnection(CONNECTION_STR);
                conn.Open();

                string Command = "SELECT * FROM APPOINTMENTS";

                if ((id + title + individual + start + end).Length > 0)
                {
                    Command += " WHERE ";
                }
                else {
                    return FetchAppointments();
                }

                if (id.Length > 0)
                {
                    Command += $" ID = '{id}' AND ";
                }

                if (title.Length > 0)
                {
                    Command += $" TITLE = '{title}' AND ";
                }

                if (individual.Length > 0)
                {
                    Command += $" INDIVIDUAL = '{individual}' AND ";
                }

                if (start.Length > 0)
                {
                    Command += $" START_DATE > '{start}' AND ";
                }

                if (end.Length > 0)
                {
                    Command += $" END_DATE <= '{end}' AND ";
                }

                Command += " ID > 0;";

                Console.WriteLine( $"Limited search : {Command}" );
                SqlCommand sqlCommand = new SqlCommand( Command , conn);

                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    AppointmentModel appointment = new AppointmentModel();
                    appointment.id = reader.GetInt32(0);
                    appointment.title = reader.GetString(2);
                    appointment.individual = reader.GetString(3);
                    appointment.start = reader.GetDateTime(4);
                    appointment.end = reader.GetDateTime(5);
                    appointments.Add(appointment);
                }
                conn.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return appointments;
        }




        public static bool CreateAppointment(string title, string individual, DateTime start_time , DateTime end_time)
        {
            int row_count = -1;
            try
            {
                SqlConnection conn = new SqlConnection(CONNECTION_STR);
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand("CREATE_APPOINTMENT", conn);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter("@USERID", UserData.userID));
                sqlCommand.Parameters.Add(new SqlParameter("@TITLE", title));
                sqlCommand.Parameters.Add(new SqlParameter("@INDIVIDUAL", individual));
                sqlCommand.Parameters.Add(new SqlParameter("@START_TIME", start_time));
                sqlCommand.Parameters.Add(new SqlParameter("@END_TIME", end_time));
                row_count = sqlCommand.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return row_count != -1;
        }

        public static bool DeleteAppointment( int appointmentID )
        {
            int row_count = -1;
            try
            {
                SqlConnection conn = new SqlConnection(CONNECTION_STR);
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand( $"DELETE FROM APPOINTMENTS WHERE ID = {appointmentID};", conn);
                row_count = sqlCommand.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return row_count != -1;
        }

        public static bool AlterAppointment(int id , string title, string individual, DateTime start_time, DateTime end_time)
        {
            int row_count = -1;
            try
            {
                SqlConnection conn = new SqlConnection(CONNECTION_STR);
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand("ALTER_APPOINTMENT", conn);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter("@ID", id));
                sqlCommand.Parameters.Add(new SqlParameter("@TITLE", title));
                sqlCommand.Parameters.Add(new SqlParameter("@INDIVIDUAL", individual));
                sqlCommand.Parameters.Add(new SqlParameter("@START_TIME", start_time));
                sqlCommand.Parameters.Add(new SqlParameter("@END_TIME", end_time));
                row_count = sqlCommand.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return row_count != -1;
        }



    }
}
