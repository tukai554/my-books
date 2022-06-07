using Microsoft.EntityFrameworkCore;
using my_books.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base (options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book_Author>()
                .HasOne(b => b.Book)
                .WithMany(bi => bi.Book_Authors)
                .HasForeignKey(key => key.BookId);
            modelBuilder.Entity<Book_Author>()
                .HasOne(b => b.Author)
                .WithMany(bi => bi.Book_Authors)
                .HasForeignKey(key => key.AuthorId);

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Book_Author> Book_Authors { get; set; }

    }
}
