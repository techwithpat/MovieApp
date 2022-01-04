using System.ComponentModel.DataAnnotations;

namespace MovieApp.Data
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public int Year { get; set; }
        public string Summary { get; set; }
        [MaxLength(3)]
        public List<Actor> Actors { get; set; }
    }

    public class Actor
    {
        public int Id { get; set; }
        [Required]
        public string Fullname { get; set; }
    }
}
