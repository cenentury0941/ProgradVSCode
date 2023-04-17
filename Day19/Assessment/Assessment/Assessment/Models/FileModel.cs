namespace Assessment.Models
{
    public class FileModel
    {
        public string filename { get; set; }

        public int userid { get; set; }

        public int fileid { get; set; }

        public string content { get; set; }

        public DateTime created { get; set; }

        public DateTime modified { get; set; }
    }
}
