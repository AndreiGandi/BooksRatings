using BooksRatings.API.Dto;
using BooksRatings.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BooksRatings.API.Services
{
    public class AuthorService : IAuthorService
    {
        public Task<Author> Create(AuthorForCreationDto author)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Author>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Author>> GetAllAuthorsAndTheirBooks()
        {
            throw new System.NotImplementedException();
        }

        public Task<Author> GetAuthorAndTheirBooks(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Author> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(int id, AuthorForUpdateDto author)
        {
            throw new System.NotImplementedException();
        }
    }
}
