using BookAuthorApi.Core.DTOs;
using BookAuthorApi.Core.Entities;
using BookAuthorApi.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

//API Controllers are similar to controllers of MVC applications, but they are specifically designed to handle HTTP requests and responses for RESTful APIs. They typically return data in formats like JSON or XML rather than rendering views.

namespace BookAuthorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        public BookController(IBookRepository repo)
        {
            this._bookRepository = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookRepository.GetAllBooksAsync();
            var model = books.Select(b => new BookDto(b.BookId, b.Title,
b.BookPrice, b.AuthorId));
            return Ok(model);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(new BookDto(book.BookId, book.Title, book.BookPrice, book.AuthorId));
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] BookDto updatedBook)
        {
            var existingBook = await _bookRepository.GetBookByIdAsync(id);
            if (existingBook == null)
            {
                return NotFound();
            }

            existingBook.Title = updatedBook.Title;
            existingBook.BookPrice = updatedBook.BookPrice;
            existingBook.AuthorId = updatedBook.AuthorId;

            await _bookRepository.UpdateBookAsync(existingBook);
            return NoContent(); // 204 No Content

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            await _bookRepository.DeleteBookAsync(id);
            return NoContent(); // 204 No Content
        }

        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] BookDto book)
        {
            if (book == null)
                return BadRequest();

            var entity = new Book
            {
                Title = book.Title,
                BookPrice = book.BookPrice,
                AuthorId = book.AuthorId
            };

            var created = await _bookRepository.AddBookAsync(entity);
            return CreatedAtAction(nameof(GetBookById), new { id = created.BookId }, new BookDto(created.BookId, created.Title, created.BookPrice, created.AuthorId));
        }

    }
}


