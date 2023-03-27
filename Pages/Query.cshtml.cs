using IMDb.Models;
using IMDb.Repositories;
using IMDb.Views;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace IMDb.Pages
{
    public class QueryModel : PageModel
    {
        private readonly CrudRepository _crudRepository;
        public List<PersonGenreRating> personPlaysInGenres { get; set; } = new();
        private readonly ILogger<QueryModel> _logger;

        public QueryModel(CrudRepository crudRepository, ILogger<QueryModel> logger)
        {
            _crudRepository = crudRepository;
            _logger = logger;
            Genres = crudRepository.ReadAllRows<Genre>().Result;
            personPlaysInGenres = _crudRepository.ReadAllRows<PersonGenreRating>().Result;
        }


        public List<Genre>? Genres { get; set; }

        public async Task OnGet()
        {
        }
    }
}