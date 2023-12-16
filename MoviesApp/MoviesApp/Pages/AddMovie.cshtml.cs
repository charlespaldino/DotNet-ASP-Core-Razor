using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MoviesApp.Data;
using MoviesApp.Data.Models;
using MoviesApp.Services;
using MoviesApp.Util;
using System.Web;

namespace MoviesApp.Pages
{
    [Authorize(Roles = SecurityUtils.ROLE_ADMIN)]
    public class AddMovieModel : PageModel
    {
        [BindProperty]
        public Movie movie_model { get; set; }

        [BindProperty]
        public IFormFile UploadedFile { get; set; }

        private IMoviesService movie_service { get; set; }
        private IFileService file_service { get; set; }

        private IWebHostEnvironment environment;
    
        public AddMovieModel(IMoviesService movie_service, IFileService file_service, IWebHostEnvironment environment)
        {
            this.movie_service = movie_service;
            this.file_service = file_service;
            this.environment= environment;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) { return Page(); }

            movie_model.Title = HttpUtility.HtmlEncode(SecurityUtils.removeSQL(movie_model.Title));
            movie_model.Description = HttpUtility.HtmlEncode(SecurityUtils.removeSQL(movie_model.Description));


            int new_id = movie_service.AddMovie(new Movie
            {
                Title = movie_model.Title,
                Rating = movie_model.Rating,
                Description = movie_model.Description
            });

            file_service.UploadPoster(UploadedFile, new_id.ToString());
            Movie? new_movie = movie_service.GetMovie(new_id);
            
            new_movie.ImageURL = "/"+FileUtils.UPLOAD_POSTER_FOLDER+"/"+ new_id + Path.GetExtension(UploadedFile.FileName);
            
            movie_service.UpdateMovie(new_movie);

            return Redirect("MovieDetails/" + new_id);
        }


    }
}
