using System.ComponentModel.DataAnnotations.Schema;

namespace IMDb.Models
{
    [Table("movie")]
    public class Movie : Title
    {
    }
}