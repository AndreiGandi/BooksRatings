using BooksRatings.API.Models;
using BooksRatings.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BooksRatings.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private IBookRepository _bookRepository;
        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            try
            {
                var books = await _bookRepository.GetBooks();
                return Ok(books);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }
        [HttpGet("{id}")]
        public ActionResult<Book> GetBook(int id)
        {
            try
            {
                var book = _bookRepository.GetBook(id);
                return book == null ? NotFound() : Ok(book);
            }
            catch(System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }
        //[HttpPost]
        //public ActionResult<Book> PostBook(Book book)
        //{
        //    var addedBook = _bookRepository.Add(book);
        //    return Ok(addedBook);
        //}
        //[HttpDelete("{id}")]
        //public ActionResult Delete(int id)
        //{
        //    _bookRepository.Remove(id);
        //    return Ok();
        //}


    }
}
