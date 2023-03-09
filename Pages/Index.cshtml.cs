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

        public int moviecount;
        public List<movie> movies = new List<movie>();

        public IndexModel(ILogger<IndexModel> logger, CrudRepository crudRepo)
        {
            _logger = logger;
            _crudRepo = crudRepo;
        }

        public async Task OnGet()
        {
            moviecount = await _crudRepo.CountAllRows<movie>();
            Predicate<movie> match = m => m.startyear > 1996; 
            movies = await _crudRepo.FindRowsWithValue(match);
        }   
    }
}