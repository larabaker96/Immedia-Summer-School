﻿using System;
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
            //modelBuilder.Entity<Actor>()
            //.HasOne(p => p.movie)
            //.WithMany(b => b.topActors);


        }
    }
}
