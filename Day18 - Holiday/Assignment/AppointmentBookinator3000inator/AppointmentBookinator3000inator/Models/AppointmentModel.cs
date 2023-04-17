namespace AppointmentBookinator3000inator.Models
{
    public class AppointmentModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public string individual { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }

        public static bool isCreated = true;

    }
}
