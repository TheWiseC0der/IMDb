using System.ComponentModel.DataAnnotations.Schema;

namespace IMDb.Models
{
    [Table("tvSerie")]
    public class TvSerie : Title
    {
        public int? endYear { get; set; }
    }
}
