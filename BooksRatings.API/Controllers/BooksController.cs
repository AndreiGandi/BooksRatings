using BooksRatings.API.Models;
using BooksRatings.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BooksRatings.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private IBookRepository _bookRepository;
        public BooksController(IBookRepository bookRepository)
        {
            bookRepository = _bookRepository;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetAllBooks()
        {
            try
            {
                return _bookRepository.GetAll();
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }
        [HttpGet("{id}")]
        public ActionResult<Book> GetBook(int id)
        {
            var book = _bookRepository.Get(id);
            return book == null ? NotFound() : Ok(book);
        }
        [HttpPost]
        public ActionResult<Book> PostBook(Book book)
        {
            var addedBook = _bookRepository.Add(book);
            return Ok(addedBook);
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _bookRepository.Remove(id);
            return Ok();
        }


    }
}
