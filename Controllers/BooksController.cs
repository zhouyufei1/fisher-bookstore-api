using Fisher.Bookstore.Models;
using Fisher.Bookstore.Services;
using Microsoft.AspNetCore.Mvc;

namespace Fisher.Bookstore.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private IBooksRepository repository;

        public BooksController(IBooksRepository booksRepository)
        {
            repository = booksRepository;
        }

        [HttpGet()]
        public IActionResult GetAll()
        {
            var books = repository.GetBooks();
            return Ok(books);
        }

        [HttpGet("{bookId}")]
        public IActionResult Get(int bookId)
        {
            var book = repository.GetBook(bookId);
            return Ok(book);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Book book)
        {
            var bookId = repository.AddBook(book);
            return Created($"https://localhost:5001/api/books/{book.Id}", book);
        }

        [HttpPut]
        public IActionResult Put([FromBody]Book book)
        {
            repository.UpdateBook(book);
            return Ok(book);
        }

        [HttpDelete("{bookId}")]
        public IActionResult Delete(int bookId)
        {
            repository.DeleteBook(bookId);
            return Ok();
        }



    }
}