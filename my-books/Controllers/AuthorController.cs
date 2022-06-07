using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Data.Services;
using my_books.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
      private AuthorService _authorService;
      public AuthorController(AuthorService authorService)
        {
            _authorService = authorService;
        }

    [HttpPost]
    [Route("api/AddAuthors")]
    public IActionResult AddAuthor ([FromBody] AuthorViewModel authorViewModel)
        {
            if(authorViewModel!=null)
            {
                _authorService.AddAuthor(authorViewModel);
            }
            return Ok();
        }
        [HttpGet]
        [Route("api/GetBookByAuthor")]
        public IActionResult GetBookByAuthor(int authorId)
        {
            var books = _authorService.GetBookByAuthor(authorId);
            return Ok(books);
        }
    }
}
