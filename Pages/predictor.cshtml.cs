using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IMDb.Pages
{
    public class PredictorModel : PageModel
    {
        private readonly ILogger<QueryModel> _logger;

        public PredictorModel(ILogger<QueryModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}