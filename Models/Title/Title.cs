using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using IMDb.Models.Title_Person;

namespace IMDb.Models
{
    [Table("title")]
    public class Title
    {
        [Key] public string titleId { get; set; }
        public string? primaryTitle { get; set; }
        public bool isAdult { get; set; }
        public int? startYear { get; set; }
        public int? runtimeMinutes { get; set; }

        public virtual List<IsWriterFor> iswritersfors { get; set; } = new();
        public virtual List<IsDirectorFor> isdirectorfors { get; set; } = new();
        public virtual List<Principals> principals { get; set; } = new();
        public virtual List<HasGenre> hasgenres { get; set; } = new();
        [NotMapped]
        public Rating rating { get; set; }
    }
}