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
        public List<Movie> movies = new List<Movie>();

        public IndexModel(ILogger<IndexModel> logger, CrudRepository crudRepo)
        {
            _logger = logger;
            _crudRepo = crudRepo;
        }

        public async Task OnGet()
        {
            moviecount = await _crudRepo.CountAllRows<Movie>();
            Predicate<Movie> match = m => m.startYear > 1996; 
            //example of inner join:
            // movies = <movie, Director, string> (m => m.DirectorId, d => d.Id, (m, d) => new { MovieTitle = m.Title, DirectorName = d.Name }); ;
            movies = await _crudRepo.FindRowsWithValue<Movie>(movie => movie is {isAdult: true, startYear: > 2016});
        }   
    }
}