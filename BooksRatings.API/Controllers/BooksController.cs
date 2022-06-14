using BooksRatings.API.Dto;
using BooksRatings.API.Models;
using BooksRatings.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

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
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            try
            {
                var book = await _bookRepository.GetBook(id);
                return book == null ? NotFound() : Ok(book);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
        [HttpPost]
        public async Task<IActionResult> CreateBook(BookForCreationDto book)
        {
            try
            {
                var createdBook = await _bookRepository.CreateBook(book);
                return Ok(createdBook);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, BookForUpdateDto book)
        {
            try
            {
                var dbBook = await _bookRepository.GetBook(id);
                if (dbBook == null)
                    return NotFound();
                await _bookRepository.UpdateBook(id, book);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            try
            {
                await _bookRepository.DeleteBook(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
