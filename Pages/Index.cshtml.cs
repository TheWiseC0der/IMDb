// Importing the required namespaces

using IMDb.Models;
using IMDb.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;

namespace IMDb.Pages
{
// Defining the IndexModel class
    public class IndexModel : PageModel
    {
// Private fields for the logger and repository
        private readonly CrudRepository _crudRepo;

        // Public properties for movie count, genres, all genres and genre popularities
        public int moviecount;
        public List<Genre> genres = new();
        public Genre? genre = new();
        public List<Genre> allGenres = new();
        public List<genrePopularity> genrePopularities = new();

        // Bindable property for selected genre, default value set to "Thriller"
        [BindProperty] public string selectedGenre { get; set; } = "Thriller";

        // Constructor for IndexModel, injecting the logger and repository
        public IndexModel(CrudRepository crudRepo)
        {
            _crudRepo = crudRepo;

            // Reading all genres from the database and setting them to the allGenres property
            allGenres = _crudRepo.ReadAllRows<Genre>().Result;

            // Querying the database to get the genres and their title count, and setting them to the genres property
            genres = _crudRepo.Query(dbContext => dbContext.genre.Select(g =>
                new Genre()
                {
                    genreName = g.genreName,
                    titleCount = g.hasgenres.Count()
                }).ToList()).Result;

            // Reading all genres from the database and setting them to the allGenres property
            allGenres = _crudRepo.ReadAllRows<Genre>().Result;
        }

        // Method for handling the post request to filter by genre
        public async Task OnPostGenre()
        {
            // Checking if the selected genre is null or empty, and returning if so
            if (String.IsNullOrEmpty(selectedGenre)) return;

            // Finding the genre popularities for the selected genre and years greater than 1949, and setting them to the genrePopularities property
            genrePopularities = await _crudRepo.FindRowsWithValue<genrePopularity>(gp =>
                gp.genreName == selectedGenre && gp.startYear > 1949);
            
            // Retrieves a genre by name and returns corresponding rating and name
            genre = _crudRepo.Query(DbContext => DbContext.genre.Select(g => new Genre()
            {
                genreName = g.genreName,
                avgRating = g.hasgenres.Average(hg => hg.title.rating.averageRating)
            }).FirstOrDefault(g => g.genreName == selectedGenre)).Result;
        }

        // Method for handling the get request to load the page
        public async Task OnGet()
        {
            // Finding the genre popularities for the selected genre and years greater than 1949, and setting them to the genrePopularities property
            genrePopularities = await _crudRepo.FindRowsWithValue<genrePopularity>(gp =>
                gp.genreName == selectedGenre && gp.startYear > 1949);
            
            // Retrieves a genre by name and returns corresponding rating and name
            genre = _crudRepo.Query(DbContext => DbContext.genre.Select(g => new Genre()
            {
                genreName = g.genreName,
                avgRating = g.hasgenres.Average(hg => hg.title.rating.averageRating)
            }).FirstOrDefault(g => g.genreName == selectedGenre)).Result;
        }
    }
}