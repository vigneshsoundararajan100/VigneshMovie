using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VigneshMovie.Model;

namespace VigneshMovie.Data
{
    public class VigneshMovieContext : DbContext
    {
        public VigneshMovieContext (DbContextOptions<VigneshMovieContext> options)
            : base(options)
        {
        }
       
     public DbSet<VigneshMovie.Model.Movies> Movies { get; set; }
        public DbSet<VigneshMovie.Model.Review> Review{ get; set; }
        public DbSet<VigneshMovie.Model.Person> Person { get; set; }
        public DbSet<VigneshMovie.Model.Actor> Actor { get; set; }
        public DbSet<VigneshMovie.Model.MovieActor> MovieActor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // To set primary key for movies table
            modelBuilder.Entity<Movies>().HasKey(x => x.MovieId);
            modelBuilder.Entity<Review>().HasKey(x => x.ReviewId);
            modelBuilder.Entity<Person>().HasKey(x => x.PersonId);
            modelBuilder.Entity<Actor>().HasKey(x => x.ActorId);
            modelBuilder.Entity<MovieActor>().HasKey(sc => new { sc.ActorId, sc.MovieId });

            modelBuilder.Entity<Review>()
            .HasOne<Movies>(s => s.Movies)
            .WithMany(g => g.Review)
            .HasForeignKey(s => s.MovieId);
            modelBuilder.Entity<Review>()
                       .HasOne<Person>(s => s.Person)
                       .WithMany(g => g.Review)
                       .HasForeignKey(s => s.PersonId);

            modelBuilder.Entity<MovieActor>()
    .HasOne<Movies>(sc => sc.Movies)
    .WithMany(s => s.MovieActor)
    .HasForeignKey(sc => sc.MovieId);


            modelBuilder.Entity<MovieActor>()
                .HasOne<Actor>(sc => sc.Actor)
                .WithMany(s => s.MovieActor)
                .HasForeignKey(sc => sc.ActorId);
            base.OnModelCreating(modelBuilder);
        }
    }
}
