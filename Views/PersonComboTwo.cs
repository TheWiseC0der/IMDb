using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace IMDb.Views;

[Table("PersonComboTwo")]
[Keyless]
public class PersonComboTwo
{
    public string personName { get; set; }
    public int birthYear { get; set; }
    public int played_in_successful_titles { get; set; }
    public int played_roles_in_succesful_titles { get; set; }
    public double movie_average_rating { get; set; }
    public string genreName { get; set; }
}