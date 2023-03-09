using IMDb.Models;
using IMDb.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IMDb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly CrudRepository _crudRepo;
        private readonly ILogger<IndexModel> _logger;
        public List<movie>? movies { get; set; }
        private int seriecount;

        public IndexModel(ILogger<IndexModel> logger, CrudRepository crudRepo)
        {
            _logger = logger;
            _crudRepo = crudRepo;
        }

        public async Task OnGet()
        {
           movies = await _crudRepo.FindRowsWithValue<movie>(movie => movie.isadult = true);
        }
    }
}