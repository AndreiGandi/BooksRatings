using BooksRatings.API.Dto;
using BooksRatings.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BooksRatings.API.Services
{
    public class BookService : IBookService
    {
        public Task<Book> Create(BookForCreationDto book)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Book>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<Book> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(int id, BookForUpdateDto book)
        {
            throw new System.NotImplementedException();
        }
    }
}
