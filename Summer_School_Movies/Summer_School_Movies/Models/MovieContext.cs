using System;
using Microsoft.EntityFrameworkCore;

namespace Summer_School_Movies.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                .HasMany(b => b.topActors)
                .WithOne();

            modelBuilder.Entity<Movie>()
                .Navigation(b => b.topActors)
                .UsePropertyAccessMode(PropertyAccessMode.Property);
        }
    }
}
