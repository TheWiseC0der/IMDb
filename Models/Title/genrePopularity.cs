using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMDb.Models
{
    [Table("genrePopularity")]
    [Keyless]
    public class genrePopularity
    {
        public string genreName { get; set; }
        public int startYear { get; set; }
        public int number_of_votes { get; set; }
    }
}