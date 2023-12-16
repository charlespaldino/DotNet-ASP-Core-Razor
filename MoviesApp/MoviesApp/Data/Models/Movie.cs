namespace MoviesApp.Data.Models
{
    public class Movie
    {
        public int ID { get; set; }
        public String Title { get; set; }
        public int Rating { get; set; }
        public String Description { get; set; }
        public String? ImageURL {  get; set; }
    }
}
