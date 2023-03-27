using System.Text;

namespace FileHandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            FileStream fs = new FileStream( "Trojan.txt", FileMode.OpenOrCreate , FileAccess.ReadWrite );
            fs.Seek( 5, SeekOrigin.Begin );
            fs.Write(Encoding.ASCII.GetBytes("123456789012345678901234567890"));
            fs.Close(); 
            FileStream fs2 = new FileStream("Trojan.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            //fs2.Seek(2, SeekOrigin.Begin );
            //StreamReader sr = new StreamReader(fs2);
            //byte[] buffer = new byte[128];
            //fs2.Read(buffer);
            //string str = Encoding.ASCII.GetString(buffer);
            fs2.Seek(12, SeekOrigin.Begin);
            StreamWriter sw = new StreamWriter(fs2);
            sw.Write(("ppppppppp"));
            sw.Close();

            fs2.Close();
            fs2 = new FileStream("Trojan.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);

            StreamReader sr = new StreamReader(fs2);
            Console.WriteLine( $"File Content : { sr.ReadToEnd() }" );
            
            sr.Close();

            



        }
    }
}