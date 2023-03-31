using IMDb.Models;
using IMDb.Repositories;
using IMDb.Views;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using NpgsqlTypes;

namespace IMDb.Pages
{
    public class QueryModel : PageModel
    {
        private readonly CrudRepository _crudRepository;
        public List<PersonComboTwo> PersonCombosTwo { get; set; } = new();
        private readonly ILogger<QueryModel> _logger;
        public List<Genre>? Genres { get; set; }
        [BindProperty] public string selectedGenre { get; set; } = "Thriller";
        [BindProperty] public string selectActorOrMovie { get; set; } = "Actor";

        public QueryModel(CrudRepository crudRepository, ILogger<QueryModel> logger)
        {
            _crudRepository = crudRepository;
            _logger = logger;
            // Reading all genres from the database and setting them to the allGenres property
            Genres = crudRepository.ReadAllRows<Genre>().Result;
        }


        public async Task OnGet()
        {
            
        }

        public async Task OnPostTable()
        {
            // Checking if the selected genre is null or empty, and returning if so
            if (String.IsNullOrEmpty(selectedGenre) || String.IsNullOrEmpty(selectActorOrMovie)) return;
            
                

            if (selectActorOrMovie == "Actor")
            {
                /*int x = _crudRepository.Query(context => context.person
                    .Where(p => p.principals.Any(
                        pc => pc.title.hasgenres.Any(tg => tg.genre.genreName == selectedGenre)))
                    .Select(p => new Person()
                    {
                        personName = p.personName,
                        AverageRating = p.principals.Average(pc => pc.title.rating.averageRating)
                    })
                    .Count()).Result;*/
                // FindRowsWithValue<PersonGenreRating>(x => x.genre == selectedGenre, 10).Result;
                PersonCombosTwo = await _crudRepository.FindRowsWithValue<PersonComboTwo>(x =>
                    x.genreName == selectedGenre);
            }

        }
    }
}