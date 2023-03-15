using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMDb.Models;

[Table("hasProfession")]
public class HasProfession
{
    [Key]
    [ForeignKey("personId")]
    public string personId { get; set; }
    [Key]
    [ForeignKey("professionId")]
    public string professionId { get; set; }
    
    public Person? person { get; set; }
    public Profession? profression { get; set; }
    
}