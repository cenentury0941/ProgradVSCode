using Assessment.Models;
using Microsoft.Data.SqlClient;
using System.Net;

namespace Assessment
{

    public class DBHandler
    {
        private static List<FileModel> fileList;
        private static string connection_string = "Data Source=DESKTOP-GEG4MT8;Initial Catalog=TrainingDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        public static bool LoginUser(string email, string password)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connection_string);
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand("LOGIN_USER", conn);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter("@UEMAIL", email));
                sqlCommand.Parameters.Add(new SqlParameter("@UPASS", password));
                SqlDataReader reader = sqlCommand.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    UserData.name = reader.GetString(2);
                    UserData.email = reader.GetString(1);
                    UserData.id = ""+reader.GetInt32(0);
                }
                else
                {
                    UserData.name= null;
                    UserData.email = null;
                    UserData.id = null;
                }
                conn.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return UserData.email != null;
        }

        public static bool CreateUser(string username, string email, string password)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connection_string);
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

        public static List<FileModel> FetchFiles()
        {
            fileList= new List<FileModel>();
            try
            {
                SqlConnection conn = new SqlConnection(connection_string);
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand("FETCH_FILES", conn);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter("@USERID", Convert.ToInt32(UserData.id)));
                SqlDataReader reader = sqlCommand.ExecuteReader();
                
                while ( reader.Read() )
                {
                    FileModel file = new FileModel();
                    file.userid = reader.GetInt32(0);
                    file.fileid = reader.GetInt32(1);
                    file.filename = reader.GetString(2);
                    file.content = reader.GetString(3);
                    file.created = reader.GetDateTime(4);
                    file.modified = reader.GetDateTime(5);
                    fileList.Add(file);
                }

                conn.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return fileList;
        }

        public static int CreateFile(string fileName)
        {
            int row_count = -1;
            try
            {
                SqlConnection conn = new SqlConnection(connection_string);
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand("CREATE_FILE", conn);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter("@FILENAME", fileName));
                sqlCommand.Parameters.Add(new SqlParameter("@USERID", Convert.ToInt32(UserData.id)));
                row_count = sqlCommand.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return row_count;
        }

        public static int DeleteFile(int fileId)
        {
            int row_count = -1;
            try
            {
                SqlConnection conn = new SqlConnection(connection_string);
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand("DELETE_FILES", conn);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter("@FILEID", fileId));
                sqlCommand.Parameters.Add(new SqlParameter("@USERID", Convert.ToInt32(UserData.id)));
                row_count = sqlCommand.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return row_count;
        }

        public static FileModel GetFile(int id)
        {
            return fileList.Find(x => x.fileid == id);
        }

        public static int UpdateFile(int fileId , string contents , string filename )
        {
            int row_count = -1;
            try
            {
                SqlConnection conn = new SqlConnection(connection_string);
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand("UPDATE_FILE", conn);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter("@FILEID", fileId));
                sqlCommand.Parameters.Add(new SqlParameter("@USERID", Convert.ToInt32(UserData.id)));
                sqlCommand.Parameters.Add(new SqlParameter("@CONTENT", contents));
                sqlCommand.Parameters.Add(new SqlParameter("@FILENAME", filename));
                row_count = sqlCommand.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return row_count;
        }


    }
}
