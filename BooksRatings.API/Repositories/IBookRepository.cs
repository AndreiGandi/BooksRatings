using BooksRatings.API.Dto;
using BooksRatings.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace BooksRatings.API.Repositories
{
    public interface IBookRepository
    {
        public Task<Book> GetBook(int id);
        public Task<IEnumerable<Book>> GetBooks();
        public Task<Book> CreateBook(BookForCreationDto book);
        

    }
}
