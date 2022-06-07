using my_books.Data.Models;
using my_books.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Data.Services
{
    public class PublisherService
    {
        private AppDbContext _context;
        public PublisherService(AppDbContext context)
        {
            _context = context;
        }

        public void AddPublisher(PublisherViewModel publishers)
        {
            var publisher = new Publisher()
            {
                Name = publishers.Name

            };
            _context.Publishers.Add(publisher);
            _context.SaveChanges();

        }
        public PublisherWithBooksViewModel GetBooksByPublisher(int id)
        {
            var bookDetails = _context.Publishers.Where(p => p.Id == id).Select(x => new PublisherWithBooksViewModel()
            {
                PublisherName=x.Name,
                BookAuthors=x.Books.Select(n=> new BookAuthorViewModel()
                {
                    BookName=n.Title,
                    AuthorNames=n.Book_Authors.Select(a=>a.Author.FullName).ToList()
                }).ToList()
            }).FirstOrDefault();
            return bookDetails;
        }
    }
}
