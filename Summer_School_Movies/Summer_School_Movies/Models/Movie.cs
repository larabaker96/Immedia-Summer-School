using System;
using System.ComponentModel.DataAnnotations;

namespace Summer_School_Movies.Models
{
    public class Movie
    {
        public int movieId;

        public string movieName;

        public string description;

        [DataType(DataType.Date)]
        public string releaseDate;

        public string ageRestriction;

        public Actor topActor1;

        public Actor topActor2;

        public Actor topActor3;

        public Genre movieGenre;
    }
}
