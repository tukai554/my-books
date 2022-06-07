using my_books.Data.Models;
using my_books.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Data.Services
{
    public class AuthorService
    {
        private AppDbContext _context;
        public AuthorService(AppDbContext context)
        {
            _context = context;
        }

        public void AddAuthor(AuthorViewModel authors)
        {
            var author = new Author()
            {
                FullName=authors.FullName

            };
            _context.Authors.Add(author);
            _context.SaveChanges();

        }
        public AuthorWithBooksViewModel GetBookByAuthor(int id)
        {

            var bookDetails = _context.Authors.Where(b => b.Id==id).Select(book => new AuthorWithBooksViewModel()
            {
                BookTitles=book.Book_Authors.Select(x=>x.Book.Title).ToList(),
                AuthorName=book.FullName

            }).FirstOrDefault();
            return bookDetails;
        }
    }
}
