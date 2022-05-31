using BooksRatings.API.Models;
using System.Collections.Generic;

namespace BooksRatings.API.Repositories
{
    public interface IBookRepository
    {
        Book Get(int id);
        List<Book> GetAll();
        Book Add(Book book);
        Book Update(Book book);
        void Remove(int id);

    }
}
