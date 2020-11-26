using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Summer_School_Movies.Models
{
    public class Actor
    {
        [Key]
        public int actorId { get; set; }
        public string actorName { get; set; }

        public ICollection<Movie> movie { get; set; }
    }
}