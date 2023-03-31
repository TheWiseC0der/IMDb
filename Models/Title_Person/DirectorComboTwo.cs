﻿using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IMDb.Models.Title_Person;
[Table("DirectorComboTwo")]
[Keyless]
public class DirectorComboTwo
{
        public string personName { get; set; }
        public int birthYear { get; set; }
        public int played_in_succesful_titles { get; set; }
        public double movie_average_rating { get; set; }
        public string genreName { get; set; }
}