using IMDb.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IMDb.Database
{
    public class AuthDbContext : IdentityDbContext<ApplicationUser>
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }

        //
        //migration adding tables
        //

        public DbSet<Movie>? movies { get; set; }
        
        /// <summary>
        /// handles everything with initing the database
        /// </summary>
        /// <param name="builder"></param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //
            //keys
            //
        
            //
            //data seeding
            //
            builder.Entity<IdentityRole>().HasData(new List<IdentityRole>()
            {
                new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" },
            });
            
            //
            //renaming
            //
            //builder.Entity<ApplicationUser>(entity => { entity.ToTable(name: "User"); });
            //builder.Entity<IdentityRole>(entity => { entity.ToTable(name: "Role"); });
            //builder.Entity<IdentityUserRole<string>>(entity => { entity.ToTable("UserRoles"); });
            //builder.Entity<IdentityUserClaim<string>>(entity => { entity.ToTable("UserClaims"); });
            //builder.Entity<IdentityUserLogin<string>>(entity => { entity.ToTable("UserLogins"); });
            //builder.Entity<IdentityRoleClaim<string>>(entity => { entity.ToTable("RoleClaims"); });
            //builder.Entity<IdentityUserToken<string>>(entity => { entity.ToTable("UserTokens"); });
        }
    }
}