﻿using IMDb.Models;
using IMDb.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;

namespace IMDb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly CrudRepository _crudRepo;
        private readonly ILogger<IndexModel> _logger;

        public int moviecount;
        public List<Genre> genres = new();
        public List<Genre> allGenres = new();

        public List<genrePopularity> genrePopularities = new();

        [BindProperty] public string selectedGenre { get; set; } = "Thriller";

        public IndexModel(ILogger<IndexModel> logger, CrudRepository crudRepo)
        {
            _logger = logger;
            _crudRepo = crudRepo;
            allGenres = _crudRepo.ReadAllRows<Genre>().Result;
        }

        public async Task OnPostGenre()
        {
            if (String.IsNullOrEmpty(selectedGenre)) return;
            
            genrePopularities =
                await _crudRepo.FindRowsWithValue<genrePopularity>(gp =>
                    gp.genreName == selectedGenre && gp.startYear > 1949);
        }

        public async Task OnGet()
        {
            // moviecount = await _crudRepo.CountAllRows<Movie>();
            // Predicate<Movie> match = m => m.startYear > 1996; 
            //example of inner join:
            // movies = <movie, Director, string> (m => m.DirectorId, d => d.Id, (m, d) => new { MovieTitle = m.Title, DirectorName = d.Name }); ;

            allGenres = await _crudRepo.ReadAllRows<Genre>();
            genrePopularities =
                await _crudRepo.FindRowsWithValue<genrePopularity>(gp =>
                    gp.genreName == selectedGenre && gp.startYear > 1949);
            //
            // genres = await _crudRepo.Query(DbContext => DbContext.genre.Select(g => new Genre()
            // {
            //     genreName = g.genreName,
            //     avgRating = g.hasgenres.Average(hg => hg.title.rating.averageRating)
            // }).ToListOrDefault());

            genres = await _crudRepo.Query(dbContext => dbContext.genre.Select(g =>
                new Genre()
                {
                    genreName = g.genreName,
                    titleCount = g.hasgenres.Count()
                }).ToList());
        }
    }
}