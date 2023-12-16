using MoviesApp.Data;
using MoviesApp.Data.Models;

namespace MoviesApp.Services
{
    public class MoviesService : IMoviesService
    {
        private ApplicationDbContext db_context { get; set; }
        public MoviesService(ApplicationDbContext context) 
        {
            db_context = context;
        }

        public int AddMovie(Movie movie)
        {
            db_context.Add(movie);
            db_context.SaveChanges();
            return movie.ID;
        }

        public List<Movie> GetAllMovies()
        {
            return db_context.Movies.ToList();
        }

        public Movie? GetMovie(int id)
        {
            return db_context.Movies.ToList().FirstOrDefault(movie => movie.ID == id);
        }

        public void UpdateMovie(Movie movie)
        {
            db_context.Movies.Update(movie);
            db_context.SaveChanges();  
        }
    }
}
