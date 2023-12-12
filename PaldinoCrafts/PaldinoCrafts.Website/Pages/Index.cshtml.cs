using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace PaldinoCrafts.Website.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> logger;
        public IndexModel(ILogger<IndexModel> logger)
        {
            this.logger = logger;

        }
    }
}
