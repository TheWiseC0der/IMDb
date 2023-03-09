using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMDb.Models
{
    public class Title
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string titleid { get; set; }
        public string primarytitle { get; set; }
        public bool isadult { get; set; }
        public int? startyear { get; set; }
        public int? runtimeminutes { get; set; }

    }
}
