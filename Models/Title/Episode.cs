using System.ComponentModel.DataAnnotations.Schema;

namespace IMDb.Models
{
    [Table("episode")]
    public class Episode : Title
    {
        [ForeignKey("titleId")]
        public string? serieId { get; set; }
        public int? seasonNumber { get; set; }
        public int? episodeNumber { get; set; }
        
        public Serie? serie { get; set; }
    }
}
