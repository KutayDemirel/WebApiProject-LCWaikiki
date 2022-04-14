using AutoMapper;
using PatikaWebApi.BookOperations.CreateBook;
using PatikaWebApi.BookOperations.GetBooks;
using PatikaWebApi.BookOperations.GetBooksDetail;

namespace PatikaWebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>(); 
            CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => (
                (GenreEnum)src.GenreId).ToString()));
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => (
                (GenreEnum)src.GenreId).ToString()));
        }

    }
}
