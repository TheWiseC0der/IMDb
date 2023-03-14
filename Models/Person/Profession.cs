using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMDb.Models;

[Table("profession")]
public class Profession
{
    [Key]
    public string professionId { get; set; }
    public string professionName { get; set; }
    
    public virtual List<HasProfession> hasprofessions { get; set; } = new();
}