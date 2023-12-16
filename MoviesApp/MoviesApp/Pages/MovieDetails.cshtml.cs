using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviesApp.Data;
using MoviesApp.Data.Models;
using MoviesApp.Services;

namespace MoviesApp.Pages
{
    public class MovieDetailsModel : PageModel
    {
        [BindProperty]
        public Movie? movie_details { get; set; }

        private IMoviesService movie_service { get; set; }

        public MovieDetailsModel(IMoviesService movie_service)
        {
            this.movie_service = movie_service;
        }


        public void OnGet(int id)
        {
            movie_details = movie_service.GetMovie(id);
        }
    }
}
