using System.ComponentModel.DataAnnotations.Schema;

namespace Summer_School_Movies.Models
{
    public class Actor
    {
        [ForeignKey(nameof(actorId))]
        public string actorId { get; set; }
        public string actorName { get; set; }
    }
}