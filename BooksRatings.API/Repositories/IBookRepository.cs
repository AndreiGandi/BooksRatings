using BooksRatings.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BooksRatings.API.Repositories
{
    public interface IBookRepository
    {
        public Task<Book> GetBook(int id);
        public Task<IEnumerable<Book>> GetBooks();

    }
}
