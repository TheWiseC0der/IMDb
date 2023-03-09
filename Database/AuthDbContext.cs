using IMDb.Models;
using Microsoft.EntityFrameworkCore;

namespace IMDb.Database;
public class AuthDbContext : DbContext
{
    public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<movie> titlemovie { get; set; }
    public DbSet<tvmovie> titletvMovie { get; set; }
    public DbSet<Serie> titletvSerie { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("imdb");
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>().HasKey(u => u.Id);
        modelBuilder.Entity<User>().Property(u => u.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
    }
}