namespace BooksRatings.API.Dto
{
    public class BookForUpdateDto
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int AuthorId { get; set; }
        public int Year { get; set; }
    }
}
