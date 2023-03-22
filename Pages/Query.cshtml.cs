using IMDb.Models;
using IMDb.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IMDb.Pages
{
    public class QueryModel : PageModel
    {
        private readonly CrudRepository _crudRepository;
        private readonly ILogger<QueryModel> _logger;
        public QueryModel(CrudRepository crudRepository, ILogger<QueryModel> logger)
        {
            _crudRepository = crudRepository;
            _logger = logger;
            Genres = crudRepository.ReadAllRows<Genre>().Result;
        }

        
        public List<Genre>? Genres { get; set; }

        public void OnGet()
        {
        }
    }
}