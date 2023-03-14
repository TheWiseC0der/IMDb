using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMDb.Models;

[Table("alsoknownas")]
public class AlsoKnownAs
{
    [Key]
    [ForeignKey("titleId")]
    public string titleId { get; set; }
    [Key]
    public int ordering { get; set; }
    public string? titleName { get; set; }
    [ForeignKey("regionId")]
    public string? regionId { get; set; }
    public string? language { get; set; }
    public string? attributes { get; set; }
    public bool? isOriginalTitle { get; set; }
    
    public Title? title { get; set; }
    public Region? region { get; set; }
}