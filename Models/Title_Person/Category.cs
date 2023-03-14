using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMDb.Models.Title_Person;

[Table("category")]
public class Category
{
    [Key]
    public string categoryId { get; set; }
    public string categoryName { get; set; }
}