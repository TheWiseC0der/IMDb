using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMDb.Models.Title_Person;

[Table("iswriterfor")]
public class IsWriterFor
{
    [Key]
    [ForeignKey("personId")]
    public string personId { get; set; }
    [Key]
    [ForeignKey("titleId")]
    public string titleId { get; set; }
    
    public Person? person { get; set; }
    public Title? title { get; set; }
}