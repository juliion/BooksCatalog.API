using BooksCatalog.API.DTOs;

namespace BooksCatalog.API.Interfaces
{
    public interface IBooksService
    {
        public Task<Guid> CreateBook(CreateBookDTO bookDTO);
        public Task UpdateBook(Guid id, UpdateBookDTO bookDTO);
        public Task DeleteBook(Guid id);
        public Task<IEnumerable<BookDTO>> GetBooks(Guid bookId);
        public Task<BookDTO> GetBook(Guid id);
    }
}
