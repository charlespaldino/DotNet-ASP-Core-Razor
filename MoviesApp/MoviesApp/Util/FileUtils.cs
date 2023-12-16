namespace MoviesApp.Util
{
    public class FileUtils
    {
        public const String UPLOAD_POSTER_FOLDER = "img";

        /// <summary>
        /// Uploads the file to the designated path.
        /// File extension is puleld from the posted file.
        /// </summary>
        internal static void uploadFile(IFormFile posted_file, String path, String filename)
        {
            String newpath = Path.Combine(path, filename + Path.GetExtension(posted_file.FileName));
            using (FileStream stream = new FileStream(newpath, FileMode.Create))
            {
                posted_file.CopyTo(stream);
            }
        }
    }
}
