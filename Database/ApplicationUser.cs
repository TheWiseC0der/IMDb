using Microsoft.AspNetCore.Identity;

namespace IMDb.Database;

public class ApplicationUser : IdentityUser
{
    public override string? Id { get; set; }
}