using AutoMapper;
using BooksCatalog.API.Data.Entities;
using BooksCatalog.API.DTOs;

namespace BooksCatalog.API.Common.Mappings
{
    public class BooksCatalogProfile : Profile
    {
        public BooksCatalogProfile() 
        {
            CreateMap<CreateBookDTO, Book>();
            CreateMap<Book, BookDTO>();
        }
    }
}
