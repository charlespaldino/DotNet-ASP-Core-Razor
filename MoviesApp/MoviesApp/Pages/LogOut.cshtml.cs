using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviesApp.Util;
using System.Security.Claims;

namespace MoviesApp.Pages
{
    public class LogOutModel : PageModel
    {
        public IActionResult OnGet()
        {
            try
            {
                HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme, SecurityUtils.getAdminAuthProperties());
                return Redirect("Movies");
            }
            catch (Exception)
            {
                return StatusCode(404);
            }
        }
    }
}
