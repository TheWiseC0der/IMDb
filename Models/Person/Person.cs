using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using IMDb.Models.Title_Person;

namespace IMDb.Models
{
    [Table("person")]
    public class Person
    {
        [Key]
        public string personId { get; set; }
        public string personName { get; set; }
        public int? birthYear { get; set; }
        public int? deathYear { get; set; }
        
        public virtual List<HasProfession> hasprofessions { get; set; } = new();
        public virtual List<IsWriterFor> iswritersfors { get; set; } = new();
        public virtual List<IsDirectorFor> isdirectorfors { get; set; } = new();
        public virtual List<Principals> principals { get; set; } = new();
    }
}
