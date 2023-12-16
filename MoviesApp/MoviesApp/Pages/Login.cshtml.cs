using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using MoviesApp.Services;
using MoviesApp.Util;
using System.Security.Claims;
using System.Web;

namespace MoviesApp.Pages
{
    public class LoginModel : PageModel
    {

        private ILoginService login_service { get; set; }


        public LoginModel(ILoginService login_service)
        {
            this.login_service = login_service;
        }

        public void OnGet(){}

        public IActionResult OnPost([FromForm] String username, [FromForm] String password)
        {
            username = HttpUtility.HtmlEncode(SecurityUtils.removeSQL(username));
            password = HttpUtility.HtmlEncode(SecurityUtils.removeSQL(password));

            if (login_service.Login(username, password))
            {
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, SecurityUtils.getAdminClaim(), SecurityUtils.getAdminAuthProperties());

                return Redirect("Movies");
            }

            return Page();
        }
    }
}
