using Microsoft.AspNetCore.Mvc;
using LibraryManagement.Api.Models;
namespace LibraryManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        var book1 = new Book
        {
            Title = "Title1",
            Author = "Author1"
        };

        var book2 = new Book
        {
            Title = "Title2", 
            Author = "Author2"
        };

        var books = new List<Book>
        {
            book1,
            book2
        };
        
        return Ok(books);
    }
}