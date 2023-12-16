using MoviesApp.Data;
using MoviesApp.Data.Models;

namespace MoviesApp.Services
{
    public class LoginService : ILoginService
    {
        private ApplicationDbContext db_context { get; set; }
        public LoginService(ApplicationDbContext context)
        {
            db_context = context;
        }

        public bool Login(string username, string password)
        {
            return true;
        }
    }
}
