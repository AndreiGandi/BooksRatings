﻿using BooksRatings.API.Context;
using BooksRatings.API.Dto;
using BooksRatings.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using System.Linq;
using System.Data;

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
            var query = "INSERT INTO dbo.Authors (FirstName,MiddleName,LastName) VALUES(@FirstName, @MiddleName, @LastName);" +
                        "SELECT CAST(SCOPE_IDENTITY() as int)";
            var parameters = new DynamicParameters();
            parameters.Add("FirstName", author.FirstName, DbType.String);
            parameters.Add("MiddleName", author.MiddleName, DbType.String);
            parameters.Add("LastName", author.LastName, DbType.String);
            using (var dbConn = _dapperContext.CreateConnection())
            {
                var id = await dbConn.QuerySingleAsync<int>(query, parameters);
                var createdAuthor = new Author()
                {
                    Id = id,
                    FirstName = author.FirstName,
                    MiddleName = author.MiddleName,
                    LastName = author.LastName
                };
                return createdAuthor;
            }
        }
        public async Task<Author> GetAuthor(int id)
        {
            var query = "SELECT * FROM Authors WHERE Id = @Id";
            using (var dbConn = _dapperContext.CreateConnection())
            {
                var author = await dbConn.QuerySingleOrDefaultAsync<Author>(query, new { Id = id });
                return author;
            }
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
            var query = "UPDATE dbo.Authors SET FirstName = @FirstName, MiddleName = @MiddleName, LastName = @LastName WHERE Id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.String);
            parameters.Add("FirstName", author.FirstName, DbType.String);
            parameters.Add("MiddleName", author.MiddleName, DbType.String);
            parameters.Add("LastName", author.LastName, DbType.String);
            using (var dbConn = _dapperContext.CreateConnection())
            {
                await dbConn.ExecuteAsync(query, parameters);
            }
        }
        public async Task DeleteAuthor(int id)
        {
            var query = "DELETE FROM Authors WHERE Id = @Id";
            using ( var dbConn = _dapperContext.CreateConnection())
            {
                await dbConn.ExecuteAsync(query, new { Id = id });
            }
        }
    }
}
