using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviesApp.Data;
using MoviesApp.Data.Models;
using MoviesApp.Services;
using MoviesApp.Util;

namespace MoviesApp.Pages
{
    public class MoviesModel : PageModel
    {
        public List<Movie> movie_list { get; set; }

        private IMoviesService movie_service { get; set; }

        public MoviesModel(IMoviesService movie_service)
        {
            this.movie_service = movie_service;
        }

        public void OnGet()
        {
            movie_list = movie_service.GetAllMovies();
        }
    }
}
