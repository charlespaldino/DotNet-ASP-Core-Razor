using MoviesApp.Data.Models;
using System.Security.Claims;

namespace MoviesApp.Services
{
    public interface ILoginService
    {
        bool Login(String username, String password);  

        

    }
}
