using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Summer_School_Movies.Models
{
    public class Actor
    {
        public int actorId { get; set; }
        public string actorName { get; set; }

        public Movie movie { get; set; }
    }
}