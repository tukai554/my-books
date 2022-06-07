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
    public class PublisherController : ControllerBase
    {
        private PublisherService _publisherService;
        public PublisherController(PublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        [HttpPost]
        [Route("api/AddPublishers")]
        public IActionResult AddPublisher([FromBody] PublisherViewModel publisherViewModel)
        {
            if(publisherViewModel!=null)
            {
                _publisherService.AddPublisher(publisherViewModel);
            }
            return Ok();
        }

        [HttpGet]
        [Route("api/GetBookByPublisher")]
        public IActionResult GetBookByPublisher(int publisherId)
        {
            var books = _publisherService.GetBooksByPublisher(publisherId);
            return Ok(books);
        }
    }
}
