using Microsoft.AspNetCore.Mvc;
using Fisher.Bookstore.Models;
using Fisher.Bookstore.Services;
using Microsoft.AspNetCore.Authorization;

namespace Fisher.Bookstore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private IBooksRepository booksRepository;

        public BooksController(IBooksRepository repository)
        {
            booksRepository = repository;
        }
    [HttpGet("{bookId")]

    public IActionResult Get(int bookId)
    {
        if(!booksRepository.BookExists(bookId))
        {
            return NotFound();
        }
        return Ok(booksRepository.GetBooks());
    }
    [HttpPost]
    public IActionResult Post([FromBody]Book book)
    {
        var bookId = booksRepository.AddBook(book);
        return Created($"https://localhost:5001/api/books/{bookId}", book);
    }
    [HttpPut("{bookId}")]
    public IActionResult Put(int bookId, [FromBody] Book book)
    {
        if(bookId != book.Id)
        {
            return BadRequest();
        }
        if(!booksRepository.BookExists(bookId))
        {
            return NotFound();
        }
        booksRepository.UpdateBook(book);
        return Ok(book);
    }
    [HttpDelete("{bookId}")]
    [Authorize]
    public IActionResult Delete(int bookId)
    {
        if(!booksRepository.BookExists(bookId))
        {
            return NotFound();
        }
        booksRepository.DeleteBook(bookId);
        return Ok();
    }
    }
}