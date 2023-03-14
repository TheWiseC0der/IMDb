using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMDb.Models.Title_Person;

[Table("principals")]
public class Principals
{
    [Key]
    [ForeignKey("titleId")]
    public string titleId { get; set; }
    [Key]
    public int ordering { get; set; }
    [ForeignKey("personId")]
    public string personId { get; set; }
    [ForeignKey("categoryId")]
    public string? categoryId { get; set; }
    public string? job { get; set; }
    public string? characters { get; set; }
    
    public Person? person { get; set; }
    public Title? title { get; set; }
    public Category? category { get; set; }
}