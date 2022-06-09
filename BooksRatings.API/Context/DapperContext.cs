using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace BooksRatings.API.Context
{
    public class DapperContext
    {
        private readonly IConfiguration _config;
        private readonly string _connString;
        public DapperContext(IConfiguration config)
        {
            _config = config;
            _connString = _config.GetConnectionString("DefaultConnection");
        }
        public IDbConnection CreateConnection() => new SqlConnection(_connString);

    }
}
