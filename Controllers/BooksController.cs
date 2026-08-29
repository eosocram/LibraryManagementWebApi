using Microsoft.AspNetCore.Mvc;
using LibraryManagement.Api.Models;
namespace LibraryManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{


    private List<Book> books = new()
    {
        new Book
        {
        Title = "Title1",
        Author = "Author1",
        Id = 1
        },

        new Book
        {
            Title = "Title2",
            Author = "Author2",
            Id = 2
        }
    };
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(books);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        if (id <= 0)
        {
            return BadRequest();
        }
        
        Book? book = books.FirstOrDefault(book => book.Id == id);
        if (book == null)
        {
            return NotFound();
        }
        return Ok(book);
    }

    [HttpPost]
    public IActionResult Post(Book book)
    {
        return Created("api/books/15",book);
    }

    [HttpPut("{id}")]
    public IActionResult PutById(int id, Book updateBook)
    {
        if (id <= 0)
        {
            return BadRequest();
        }

        Book? book = books.FirstOrDefault(book => book.Id == id);
        if (book == null)
        {
            return NotFound();
        }

        book.Title = updateBook.Title;
        book.Author = updateBook.Author;
        return Ok(updateBook);

    }

    [HttpDelete("{id}")]
    public IActionResult DeleteById(int id)
    {
        if (id <= 0)
        {
            return BadRequest();
        }

        Book? book = books.FirstOrDefault(book => book.Id == id);
        if (book == null)
        {
            return NotFound();
        }

        books.Remove(book);
        return NoContent();
    }
}