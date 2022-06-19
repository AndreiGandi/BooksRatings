using BooksRatings.API.Dto;
using BooksRatings.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BooksRatings.API.Services
{
    public interface IBookService
    {
        public Task<Book> GetById(int id);
        public Task<IEnumerable<Book>> GetAll();
        public Task<Book> Create(BookForCreationDto book);
        public Task Update(int id, BookForUpdateDto book);
        public Task Delete(int id);
    }
}
