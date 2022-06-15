using BooksRatings.API.Dto;
using BooksRatings.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BooksRatings.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;
        public AuthorsController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAuthors()
        {
            try
            {
                var authors = await _authorRepository.GetAuthors();
                return Ok(authors);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthor(int id)
        {
            try
            {
                var author = await _authorRepository.GetAuthor(id);
                return (author == null)?NotFound():Ok(author);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateAuthor(AuthorForCreationDto author)
        {
            try
            {
                var createdAuthor = await _authorRepository.CreateAuthor(author);
                return Ok(createdAuthor);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor(int id, AuthorForUpdateDto author)
        {
            try
            {
                var dbAuthor = await _authorRepository.GetAuthor(id);
                if (dbAuthor == null)
                    return NotFound();
                await _authorRepository.UpdateAuthor(id, author);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            try
            {
                await _authorRepository.DeleteAuthor(id);
                return NoContent() ;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
