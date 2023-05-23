using BooksCatalog.API.Common.Exceptions;
using BooksCatalog.API.DTOs;
using BooksCatalog.API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;

namespace BooksCatalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _booksService;

        public BooksController(IBooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpGet("GetBooks")]
        public async Task<IActionResult> GetBooks()
        {
            var books = await _booksService.GetBooks();

            return Ok(books);
        }
        [HttpGet("GetBook/{id}")]
        public async Task<IActionResult> GetBook(Guid id)
        {
            try
            {
                var book = await _booksService.GetBook(id);

                return Ok(book);
            }
            catch (NotFoundException)
            {
                return NotFound("Book not found");
            }
        }
        [HttpPost("CreateBook")]
        public async Task<IActionResult> CreateBook(CreateBookDTO bookDTO)
        {
            var bookId = await _booksService.CreateBook(bookDTO);

            return Ok(bookId);
        }

        [HttpPut("UpdateBook/{id}")]
        public async Task<IActionResult> UpdateBook(Guid id, UpdateBookDTO bookDTO)
        {
            try
            {
                await _booksService.UpdateBook(id, bookDTO);

                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound("Book not found");
            }
        }

        [HttpDelete("DeleteBook/{id}")]
        public async Task<IActionResult> DeleteBook(Guid id)
        {
            try
            {
                await _booksService.DeleteBook(id);

                return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

    }
}
