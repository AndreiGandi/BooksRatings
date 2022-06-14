using BooksRatings.API.Context;
using BooksRatings.API.Dto;
using BooksRatings.API.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BooksRatings.API.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly DapperContext _dapperContext;
        public BookRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<IEnumerable<Book>> GetBooks()
        {
            var query = "SELECT * FROM Books";
            using (var dbConn = _dapperContext.CreateConnection())
            {
                var books = await dbConn.QueryAsync<Book>(query);
                return books.ToList();
            }
        }
        public async Task<Book> GetBook(int id)
        {
            var query = "SELECT * FROM Books WHERE Id = @Id";
            using (var dbConn = _dapperContext.CreateConnection())
            {
                var book = await dbConn.QueryAsync<Book>(query, new { @Id=id });
                return book.FirstOrDefault();
            }
        }
        public async Task<Book> CreateBook(BookForCreationDto book)
        {
            var sql = "INSERT INTO dbo.Books(ISBN,Title,Description,AuthorId,Year) VALUES(@ISBN,@Title,@Description,@AuthorId,@Year);" +
                      "SELECT CAST(SCOPE_IDENTITY() as int)";
            var parameters = new DynamicParameters();
            parameters.Add("ISBN", book.ISBN, DbType.String);
            parameters.Add("Title", book.Title, DbType.String);
            parameters.Add("Description", book.Description, DbType.String);
            parameters.Add("AuthorId", book.AuthorId, DbType.Int32);
            parameters.Add("Year", book.Year, DbType.Int32);
            using (var dbConn = _dapperContext.CreateConnection())
            {
                var id = await dbConn.QuerySingleAsync<int>(sql, parameters);
                var createdBook = new Book()
                {
                    Id = id,
                    ISBN = book.ISBN,
                    Title = book.Title,
                    Description = book.Description,
                    AuthorId = book.AuthorId,
                    Year = book.Year,
                };
                return createdBook;
            }
        }

        public async Task UpdateBook(int id, BookForUpdateDto book)
        {
            var query = "UPDATE dbo.Books SET ISBN = @ISBN,Title = @Title, Description = @Description, AuthorId = @AuthorId, Year = @Year WHERE Id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32);
            parameters.Add("ISBN", book.ISBN, DbType.String);
            parameters.Add("Title", book.Title, DbType.String);
            parameters.Add("Description", book.Description, DbType.String);
            parameters.Add("AuthorId", book.AuthorId, DbType.Int32);
            parameters.Add("Year", book.Year, DbType.Int32);
            using (var dbConn = _dapperContext.CreateConnection())
            {
                await dbConn.ExecuteAsync(query, parameters);
            }
        }
        public async Task DeleteBook(int id)
        {
            var query = "DELETE FROM Books WHERE Id = @Id;";
            using (var dbConn = _dapperContext.CreateConnection())
            {
                await dbConn.ExecuteAsync(query, new { id });
            }
        }
    }
}
