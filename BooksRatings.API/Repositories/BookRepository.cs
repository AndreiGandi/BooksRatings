using BooksRatings.API.Context;
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
        public async Task<Book> AddBook(Book book)
        {
            var query = "INSERT INTO Books (ISBN,Title,Description,AuthorId,Year) VALUES (@ISBN, @Title, @Description, @AuthorId, @Year);" +
                "SELECT CAST(SCOPE_IDENTITY() as int);";
            using (var dbConn = _dapperContext.CreateConnection())
            {
                var id = await dbConn.QueryAsync<int>(query,
                    new
                    {
                        book.ISBN,
                        book.Title,
                        book.Description,
                        book.AuthorId,
                        book.Year
                    });
                book.Id = id.Single();
                return book;
            }
        }
    }
}
