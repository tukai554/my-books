using Microsoft.EntityFrameworkCore;
using my_books.Data.Models;
using my_books.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Data.Services
{
    public class BooksService
    {
        private AppDbContext _context;
        public BooksService(AppDbContext context)
        {
            _context = context;
        }

        public void AddBook(BookViewModel book)
        {
            var books = new Book()
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.IsRead ? book.DateRead.Value : null,
                Rate = book.IsRead ? book.Rate : null,
                Genre = book.Genre,
                CoverUrl = book.CoverUrl,
                DateAdded = DateTime.Now,
                PublisherId=book.PublisherId
              };
            _context.Books.Add(books);
            _context.SaveChanges();
            foreach(var id in book.AuthorIds)
            {
                var bookAuthor = new Book_Author()
                {
                    BookId = books.Id,
                    AuthorId = id
                };
                _context.Book_Authors.Add(bookAuthor);
                _context.SaveChanges();
            }

        }

        public List<Book> GetBooks()
        {
            return _context.Books.ToList();
        }
        public BookWithAuthorViewModel GetBookById(int id)
        {
            var bookDetails = _context.Books.Where(b=>b.Id==id).Select(book=> new BookWithAuthorViewModel()
            {
                Title=book.Title,
                Description=book.Description,
                IsRead=book.IsRead,
                DateRead=book.DateRead,
                Rate=book.Rate,
                Genre=book.Genre,
                PublisherName=book.Publisher.Name,
                AuthorNames=book.Book_Authors.Select(x=>x.Author.FullName).ToList()
            }).FirstOrDefault();
            return bookDetails;
        }
        
        public Book UpdateBooks(int id,BookViewModel bookViewModel)
        {
            var book = _context.Books.FirstOrDefault(x => x.Id == id);
            if(book!=null)
            {
                book.Title = bookViewModel.Title;
                book.Description = bookViewModel.Description;
                book.IsRead = bookViewModel.IsRead;
                book.DateRead = bookViewModel.IsRead ? bookViewModel.DateRead.Value : null;
                book.Rate = bookViewModel.IsRead ? book.Rate : null;
                book.Genre = bookViewModel.Genre;
                book.CoverUrl = bookViewModel.CoverUrl;
            }
            _context.SaveChanges();
            return book;
        }
        public Book DeleteBook(int id)
        {
            var book = _context.Books.FirstOrDefault(x => x.Id == id);
            _context.Entry(book).State = EntityState.Deleted;
            _context.SaveChanges();
            return book;
        }
    }
}
