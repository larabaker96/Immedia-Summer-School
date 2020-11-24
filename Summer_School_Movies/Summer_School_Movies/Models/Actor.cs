namespace Summer_School_Movies.Models
{
    public class Actor
    {
        public string actorId { get; set; }
        public string actorName { get; set; }

        public Movie movie { get; set; }
    }
}