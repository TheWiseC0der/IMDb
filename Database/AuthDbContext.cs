using IMDb.Models;
using IMDb.Models.Title_Person;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IMDb.Database;

public class AuthDbContext : IdentityDbContext<ApplicationUser>
{
    public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
    {
    }


    //Titles
    public DbSet<Movie> movie { get; set; }
    public DbSet<Title> title { get; set; }
    public DbSet<Episode> episode { get; set; }
    public DbSet<AlsoKnownAs> alsoknownas { get; set; }
    public DbSet<Film> film { get; set; }
    public DbSet<Game> game { get; set; }
    public DbSet<Genre> genre { get; set; }
    public DbSet<HasGenre> hasgenre { get; set; }
    public DbSet<Rating> rating { get; set; }
    public DbSet<Region> region { get; set; }
    public DbSet<Serie> serie { get; set; }
    public DbSet<Short> _short { get; set; }
    public DbSet<TvMovie> tvmovie { get; set; }
    public DbSet<Video> video { get; set; }


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
        modelBuilder.Entity<Movie>().ToTable("movie");


        //
        //association keys
        //
        modelBuilder.Entity<HasProfession>().HasKey(hp => new { hp.personId, hp.professionId });
        modelBuilder.Entity<IsDirectorFor>().HasKey(idf => new { idf.personId, idf.titleId });
        modelBuilder.Entity<IsWriterFor>().HasKey(iwf => new { iwf.personId, iwf.titleId });
        modelBuilder.Entity<HasGenre>().HasKey(hg => new { hg.genreId, hg.titleId });
        modelBuilder.Entity<Principals>().HasKey(p => new { p.titleId, p.personId, p.categoryId });
        modelBuilder.Entity<AlsoKnownAs>().HasKey(aka => new { aka.titleId, aka.regionId });

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

        //rating
        modelBuilder.Entity<Rating>().HasOne(x => x.title).WithMany(x => x.rating)
            .HasForeignKey(x => x.titleId);
    }
}