using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMDb.Views
{
    [Table("PersonGenreRating")]
    [Keyless]
    public class PersonGenreRating
    {
        public string persoon { get; set; }
        public string genre { get; set; }
        public double gemiddelde_rating { get; set; }
    }
}
