using MoviesApp.Data.Models;
using System.Security.Claims;

namespace MoviesApp.Services
{
    public interface IFileService
    {
        void UploadPoster(IFormFile posted_file, String filename);  
    }
}
