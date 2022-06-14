using BooksRatings.API.Context;
using BooksRatings.API.Dto;
using BooksRatings.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using System.Linq;

namespace BooksRatings.API.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly DapperContext _dapperContext;
        public AuthorRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<Author> CreateAuthor(AuthorForCreationDto author)
        {
            throw new System.NotImplementedException();
        }

        public async Task DeleteAuthor(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Author> GetAuthor(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Author>> GetAuthors()
        {
            var query = "SELECT * FROM Authors";
            using (var dbConn = _dapperContext.CreateConnection())
            {
                var authors = await dbConn.QueryAsync<Author>(query);
                return authors.ToList();
            }
        }

        public async Task UpdateAuthor(int id, AuthorForUpdateDto author)
        {
            throw new System.NotImplementedException();
        }
    }
}
