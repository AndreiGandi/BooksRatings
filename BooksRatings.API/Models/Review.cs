namespace BooksRatings.API.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string BookId { get; set; }
        public int Rating { get; set; }
        public string ReviewText { get; set; }
    }
}
