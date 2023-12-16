using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Runtime.ConstrainedExecution;
using System.Security.Claims;

namespace MoviesApp.Util
{
    public class SecurityUtils
    {
        #region "Authentication"
            public const String ROLE_ADMIN = "Admin";


            public static ClaimsPrincipal getAdminClaim()
            {
                return new ClaimsPrincipal(new ClaimsIdentity
                        (
                            new List<Claim> { new Claim(ClaimTypes.Role, ROLE_ADMIN) },
                            CookieAuthenticationDefaults.AuthenticationScheme
                        ));
            }

            public static AuthenticationProperties getAdminAuthProperties()
            {
                return new AuthenticationProperties
                    {
                        AllowRefresh = true,
                        IssuedUtc = DateTimeOffset.UtcNow,
                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(90),
                        IsPersistent = true
                    };

            }

        #endregion


        #region "Security - SQL Injection"

        /// <summary>
        /// This returns the same string, with various SQL keywords removed.
        /// Removes " INSERT ", " INTO ", " FROM " , " SELECT ", " * ", " DELETE ", " DROP ", " ALTER "
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static String removeSQL(String input)
        {
            input = input.Replace(" INSERT ", "").Replace(" INTO ", "").Replace(" FROM ", "");
            input = input.Replace(" SELECT ", "").Replace(" * ", "").Replace(" DELETE ", "").Replace(" DROP ", "");
            input = input.Replace(" ALTER ", "");

            return input;
        }

        #endregion
    }
}



