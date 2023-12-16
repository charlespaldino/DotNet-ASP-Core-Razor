using MoviesApp.Data;
using MoviesApp.Data.Models;
using MoviesApp.Util;
using System;

namespace MoviesApp.Services
{
    public class FileService : IFileService
    {

        private IWebHostEnvironment webhost_environment;

        public FileService(IWebHostEnvironment webhost_environment)
        {
            this.webhost_environment = webhost_environment;
        }


        public void UploadPoster(IFormFile posted_file, String filename)
        {
            try
            {
                String path = Path.Combine(webhost_environment.WebRootPath, FileUtils.UPLOAD_POSTER_FOLDER);
                FileUtils.uploadFile(posted_file, path, filename);
            }
            catch(Exception){}
        }

    }
}
