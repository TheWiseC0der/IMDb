using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMDb.Models
{
    [Table("rating")]
    public class Rating
    {
        [Key]
        [ForeignKey("titleId")]
        public string titleId { get; set; }
        public double? averageRating { get; set; }
        public int? numVotes { get; set; }
        
        public Title? title { get; set; }
    }
}
