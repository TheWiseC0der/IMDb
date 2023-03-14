using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMDb.Models;

[Table("hasgenre")]
public class HasGenre
{
    [Key]
    [ForeignKey("titleId")]
    public string titleId { get; set; }
    [Key]
    [ForeignKey("genreId")]
    public string genreId { get; set; }
    
    public Title? title { get; set; }
    public Genre? genre { get; set; }
}