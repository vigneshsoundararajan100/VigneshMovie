using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VigneshMovie.Model
{
    public class Movies
    {
        [Key]
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public int Price { get; set; }
        public string Genre { get; set;}
        public int Rating { get; set; }
        public int Year { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }

       public ICollection<Review> Review { get; set; }

        public IList<MovieActor> MovieActor { get; set; }
    }
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        public string PersonName { get; set;}
        public ICollection<Review> Review { get; set; }
    }
    public class Review
    {
        public int ReviewId { get; set; }
        public int PersonId { get; set; }
        public string Comments { get; set; }
        public int MovieId { get; set; }
       public Person Person { get; set; }
        public Movies Movies { get; set; }
    }
    public class Actor
    {
        public int ActorId { get; set; }
        public string ActorName { get; set; }
        public DateTime DOB { get; set; }
        public IList<MovieActor> MovieActor { get; set; }

    }
    public class MovieActor
    {
        public int ActorId { get; set; }
        public Actor Actor { get; set; }
        public int MovieId { get; set; }
        public Movies Movies { get; set; }
    }

}
