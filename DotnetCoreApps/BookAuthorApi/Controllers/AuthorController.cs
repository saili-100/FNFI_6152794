using BookAuthorApi.Core.DTOs;
using BookAuthorApi.Core.Entities;
using BookAuthorApi.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookAuthorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository _authorService;

        public AuthorController(IAuthorRepository authorService)
        {
            _authorService = authorService;
        }

        // GET: api/Author
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorDto>>> GetAllAuthors()
        {
            var authors = await _authorService.GetAllAuthorsAsync();
            var authorDtos = authors.Select(a => new AuthorDto(a.AuthorId, a.Name));
            return Ok(authorDtos);
        }

        // GET: api/Author/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDto>> GetAuthorById(int id)
        {
            var author = await _authorService.GetAuthorByIdAsync(id);
            if (author == null)
                return NotFound();
            return Ok(new AuthorDto(author.AuthorId, author.Name));
        }

        // POST: api/Author
        [HttpPost]
        public async Task<ActionResult<AuthorDto>> CreateAuthor([FromBody] AuthorDto authorDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var author = new Author { Name = authorDto.Name };
            var createdAuthor = await _authorService.AddAuthorAsync(author);
            var createdDto = new AuthorDto(createdAuthor.AuthorId, createdAuthor.Name);
            return CreatedAtAction(nameof(GetAuthorById), new { id = createdDto.AuthorId }, createdDto);
        }

        // PUT: api/Author/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor(int id, [FromBody] AuthorDto authorDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var author = await _authorService.GetAuthorByIdAsync(id);
            if (author == null)
                return NotFound();

            author.Name = authorDto.Name;
            await _authorService.UpdateAuthorAsync(author);
            return NoContent();
        }

        // DELETE: api/Author/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var author = await _authorService.GetAuthorByIdAsync(id);
            if (author == null)
                return NotFound();

            await _authorService.DeleteAuthorAsync(id);
            return NoContent();
        }
    }
}








