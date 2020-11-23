using System;
using System.ComponentModel.DataAnnotations;

namespace Summer_School_Movies.Models
{
    public class Movie
    {
        public int movieId { get; set; }

        public string movieName { get; set; }

        public string description { get; set; }

        [DataType(DataType.Date)]
        public string releaseDate { get; set; }

        public string ageRestriction { get; set; }

        public Actor topActor1 { get; set; }

        public Actor topActor2 { get; set; }

        public Actor topActor3 { get; set; }

        public Genre movieGenre { get; set; }
    }
}
