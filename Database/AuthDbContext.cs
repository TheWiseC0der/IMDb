using IMDb.Models;
using IMDb.Models.Title_Person;
using IMDb.Views;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IMDb.Database;

public class AuthDbContext : DbContext
{
    public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
    {
    }


    //Titles
    public DbSet<Movie> movie { get; set; }
    public DbSet<Title> title { get; set; }
    public DbSet<Episode> episode { get; set; }
    public DbSet<AlsoKnownAs> alsoknownas { get; set; }
    public DbSet<VideoGame> videogame { get; set; }
    public DbSet<Genre> genre { get; set; }
    public DbSet<HasGenre> hasgenre { get; set; }
    public DbSet<Rating> rating { get; set; }
    public DbSet<Region> region { get; set; }
    public DbSet<TvSerie> tvserie { get; set; }
    public DbSet<TvSpecial> tvspecial { get; set; }
    public DbSet<TvShort> tvshort { get; set; }
    public DbSet<Short> _short { get; set; }
    public DbSet<TvMovie> tvmovie { get; set; }
    public DbSet<Video> video { get; set; }
    public DbSet<genrePopularity> genrePopularity { get; set; }
    public DbSet<PersonGenreRating> PersonGenreRating { get; set; }



    //Persons
    public DbSet<Person> person { get; set; }
    public DbSet<Profession> profession { get; set; }
    public DbSet<HasProfession> hasprofession { get; set; }


    //Title_Person
    public DbSet<Principals> principals { get; set; }
    public DbSet<IsDirectorFor> isdirectorfor { get; set; }
    public DbSet<IsWriterFor> iswriterfor { get; set; }
    public DbSet<Category> category { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("imdb");
        base.OnModelCreating(modelBuilder);

        //
        //association keys
        //
        modelBuilder.Entity<HasProfession>().HasKey(hp => new { hp.personId, hp.professionId });
        modelBuilder.Entity<IsDirectorFor>().HasKey(idf => new { idf.personId, idf.titleId });
        modelBuilder.Entity<IsWriterFor>().HasKey(iwf => new { iwf.personId, iwf.titleId });
        modelBuilder.Entity<HasGenre>().HasKey(hg => new { hg.genreId, hg.titleId });
        modelBuilder.Entity<Principals>().HasKey(p => new { p.titleId, p.personId, p.categoryId });
        modelBuilder.Entity<AlsoKnownAs>().HasKey(aka => new { aka.titleId, aka.ordering });
        modelBuilder.Entity<genrePopularity>().HasNoKey();
        modelBuilder.Entity<PersonGenreRating>().HasNoKey();
        //
        //foreign key references
        //

        //principals
        modelBuilder.Entity<Principals>().HasOne(x => x.person).WithMany(x => x.principals)
            .HasForeignKey(x => x.personId);
        modelBuilder.Entity<Principals>().HasOne(x => x.title).WithMany(x => x.principals)
            .HasForeignKey(x => x.titleId);
        modelBuilder.Entity<Principals>().HasOne(x => x.category).WithMany(x => x.principals)
            .HasForeignKey(x => x.categoryId);

        modelBuilder.Entity<Rating>().HasOne(rating => rating.title).WithOne(title => title.rating)
            .HasForeignKey<Rating>(rating => rating.titleId);
    }
}