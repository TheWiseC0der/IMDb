using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IMDb.Pages
{
    public class PredictorModel : PageModel
    {
        private readonly ILogger<QuerierModel> _logger;

        public PredictorModel(ILogger<QuerierModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}