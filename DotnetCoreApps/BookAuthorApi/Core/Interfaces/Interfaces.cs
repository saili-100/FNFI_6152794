
namespace BookAuthorApi.Core.Interfaces
{
    using BookAuthorApi.Core.DTOs;
    using BookAuthorApi.Core.Entities;
    using BookAuthorApi.Infrastructure;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    //All APIs are asynchronous, returning Task or Task<T> to support non-blocking operations. This is particularly useful for I/O-bound operations like database access. All End points are implemented asynchronously.
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAllAuthorsAsync();
        Task<Author> GetAuthorByIdAsync(int authorId);
        Task<Author> AddAuthorAsync(Author author);
        Task UpdateAuthorAsync(Author author);
        Task DeleteAuthorAsync(int authorId);
    }
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book> GetBookByIdAsync(int bookId);
        Task<Book> AddBookAsync(Book book);
        Task UpdateBookAsync(Book book);
        Task DeleteBookAsync(int bookId);
    }

    public class AuthorRepository : IAuthorRepository
    {
        private readonly BookAuthorDbContext _context;
        public AuthorRepository(BookAuthorDbContext context)
        {
            this._context = context;
        }
        public async Task<Author> AddAuthorAsync(Author author)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
            return author;//implicitly filled with the generated AuthorId
        }

        public async Task DeleteAuthorAsync(int authorId)
        {
            var author = await _context.Authors.Include(a => a.Books).FirstOrDefaultAsync(a => a.AuthorId == authorId);
            if (author != null)
            {
                // Optionally, remove related books if cascade delete is not configured
                if (author.Books != null && author.Books.Any())
                {
                    _context.Books.RemoveRange(author.Books);
                }
                _context.Authors.Remove(author);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Author>> GetAllAuthorsAsync()
        {
            return await _context.Authors.Include(a => a.Books).ToListAsync();
        }

        public async Task<Author> GetAuthorByIdAsync(int authorId) => await _context.Authors.Include(a => a.Books).FirstOrDefaultAsync(a => a.AuthorId == authorId);


        public async Task UpdateAuthorAsync(Author author)
        {
            var existingAuthor = await _context.Authors.FirstOrDefaultAsync(a => a.AuthorId == author.AuthorId);
            if (existingAuthor != null)
            {
                existingAuthor.Name = author.Name;
                await _context.SaveChangesAsync();
            }
        }

    }

    public class BookRepository : IBookRepository
    {
        private readonly BookAuthorDbContext _context;
        public BookRepository(BookAuthorDbContext context)
        {
            this._context = context;
        }
        public async Task<Book> AddBookAsync(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;//implicitly filled with the generated BookId
        }


        public async Task DeleteBookAsync(int bookId)
        {

            var book = await _context.Books.FindAsync(bookId);
            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }


        }
        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _context.Books.Include(b => b.Author).ToListAsync();
        }
        public async Task<Book> GetBookByIdAsync(int bookId) => await _context.Books.Include(b => b.Author).FirstOrDefaultAsync(b => b.BookId == bookId);
        public async Task UpdateBookAsync(Book book)
        {

            var existingBook = await _context.Books.FindAsync(book.BookId);
            if (existingBook != null)
            {
                existingBook.Title = book.Title;
                existingBook.BookPrice = book.BookPrice;
                existingBook.AuthorId = book.AuthorId;

                await _context.SaveChangesAsync();
            }

        }
    }
}