using BooksRatings.API.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BooksRatings.API.Repositories
{
    public class BookRepository : IBookRepository
    {
        private IDbConnection _db;
        public BookRepository(IConfiguration config)
        {
            _db = new SqlConnection(config.GetConnectionString("DefaultConnection"));
        }
        public Book Add(Book book)
        {
            var parameters = new DynamicParameters();
            parameters.Add("BookId", 0, DbType.Int32, ParameterDirection.Output);
            parameters.Add("ISBN", book.ISBN, DbType.String, ParameterDirection.Input);
            parameters.Add("Title", book.Title, DbType.String, ParameterDirection.Input);
            parameters.Add("Description", book.Description, DbType.String, ParameterDirection.Input);
            parameters.Add("AuthorId", book.AuthorId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("Year", book.Year, DbType.Int32, ParameterDirection.Input);
            var sp = "AddBook";
            _db.Execute(sp, parameters, commandType: CommandType.StoredProcedure);
            book.Id = parameters.Get<int>("BookId");
            return book;
        }

        public Book Get(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32, direction:ParameterDirection.Input);
            var sp = "GetBook";
            return _db.Query<Book>(sp, parameters, commandType: CommandType.StoredProcedure).Single();
        }

        public List<Book> GetAll()
        {
            return _db.Query<Book>("GetAllBooks", commandType:CommandType.StoredProcedure).ToList();
        }

        public void Remove(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32, direction: ParameterDirection.Input);
            _db.Execute("RemoveBook", parameters, commandType: CommandType.StoredProcedure);
        }

        public Book Update(Book book)
        {
            var parameters = new DynamicParameters();
            parameters.Add("BookId", book.Id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("ISBN", book.ISBN, DbType.String, ParameterDirection.Input);
            parameters.Add("Title", book.Title, DbType.String, ParameterDirection.Input);
            parameters.Add("Description", book.Description, DbType.String, ParameterDirection.Input);
            parameters.Add("AuthorId", book.AuthorId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("Year", book.Year, DbType.Int32, ParameterDirection.Input);
            var sp = "UpdateBook";
            _db.Execute(sp, parameters, commandType: CommandType.StoredProcedure);
            return book;
        }
    }
}
