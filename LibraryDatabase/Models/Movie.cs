namespace LibraryDatabase.Models
{
    public class Movie
    {
        public int movie_id { get; set; }
        public string title { get; set; }

        public string director { get; set; }
        public string duration { get; set; }
        public DateTime release_date { get; set; }
        public string genre { get; set; }

    }
}
