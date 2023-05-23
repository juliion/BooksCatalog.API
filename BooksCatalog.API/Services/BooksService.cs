using AutoMapper;
using BooksCatalog.API.Common.Exceptions;
using BooksCatalog.API.Data;
using BooksCatalog.API.Data.Entities;
using BooksCatalog.API.DTOs;
using BooksCatalog.API.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;

namespace BooksCatalog.API.Services
{
    public class BooksService : IBooksService
    {
        private readonly BooksCatalogContext _context;
        private readonly IMapper _mapper;

        public BooksService(BooksCatalogContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid> CreateBook(CreateBookDTO bookDTO)
        {
            var newBook = _mapper.Map<CreateBookDTO, Book>(bookDTO);

            _context.Books.Add(newBook);
            await _context.SaveChangesAsync();

            return newBook.Id;
        }

        public async Task DeleteBook(Guid id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                throw new NotFoundException();
            }
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }

        public async Task<BookDTO> GetBook(Guid id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                throw new NotFoundException();
            }

            var bookDto = _mapper.Map<Book, BookDTO>(book);

            return bookDto;
        }

        public async Task<IEnumerable<BookDTO>> GetBooks(Guid bookId)
        {
            var books = await _context.Books.ToListAsync();

            var booksDTOs = _mapper.Map<List<Book>, List<BookDTO>>(books);

            return booksDTOs;
        }

        public async Task UpdateBook(Guid id, UpdateBookDTO bookDTO)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                throw new NotFoundException();
            }

            book.Title = bookDTO.Title;
            book.Description = bookDTO.Description;
            book.PublishDate = bookDTO.PublishDate;
            book.Pages = bookDTO.Pages;

            await _context.SaveChangesAsync();
        }
    }
}
