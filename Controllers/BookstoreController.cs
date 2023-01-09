using Bookstore.Models;
using Bookstore.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookstoreController : ControllerBase
    {  
        [HttpGet("books")]
        public ActionResult<List<Book>> GetBooks()
        {
            return BookstoreService.GetAllBooks();
        }

        [HttpGet("book/{id}")]
        public ActionResult<Book> GetBook(int id)
        {
            Book? book = BookstoreService.GetBook(id);
            return book == null ? NotFound() : Ok(book);
        }

        [HttpGet("authors")]
        public ActionResult<List<Author>> GetAuthors()
        {
            return BookstoreService.GetAllAuthors();
        }

        [HttpGet("author/{id}")]
        public ActionResult<List<Author>> GetAuthor(int id)
        {
            Author? author = BookstoreService.GetAuthor(id);
            return author == null ? NotFound() : Ok(author);
        }

        [HttpGet("author/{id}/books")]
        public ActionResult<List<Book>> GetAuthorBooks(int id)
        {
            Author? author = BookstoreService.GetAuthor(id);
            List<Book> books = BookstoreService.GetAllBooks();

            return books.Where(book => book.Author == author).ToList();
        }

        [HttpPost("author")]
        public IActionResult CreateAuthor(Author author)
        {
            BookstoreService.AddAuthor(author);
            return CreatedAtAction(nameof(CreateAuthor), new { id = author.Id }, author);
        }

        [HttpPut("author")]
        public IActionResult UpdateAuthor(int id, Author author)
        {
            if (id != author.Id) return BadRequest();

            var existingAuthor = BookstoreService.GetAuthor(id);

            if (existingAuthor is null) return NotFound();

            BookstoreService.UpdateAuthor(author);

            return NoContent();
        }

        [HttpDelete("author/{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            var existingAuthor = BookstoreService.GetAuthor(id);

            if (existingAuthor is null) return NotFound();

            BookstoreService.DeleteAuthor(id);

            return NoContent();
        }

        [HttpPost("book")]
        public IActionResult CreateBook(Book book)
        {
            BookstoreService.AddBook(book);
            return CreatedAtAction(nameof(CreateBook), new { id = book.Id }, book);
        }

        [HttpPut("book")]
        public IActionResult UpdateBook(int id, Book book)
        {
            if (id != book.Id) return BadRequest();

            var existingBook = BookstoreService.GetBook(id);

            if (existingBook is null) return NotFound();

            BookstoreService.UpdateBook(book);

            return NoContent();
        }

        [HttpDelete("book/{id}")]
        public IActionResult DeleteBook(int id)
        {
            var existingBook = BookstoreService.GetBook(id);

            if (existingBook is null) return NotFound();

            BookstoreService.DeleteBook(id);

            return NoContent();
        }
    }
}