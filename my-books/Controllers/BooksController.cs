using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Data.Models;
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
    public class BooksController : ControllerBase
    {
        public BooksService _booksService;
        public BooksController(BooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpPost]
        [Route("api/AddBooks")]
        public IActionResult AddBooks([FromBody]BookViewModel bookViewModel)
        {
            _booksService.AddBook(bookViewModel);
            return Ok();
        }
        [HttpGet]
        [Route("api/GetBooks")]
        public List<Book> GetBooks()
        {
            var books = _booksService.GetBooks();
            return books;
        }
        [HttpGet]
        [Route("api/GetBookById")]
        public IActionResult GetBookById(int id)
        {
            var books = _booksService.GetBookById(id);
            return Ok(books);
        }
       
        [HttpPut]
        [Route("api/UpdateBooks")]
        public IActionResult UpdateBooks([FromHeader]int id,[FromBody]BookViewModel bookViewModel)
        {
            var books = _booksService.UpdateBooks(id,bookViewModel);
            return Ok(books);
        }
        [HttpDelete]
        [Route("api/DeleteBook")]
        public IActionResult DeleteBook([FromHeader]int id)
        {
            var books = _booksService.DeleteBook(id);
            return Ok(books);
        }
    }

}
