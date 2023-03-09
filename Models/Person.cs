using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMDb.Models
{
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int personid { get; set; }
        public string personname { get; set; }
        public int? birthyear { get; set; }
        public int? deathyear { get; set; }

    }
}
