using BooksCatalog.API.Data.Configurations;
using BooksCatalog.API.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BooksCatalog.API.Data
{
    public class BooksCatalogContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public BooksCatalogContext(DbContextOptions<BooksCatalogContext> opt) : base(opt) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new BooksConfiguration());
        }
    }
}
