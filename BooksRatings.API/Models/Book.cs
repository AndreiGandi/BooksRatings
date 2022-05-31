using System.ComponentModel.DataAnnotations;

namespace BooksRatings.API.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
        public int Year { get; set; }

    }
}
