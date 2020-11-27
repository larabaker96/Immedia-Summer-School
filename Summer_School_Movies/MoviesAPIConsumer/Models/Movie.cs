using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesAPIConsumer.Models
{
    public class Movie
    {
        //Auto-increment ID

        [Key]
        public int movieId { get; set; }

        public string movieName { get; set; }

        public string description { get; set; }

        public string movieGenre { get; set; }

        [DataType(DataType.Date)]
        public string releaseDate { get; set; }

        public string ageRestriction { get; set; }

        public ICollection<Actor> topActors { get; set; }
    }
}
