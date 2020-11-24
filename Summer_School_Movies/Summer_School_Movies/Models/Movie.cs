using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Summer_School_Movies.Models
{
    public class Movie
    {
        public int movieId { get; set; }

        public string movieName { get; set; }

        public string description { get; set; }

        public string movieGenre { get; set; }

        [DataType(DataType.Date)]
        public string releaseDate { get; set; }

        public string ageRestriction { get; set; }

        [ForeignKey("actorId")]
        public ICollection<Actor> topActors { get; set; }
    }
}
