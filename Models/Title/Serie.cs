using System.ComponentModel.DataAnnotations.Schema;

namespace IMDb.Models
{
    [Table("serie")]
    public class Serie : Title
    {
        public int? endYear;
    }
}
