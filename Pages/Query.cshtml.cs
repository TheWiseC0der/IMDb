using IMDb.Models;
using IMDb.Repositories;
using IMDb.Views;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using IMDb.Models.Title_Person;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using NpgsqlTypes;

namespace IMDb.Pages
{
    public class QueryModel : PageModel
    {
        private readonly CrudRepository _crudRepository;
        public List<PersonComboTwo> PersonCombosTwos { get; set; } = new();
        public List<DirectorComboTwo> DirectorComboTwos { get; set; } = new();
        public List<WriterComboTwo> WriterComboTwos { get; set; } = new();
        private readonly ILogger<QueryModel> _logger;
        public List<Genre>? Genres { get; set; }
        [BindProperty] public string selectedGenre { get; set; } = "Thriller";
        [BindProperty] public string selectedActorOrWriterOrDirector { get; set; } = "Actor";
        [BindProperty] public int selectedSuccesfulTitles { get; set; } = 5;

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
            if (String.IsNullOrEmpty(selectedGenre) || String.IsNullOrEmpty(selectedActorOrWriterOrDirector)) return;
            
                

            if (selectedActorOrWriterOrDirector == "Actor")
            {
                PersonCombosTwos = await _crudRepository.FindRowsWithValue<PersonComboTwo>(x =>
                    x.genreName == selectedGenre && x.played_in_succesful_titles >= selectedSuccesfulTitles, 10);
            }

            if (selectedActorOrWriterOrDirector == "Director")
            {
                DirectorComboTwos = await _crudRepository.FindRowsWithValue<DirectorComboTwo>(x =>
                    x.genreName == selectedGenre && x.played_in_succesful_titles >= selectedSuccesfulTitles, 10);
            }
            if (selectedActorOrWriterOrDirector == "Writer")
            {
                WriterComboTwos = await _crudRepository.FindRowsWithValue<WriterComboTwo>(x =>
                    x.genreName == selectedGenre && x.played_in_succesful_titles >= selectedSuccesfulTitles, 10);
            }

        }
    }
}