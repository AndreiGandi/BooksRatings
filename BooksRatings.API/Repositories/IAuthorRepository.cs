using BooksRatings.API.Dto;
using BooksRatings.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BooksRatings.API.Repositories
{
    public interface IAuthorRepository
    {
        public Task<IEnumerable<Author>> GetAuthors();
        public Task<Author> GetAuthor(int id);
        public Task<Author> CreateAuthor(AuthorForCreationDto author);
        public Task UpdateAuthor(int id, AuthorForUpdateDto author);
        public Task DeleteAuthor(int id);
        public Task<Author> GetAuthorAndTheirBooks(int id);
        public Task<List<Author>> GetAllAuthorsAndTheirBooks();

    }
}
