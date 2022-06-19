using BooksRatings.API.Dto;
using BooksRatings.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BooksRatings.API.Services
{
    public interface IAuthorService
    {
        public Task<IEnumerable<Author>> GetAll();
        public Task<Author> GetById(int id);
        public Task<Author> Create(AuthorForCreationDto author);
        public Task Update(int id, AuthorForUpdateDto author);
        public Task Delete(int id);
        public Task<Author> GetAuthorAndTheirBooks(int id);
        public Task<List<Author>> GetAllAuthorsAndTheirBooks();
    }
}
