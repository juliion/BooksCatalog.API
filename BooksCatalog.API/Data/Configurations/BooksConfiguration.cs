using BooksCatalog.API.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BooksCatalog.API.Data.Configurations
{
    public class BooksConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(book => book.Title)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(book => book.Description)
                .HasMaxLength(500)
                .IsRequired();
            builder.Property(book => book.PublishDate)
                .IsRequired();
            builder.Property(book => book.Pages)
               .IsRequired();
        }
    }
}
