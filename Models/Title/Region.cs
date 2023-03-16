using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMDb.Models;

[Table("region")]
public class Region
{
    [Key]
    public string regionId { get; set; }
    public string? regionName { get; set; }
}