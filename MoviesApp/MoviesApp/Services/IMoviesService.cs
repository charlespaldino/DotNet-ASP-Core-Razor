using MoviesApp.Data.Models;

namespace MoviesApp.Services
{
    public interface IMoviesService
    {
        List<Movie> GetAllMovies();
        Movie? GetMovie(int id);

        /// <summary>
        /// Adds a new movie to the database.
        /// </summary>
        /// <returns>Expected return of the generated ID. -1 for failure.</returns>
        int AddMovie(Movie movie);

        void UpdateMovie(Movie movie);
    }
}
