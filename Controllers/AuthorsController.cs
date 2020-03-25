using Microsoft.AspNetCore.Mvc;
using Fisher.Bookstore.Models;
using Fisher.Bookstore.Services;

namespace Fisher.Bookstore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {        private IAuthorsRepository AuthorsRepository;
        public AuthorsController(IAuthorsRepository repository)
        {
        AuthorsRepository = repository;
        }

       
    [HttpGet]

    public IActionResult GetAll()
    {
        return Ok();
    }
    [HttpPost]
    public IActionResult Post([FromBody]Author author)
    {
        var bookId = AuthorsRepository.AddAuthor(author);
        return Created($"https://localhost:5001/api/authors/{author}", author);
    }
    [HttpPut("{authorId}")]
    public IActionResult Put(int authorId, [FromBody] Author author)
    {
        if(authorId != author.Id)
        {
            return BadRequest();
        }
        if(!AuthorsRepository.AuthorExists(authorId))
        {
            return NotFound();
        }
       AuthorsRepository.UpdateAuthor(author);
        return Ok(author);
    }
    [HttpDelete("{authorId}")]
    public IActionResult Delete(int authorId)
    {
        if(!AuthorsRepository.AuthorExists(authorId))
        {
            return NotFound();
        }
        AuthorsRepository.DeleteAuthor(authorId);
        return Ok();
    }
    }
}