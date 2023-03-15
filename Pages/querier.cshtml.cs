using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IMDb.Pages
{
    public class QuerierModel : PageModel
    {
        private readonly ILogger<QuerierModel> _logger;

        public QuerierModel(ILogger<QuerierModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}