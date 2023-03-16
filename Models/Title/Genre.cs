using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMDb.Models
{
    [Table("genre")]
    public class Genre
    {
        [Key]
        public string genreId { get; set; }
        public string? genreName { get; set; }
        public virtual List<HasGenre> hasgenres { get; set; } = new();
    }
}
